
namespace HCM.Data.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using HCM.Common;
    using HCM.Data.Common;

    public class User : BaseDeletableModel<string>
    {
        public User()
        {
            this.Contracts = new HashSet<Contract>();
        }

        [Display(Name = GlobalConstants.EmailDisplay)]
        [Required(ErrorMessage = GlobalConstants.EmailIsRequired)]
        [EmailAddress(ErrorMessage = GlobalConstants.EmailIsInvalid)]
        public string Email { get; set; }

        [Required(ErrorMessage = GlobalConstants.UsernameIsRequired)]
        [StringLength(GlobalConstants.UsernameMaxLength, MinimumLength = GlobalConstants.UsernameMinLength, ErrorMessage = GlobalConstants.UsernameIsInvalid)]
        public string Username { get; set; }

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
        public Gender Gender { get; set; }

        [Display(Name = GlobalConstants.MaritalStatusDisplay)]
        [Required(ErrorMessage = GlobalConstants.MaritalStatusIsRequired)]
        public MaritalStatus MaritalStatus { get; set; }

        [Display(Name = GlobalConstants.ParentalStatusDisplay)]
        [Required(ErrorMessage = GlobalConstants.ParentalStatusIsRequired)]
        public ParentalStatus ParentalStatus { get; set; }

        [Display(Name = GlobalConstants.DateOfBirthDisplay)]
        [Required(ErrorMessage = GlobalConstants.DateOfBirthIsRequired)]
        [DateOfBirth]
        public DateTime DateOfBirth { get; set; }

        [Display(Name = GlobalConstants.PhoneNumberDisplay)]
        [Required(ErrorMessage = "Phone number is required")]
        [Phone(ErrorMessage = "Phone number is not valid")]
        public string PhoneNumber { get; set; }

        [Required(ErrorMessage = GlobalConstants.AddressIsRequired)]
        public Address Address { get; set; }

        [Required(ErrorMessage = GlobalConstants.PortraitIsRequired)]
        public string Portrait { get; set; }

        [Required(ErrorMessage = GlobalConstants.CVIsRequired)]
        public string CV { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether a user is banned or not. A banned user won't be allowed to login.
        /// </summary>
        public bool IsBanned { get; set; }

        /// <summary>
        /// Gets or sets the password of the user.
        /// </summary>
        [Required(ErrorMessage = GlobalConstants.PasswordIsRequired)]
        [StringLength(GlobalConstants.PasswordMaxLength, MinimumLength = GlobalConstants.PasswordMinLength, ErrorMessage = GlobalConstants.PasswordIsInvalid)]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        public virtual ICollection<Contract> Contracts { get; set; }
    }
}
