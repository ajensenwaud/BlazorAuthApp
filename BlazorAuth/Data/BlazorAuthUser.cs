using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Identity;

namespace BlazorAuth.Data;

public class BlazorAuthUser : IdentityUser<Guid>
{
    [Required] public string FirstName { get; set; } = string.Empty;

    [Required] public string LastName { get; set; } = string.Empty;

    [Required] public DateTime CreatedAt { get; set; }

    [Required] public DateTime UpdatedAt { get; set; }

    [Required] public bool Is18OrAbove { get; set; } = false;

    [Required] public string ActivationKey { get; set; } = string.Empty;

    [Required] public string ResetKey { get; set; } = string.Empty;
    
    
}