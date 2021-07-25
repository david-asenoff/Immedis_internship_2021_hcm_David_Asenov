using HCM.Common;
using HCM.Data.Common;
using HCM.Web.ViewModels.Gender;
using System;
using System.ComponentModel.DataAnnotations;

namespace HCM.Web.ViewModels.Employee
{
    public class EmployeeRegistrationViewModel
    {
        [Display(Name = GlobalConstants.FirstNameDisplay)]
        [Required(ErrorMessage = GlobalConstants.FirstNameIsRequired)]
        [StringLength(GlobalConstants.NameMaxLength, MinimumLength = GlobalConstants.NameMinLength, ErrorMessage = GlobalConstants.FirstNameIsInvalid)]
        public string FirstName { get; set; }

        [Display(Name = GlobalConstants.MiddleNameDisplay)]
        [StringLength(GlobalConstants.NameMaxLength, MinimumLength = GlobalConstants.NameMinLength, ErrorMessage = GlobalConstants.MiddleNameIsInvalid)]
        public string MiddleName { get; set; }

        [Display(Name = GlobalConstants.LastNameDisplay)]
        [Required(ErrorMessage = GlobalConstants.LastNameIsRequired)]
        [StringLength(GlobalConstants.NameMaxLength, MinimumLength = GlobalConstants.NameMinLength, ErrorMessage = GlobalConstants.LastNameIsInvalid)]
        public string LastName { get; set; }

        [Required(ErrorMessage = GlobalConstants.GenderIsRequired)]
        public GenderViewModel Gender { get; set; }

        [Display(Name = GlobalConstants.PhoneNumberDisplay)]
        [Required(ErrorMessage = "Phone number is required")]
        [Phone(ErrorMessage = "Phone number is not valid")]
        public string PhoneNumber { get; set; }

        [Display(Name = GlobalConstants.EmailDisplay)]
        [Required(ErrorMessage = GlobalConstants.EmailIsRequired)]
        [EmailAddress(ErrorMessage = GlobalConstants.EmailIsInvalid)]
        public string Email { get; set; }

        [Required(ErrorMessage = GlobalConstants.PasswordIsRequired)]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Display(Name = GlobalConstants.ConfirmPasswordDisplay)]
        [Required(ErrorMessage = GlobalConstants.ConfirmPasswordIsRequired)]
        [DataType(DataType.Password)]
        [Compare("Password", ErrorMessage = GlobalConstants.PasswordsDontMatch)]
        public string ConfirmPassword { get; set; }

        [Required(ErrorMessage = GlobalConstants.UsernameIsRequired)]
        [StringLength(GlobalConstants.UsernameMaxLength, MinimumLength = GlobalConstants.UsernameMinLength, ErrorMessage = GlobalConstants.UsernameIsInvalid)]
        public string Username { get; set; }

        [Display(Name = GlobalConstants.DateOfBirthDisplay)]
        [Required(ErrorMessage = GlobalConstants.DateOfBirthIsRequired)]
        [DateOfBirth]
        public DateTime DateOfBirth { get; set; }

        [Required(ErrorMessage = GlobalConstants.PortraitIsRequired)]
        public string Portrait { get; set; }

        [Required(ErrorMessage = GlobalConstants.CVIsRequired)]
        public string CV { get; set; }
    }
}
