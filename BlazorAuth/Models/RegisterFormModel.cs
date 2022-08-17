using System.ComponentModel.DataAnnotations;

namespace BlazorAuth.Data;

public class RegisterFormModel
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
    public string Email { get; set; } = string.Empty;

    [RegularExpression(@"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[#$^+=!*()@%&]).{8,}$",
        ErrorMessage =
            "Password must be at least 8 characters long and have (at least) one digit, one upper case character, one upper case character, and an non-alphanumeric character.")]
    [Required(ErrorMessage = "You must provide a password.")]
    [StringLength(255, ErrorMessage = "Password must be at least {2} and at max {1} characters long.",
        MinimumLength = 8)]
    [DataType(DataType.Password)]
    [Display(Name = "Password")]
    public string Password { get; set; } = String.Empty;

    [Required] public bool Above18 { get; set; }
}