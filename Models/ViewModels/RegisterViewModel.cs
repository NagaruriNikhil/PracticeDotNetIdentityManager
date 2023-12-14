using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace IdentityManager.Models.ViewModels
{
	public class RegisterViewModel
	{
        [Required]
        public string Name { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }
        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        [StringLength(100,ErrorMessage ="The {0} must be atleast {2} characters long.", MinimumLength = 6)]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Required]
        [DisplayName("Confirm Password")]
        [Compare("Password", ErrorMessage ="The Password and Confirm password doesn't match ")]
        public string ConfirmPassword { get; set; }



    }
}
