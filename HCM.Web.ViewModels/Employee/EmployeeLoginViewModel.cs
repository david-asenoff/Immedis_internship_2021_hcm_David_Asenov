using HCM.Data.Common;
using System.ComponentModel.DataAnnotations;

namespace HCM.Web.ViewModels.Employee
{
    public class EmployeeLoginViewModel
    {
        [Required(ErrorMessage = GlobalConstants.PasswordIsRequired)]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Required(ErrorMessage = GlobalConstants.UsernameIsRequired)]
        [StringLength(GlobalConstants.UsernameMaxLength, MinimumLength = GlobalConstants.UsernameMinLength, ErrorMessage = GlobalConstants.UsernameIsInvalid)]
        public string Username { get; set; }
    }
}
