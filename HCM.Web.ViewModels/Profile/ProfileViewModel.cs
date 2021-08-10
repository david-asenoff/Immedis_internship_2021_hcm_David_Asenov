using HCM.Data.Common;
using System.ComponentModel.DataAnnotations;

namespace HCM.Web.ViewModels.Profile
{
    public class ProfileViewModel : ProfileViewBaseModel
    {
        [Required(ErrorMessage = GlobalConstants.PasswordIsRequired)]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Display(Name = "Confirm password")]
        [Required(ErrorMessage = "Confirm your password")]
        [DataType(DataType.Password)]
        [Compare("Password", ErrorMessage = "Passwords don't match")]
        public string ConfirmPassword { get; set; }
    }
}
