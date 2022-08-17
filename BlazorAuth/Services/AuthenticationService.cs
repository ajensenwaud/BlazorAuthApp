using System.Security.Authentication;
using BlazorAuth.Data;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Identity;

namespace BlazorAuth.Services;

public class AuthenticationService
{
    public enum AuthenticationResult
    {
        UserDoesNotExist,
        UserCannotSignIn,
        UserIsBlocked,
        Success,
        Failure,
        TwoFactorRequired,
        UnknownError
    }

    private readonly IdentityContext _identityContext;
    private readonly NavigationManager _navigationManager;
    private readonly SessionState _sessionState;
    private readonly SignInManager<BlazorAuthUser> _signInManager;
    private readonly UserManager<BlazorAuthUser> _userManager;
    private readonly EmailService _emailService;

    public AuthenticationService(
        SignInManager<BlazorAuthUser> signInManager,
        UserManager<BlazorAuthUser> userManager,
        IdentityContext identityContext,
        SessionState sessionState,
        NavigationManager navManager,
        EmailService emailService
    )
    {
        _userManager = userManager;
        _identityContext = identityContext;
        _signInManager = signInManager;
        _sessionState = sessionState;
        _emailService = emailService;
        _navigationManager = navManager;
    }

    public int LookupByEmail(string email)
    {
        var numUsers = _identityContext.Users.Count(xx => xx.Email == email);
        return numUsers;
    }

    public int LookupByUsername(string username)
    {
        var numUsers = _identityContext.Users.Count(xx => xx.UserName == username);
        return numUsers;
    }


    public async Task<(AuthenticationResult, SignInResult?, BlazorAuthUser?)> LoginAsync(string email,
        string password, bool rememberMe)
    {
        try
        {
            var usr = GetByEmail(email);
            if (usr == null) return (AuthenticationResult.UserDoesNotExist, null, null);
            if (await _signInManager.CanSignInAsync(usr))
            {
                var res = await _signInManager.CheckPasswordSignInAsync(usr, password, false);
                if (res == SignInResult.Success)
                {
                    var key = Guid.NewGuid();
                    BlazorCookieLoginMiddleware.Logins[key] = new LoginInfo
                    { Username = usr.UserName, Email = email, Password = password, RememberMe = rememberMe };
                    _sessionState.SessionKey = key;
                    // See https://github.com/dotnet/aspnetcore/issues/13601 for details
                    _navigationManager.NavigateTo($"/login?key={key}", true);
                    return (AuthenticationResult.Success, res, usr);
                }

                return (AuthenticationResult.Failure, res, usr);
            }

            return (AuthenticationResult.UserIsBlocked, null, usr);
        }
        catch (Exception ex)
        {
            throw new AuthenticationException(ex.ToString());
        }
    }

    public async Task<(BlazorAuthUser, IdentityResult)> CreateUserAsync(RegisterFormModel rfm, bool makeAdmin, bool emailConfirmed, bool sendEmail)
    {
        var activationKey = Guid.NewGuid().ToString();
        var user = new BlazorAuthUser();
        user.Id = Guid.NewGuid();
        user.Email = rfm.Email;
        user.LockoutEnabled = true;
        user.EmailConfirmed = emailConfirmed;
        user.CreatedAt = DateTime.Now;
        user.FirstName = rfm.FirstName;
        user.LastName = rfm.LastName;
        user.Is18OrAbove = rfm.Above18;
        user.TwoFactorEnabled = false;
        user.UserName = rfm.Username;
        user.ConcurrencyStamp = Guid.NewGuid().ToString();
        user.SecurityStamp = Guid.NewGuid().ToString();
        user.ActivationKey = activationKey;
        var res = await _userManager.CreateAsync(user, rfm.Password);
        if (!res.Succeeded) throw new Exception("Error in creating user.");
        // Check it's persisted
        var lookup = await _userManager.FindByIdAsync(user.Id.ToString());
        await _userManager.AddToRoleAsync(user, "User");

        // Admin rights:
        if (makeAdmin) await _userManager.AddToRoleAsync(user, "Admin");
        
        var emailResp = await _emailService.SendActivationEmail(user.Email, $"{user.FirstName} {user.LastName}",
            _navigationManager.BaseUri, activationKey);

        if (!emailResp.IsSuccessStatusCode)
        {
            throw new ApplicationException($"Error sending email to user {user.Email}. Error: {emailResp}");
        }
        
        return (user, res);


    }
    
    public BlazorAuthUser FindByActivationId(string activationId)
    {
        var u = _identityContext.Users.First(u => u.ActivationKey == activationId);
        return u;
    }

    public BlazorAuthUser GetById(Guid key)
    {
        return _identityContext.Users.First(usr => usr.Id == key);
    }
    
    public BlazorAuthUser GetByEmail(string email)
    {
        return _identityContext.Users.First(usr => usr.Email == email && usr.EmailConfirmed);
    }

    public void ActivateUser(BlazorAuthUser u)
    {
        var user = GetById(u.Id);
        user.UpdatedAt = DateTime.Now;
        user.EmailConfirmed = true;
        user.LockoutEnabled = false;
        _identityContext.Update(user);
        _identityContext.SaveChanges();
    }

    public BlazorAuthUser? FindByResetId(string resetKey)
    {
        if (string.IsNullOrWhiteSpace(resetKey))
            throw new ArgumentException("ResetKey is null");
        var user = _identityContext.Users.First(u => u.ResetKey == resetKey);
        return user;
    }

    public string SetPasswordResetKey(BlazorAuthUser u)
    {
        var user = GetById(u.Id);
        user.ResetKey = Guid.NewGuid().ToString();
        _identityContext.Update(user);
        _identityContext.SaveChanges();
        return user.ResetKey;
    }

    public async Task<IdentityResult> ResetPassword(Guid userId, string newPassword)
    {
        var u1 = GetById(userId);
        var token = await  _userManager.GeneratePasswordResetTokenAsync(u1);
        var passwdres = await _userManager.ResetPasswordAsync(u1, token, newPassword);
        return passwdres;
    }
}