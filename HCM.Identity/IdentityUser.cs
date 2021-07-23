namespace HCM.Identity
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Text;
    using HCM.Common;
    using HCM.Data.Common;

    public class IdentityUser<T> : BaseDeletableModel<T>
    {
        [Required(ErrorMessage = GlobalConstants.UsernameIsRequired)]
        [StringLength(GlobalConstants.UsernameMaxLength, MinimumLength = GlobalConstants.UsernameMinLength, ErrorMessage = GlobalConstants.UsernameIsInvalid)]
        public string Username { get; set; }

        [Display(Name = GlobalConstants.EmailDisplay)]
        [Required(ErrorMessage = GlobalConstants.EmailIsRequired)]
        [EmailAddress(ErrorMessage = GlobalConstants.EmailIsInvalid)]
        public string Email { get; set; }

        /// <summary>
        /// Gets or sets the password of the user.
        /// </summary>
        [Required(ErrorMessage = GlobalConstants.PasswordIsRequired)]
        [StringLength(GlobalConstants.PasswordMaxLength, MinimumLength = GlobalConstants.PasswordMinLength, ErrorMessage = GlobalConstants.PasswordIsInvalid)]
        [DataType(DataType.Password)]
        public string Password { get; set; }

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

        [Display(Name = GlobalConstants.RememberMeDisplay)]
        public bool RememberMe { get; set; }

        public IdentityRole Role { get; set; }
    }
}
