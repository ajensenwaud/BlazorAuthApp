using System.ComponentModel.DataAnnotations;

namespace TxB.Models;

public class PasswordResetRequestModel
{
    [Required(ErrorMessage = "You must provide an email address")]
    [MinLength(3)]
    [EmailAddress(ErrorMessage = "Invalid email address")]
    [Display(Name = "Email address")]
    public string Email { get; set; }
    
}