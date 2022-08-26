using System.ComponentModel.DataAnnotations;

namespace TxB.Models
{
    public class ChangePasswordFormModel
    {
        [RegularExpression(@"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[#$^+=!*()@%&]).{8,}$",
        ErrorMessage =
            "Password must be at least 8 characters long and have (at least) one digit, one upper case character, one upper case character, and an non-alphanumeric character.")]
        [Required(ErrorMessage = "You must provide a password.")]
        [StringLength(255, ErrorMessage = "Password must be at least {2} and at max {1} characters long.",
        MinimumLength = 8)]
        [DataType(DataType.Password)]
        [Display(Name = "Current Password")]
        public string CurrentPassword { get; set; } = string.Empty;

        [RegularExpression(@"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[#$^+=!*()@%&]).{8,}$",
        ErrorMessage =
            "Password must be at least 8 characters long and have (at least) one digit, one upper case character, one upper case character, and an non-alphanumeric character.")]
        [Required(ErrorMessage = "You must provide a password.")]
        [StringLength(255, ErrorMessage = "Password must be at least {2} and at max {1} characters long.",
        MinimumLength = 8)]
        [DataType(DataType.Password)]
        [Display(Name = "New Password")]
        public string NewPassword { get; set; } = string.Empty;
    }

}
