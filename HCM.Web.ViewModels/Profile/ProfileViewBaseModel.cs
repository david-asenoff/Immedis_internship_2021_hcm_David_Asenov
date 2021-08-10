namespace HCM.Web.ViewModels.Profile
{
    using HCM.Data.Common;
    using HCM.Web.ViewModels.Gender;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public class ProfileViewBaseModel
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
        public string Gender { get; set; }

        [Display(Name = GlobalConstants.PhoneNumberDisplay)]
        [Required(ErrorMessage = "Phone number is required")]
        [Phone(ErrorMessage = "Phone number is not valid")]
        public string PhoneNumber { get; set; }

        [Display(Name = GlobalConstants.EmailDisplay)]
        [Required(ErrorMessage = GlobalConstants.EmailIsRequired)]
        [EmailAddress(ErrorMessage = GlobalConstants.EmailIsInvalid)]
        public string Email { get; set; }

        [NotMapped]
        public string Username { get; set; }

        [Display(Name = GlobalConstants.DateOfBirthDisplay)]
        [Required(ErrorMessage = GlobalConstants.DateOfBirthIsRequired)]
        [DateOfBirth]
        public DateTime DateOfBirth { get; set; }

        public IEnumerable<GenderDropDownViewModel> Genders { get; set; }
    }
}
