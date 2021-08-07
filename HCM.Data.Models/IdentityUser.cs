namespace HCM.Data
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using HCM.Data.Common;

    public class IdentityUser<T> : BaseDeletableModel<T>
    {
        /// <summary>
        /// Gets or sets the username of an identity user.
        /// </summary>
        [Required(ErrorMessage = GlobalConstants.UsernameIsRequired)]
        [StringLength(GlobalConstants.UsernameMaxLength, MinimumLength = GlobalConstants.UsernameMinLength, ErrorMessage = GlobalConstants.UsernameIsInvalid)]
        public string Username { get; set; }

        /// <summary>
        /// Gets or sets the email of an identity user.
        /// </summary>
        [Display(Name = GlobalConstants.EmailDisplay)]
        [Required(ErrorMessage = GlobalConstants.EmailIsRequired)]
        [EmailAddress(ErrorMessage = GlobalConstants.EmailIsInvalid)]
        public string Email { get; set; }

        /// <summary>
        /// Gets or sets the password of the user.
        /// </summary>
        [Required(ErrorMessage = GlobalConstants.PasswordIsRequired)]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        /// <summary>
        /// Gets or sets the phone number of an identity user.
        /// </summary>
        [Display(Name = GlobalConstants.PhoneNumberDisplay)]
        [Required(ErrorMessage = "Phone number is required")]
        [Phone(ErrorMessage = "Phone number is not valid")]
        public string PhoneNumber { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether a user is banned or not. A banned user won't be allowed to login.
        /// </summary>
        public bool IsBanned { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether a user confirmed his e-mail. User with not confirmed e-mail won't be allowed to login.
        /// </summary>
        public bool IsEmailConfirmed { get; set; }

        /// <summary>
        /// Gets or sets whether an identity user should be remembered.
        /// </summary>
        [Display(Name = GlobalConstants.RememberMeDisplay)]
        public bool RememberMe { get; set; }

        /// <summary>
        /// Gets or sets the identity role id of the identity user.
        /// </summary>
        [ForeignKey(nameof(IdentityRole))]
        public int IdentityRoleId { get; set; }

        public virtual IdentityRole Role { get; set; }
    }
}
