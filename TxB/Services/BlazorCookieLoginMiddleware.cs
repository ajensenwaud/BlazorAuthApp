using System.Collections.Concurrent;
using TxB.Data;
using Microsoft.AspNetCore.Identity;

namespace TxB.Services;

public class LoginInfo
{
    public string Username { get; set; }
    public string Email { get; set; }

    public string Password { get; set; }

    public bool RememberMe { get; set; }
}

/// <summary>
/// Intercepts '/login' and cache login / password
/// in order to avoid "System.InvalidOperationException: Headers are read-only, response has already started."
/// being thrown after logging in.
/// Solution courtesy of https://github.com/dotnet/aspnetcore/issues/13601
/// </summary>
public class BlazorCookieLoginMiddleware
{
    private readonly RequestDelegate _next;

    public BlazorCookieLoginMiddleware(RequestDelegate next)
    {
        _next = next;
    }

    public static IDictionary<Guid, LoginInfo> Logins { get; }
        = new ConcurrentDictionary<Guid, LoginInfo>();

    public async Task Invoke(HttpContext context, SignInManager<ApplicationUser> signInMgr,
        UserManager<ApplicationUser> userManager, SessionState sessionState)
    {
        if (context.Request.Path == "/login" && context.Request.Query.ContainsKey("key"))
        {
            var key = Guid.Parse(context.Request.Query["key"]);
            var info = Logins[key];
            var result = await signInMgr.PasswordSignInAsync(info.Username, info.Password, info.RememberMe, false);

            info.Password = string.Empty;
            if (result.Succeeded)
            {
                Logins.Remove(key);
                context.Response.Redirect("/");
                // Store user information into session state object
                sessionState.CurrentUser = await userManager.FindByEmailAsync(info.Email);
                sessionState.ClaimsPrincipal = await signInMgr.CreateUserPrincipalAsync(sessionState.CurrentUser);
                sessionState.CurrentRoles = await userManager.GetRolesAsync(sessionState.CurrentUser);
                return;
            }

            if (result.RequiresTwoFactor)
            {
                context.Response.Redirect("/loginwith2fa/" + key);
                return;
            }

            context.Response.Redirect("/loginfailed");
            return;
        }

        if (context.Request.Path == "/logout")
        {
            await signInMgr.SignOutAsync();
            try
            {
                var key = sessionState.SessionKey;
                Logins.Remove(key);
            }
            catch (Exception ex)
            {
                Console.WriteLine("No guid found ...  exiting");
            }

            context.Response.Redirect("/");
        }
        else
        {
            await _next.Invoke(context);
        }
    }
}