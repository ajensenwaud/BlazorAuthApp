using System.ComponentModel.DataAnnotations;

namespace TxB.Models;

public class UserEditFormModel
{
    [Required(ErrorMessage = "You must provide a user name")]
    [MinLength(3, ErrorMessage = "User name must have a minimum of 3 characters")]
    [RegularExpression(@"^\S*$", ErrorMessage = "No white space allowed in user name")]
    [Display(Name = "User name")]
    public string Username { get; set; } = string.Empty;

    [Display(Name = "First name")] public string FirstName { get; set; } = string.Empty;

    [Display(Name = "Last name")] public string LastName { get; set; } = string.Empty;

    [Required(ErrorMessage = "You must provide an email address to register.")]
    [MinLength(3)]
    [EmailAddress(ErrorMessage = "Invalid email address")]
    [Display(Name = "Email address")]
    public string Email { get; set; } = String.Empty;

    public string Password { get; set; } = String.Empty;

    [Required] public bool Above18 { get; set; }

    [Required] public bool LockoutEnabled { get; set; }

    [Required] public bool EmailConfirmed { get; set; }

}