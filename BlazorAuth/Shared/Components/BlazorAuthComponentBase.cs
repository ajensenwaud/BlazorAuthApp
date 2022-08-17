using BlazorAuth.Data;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Identity;

namespace BlazorAuth.Shared.Components;

public class BlazorAuthComponentBase : ComponentBase
{
    [Inject]
    private AuthenticationStateProvider AuthenticationStateProvider { get; set; }

    [Inject]
    private SessionState SessionState { get; set; }
    
    [Inject]
    private ILogger<BlazorAuthComponentBase> Logger { get; set; }

    [Inject]
    private SignInManager<BlazorAuthUser> SignInManager { get; set; }

    [Inject]
    private UserManager<BlazorAuthUser> UserManager { get; set; }

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
            Logger.LogInformation($"User is ${identity.Name}");
            var user = await UserManager.FindByNameAsync(identity.Name);
            Logger.LogInformation($"User email is ${user.Email}");

            // Repopulate session state object
            SessionState.CurrentUser = user;
            SessionState.CurrentRoles = await UserManager.GetRolesAsync(user);
            SessionState.ClaimsPrincipal = authState.User;
        }
    }
}