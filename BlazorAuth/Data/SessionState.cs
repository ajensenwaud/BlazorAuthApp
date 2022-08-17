﻿using System.Security.Claims;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Authorization;

namespace BlazorAuth.Data;

public class SessionState
{
    [Inject]
    private AuthenticationStateProvider AuthenticationStateProvider { get; set; }

    public Guid SessionKey { get; set; } = Guid.Empty;

    public BlazorAuthUser? CurrentUser { get; set; }

    public IList<string> CurrentRoles { get; set; }

    public ClaimsPrincipal? ClaimsPrincipal { get; set; }

    public bool IsAuthenticated
    {
        get
        {
            return (ClaimsPrincipal != null && ClaimsPrincipal.Identity.IsAuthenticated);
        }
    }
    
}