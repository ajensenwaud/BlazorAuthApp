using TxB.Data;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Identity;

namespace TxB.Shared.Components;

public class BlazorAuthComponentBase : ComponentBase
{
    [Inject]
    private AuthenticationStateProvider AuthenticationStateProvider { get; set; }

    [Inject]
    protected SessionState SessionState { get; set; }
    
    [Inject]
    private ILogger<BlazorAuthComponentBase> Logger { get; set; }

    [Inject]
    private SignInManager<ApplicationUser> SignInManager { get; set; }

    [Inject]
    private UserManager<ApplicationUser> UserManager { get; set; }

    protected async Task<ApplicationUser> GetCurrentUser()
    {
        var authState = await AuthenticationStateProvider.GetAuthenticationStateAsync();
        var identity = authState.User.Identity;
        var user = await UserManager.GetUserAsync(authState.User);
        return user;
    }

    protected override async void OnInitialized()
    {
        base.OnInitialized();
        
        var authState = await AuthenticationStateProvider.GetAuthenticationStateAsync();
        
        // Sometimes if you stop and restart development server, the authentication state is lost, but 
        // cookie with correct credentials still exists. If that is the case, repopulate SessionState 
        // so application doesn't crash with null pointers
        if (authState.User.Identity is not null && authState.User.Identity.Name is not null && SessionState.CurrentUser is null)
        {
            Logger.LogError("User is authenticated but SessionState is empty. Needs to be fixed.");
            var identity = authState.User.Identity;
            var user = await UserManager.GetUserAsync(authState.User);
            Logger.LogInformation($"User is ${identity}");
            // var user = await UserManager.
            Logger.LogInformation($"User email is ${user.Email}");

            // Repopulate session state object
            SessionState.CurrentUser = user;
            SessionState.CurrentRoles = await UserManager.GetRolesAsync(user);
            SessionState.ClaimsPrincipal = authState.User;
        }
    }
}