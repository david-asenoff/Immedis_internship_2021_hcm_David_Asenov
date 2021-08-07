namespace HCM.Web.ViewModels.Company
{
    using HCM.Data.Common;
    using System.ComponentModel.DataAnnotations;

    public abstract class CompanyBaseViewModel
    {
        [Required(ErrorMessage = GlobalConstants.CompanyNameIsRequired)]
        [StringLength(GlobalConstants.CompanyNameMaxLength, MinimumLength = GlobalConstants.CompanyNameMinLength, ErrorMessage = GlobalConstants.CompanyNameIsInvalid)]
        public string Name { get; set; }

        [Display(Name = GlobalConstants.EmailDisplay)]
        [Required(ErrorMessage = GlobalConstants.EmailIsRequired)]
        [EmailAddress(ErrorMessage = GlobalConstants.EmailIsInvalid)]
        public string Email { get; set; }

        [Display(Name = GlobalConstants.PhoneNumberDisplay)]
        [Required(ErrorMessage = GlobalConstants.PhoneNumberIsRequired)]
        [Phone(ErrorMessage = GlobalConstants.PhoneNumberIsInvalid)]
        public string PhoneNumber { get; set; }

        [Required(ErrorMessage = GlobalConstants.LogoIsRequired)]
        public string Logo { get; set; }

        [Display(Name = GlobalConstants.AboutUsDisplay)]
        [Required(ErrorMessage = GlobalConstants.AboutUsIsRequired)]
        public string AboutUs { get; set; }

        public string Id { get; set; }

        public string ShortAboutUs => this.AboutUs.Length > 50 ?
                                      this.AboutUs.Substring(0, 50) + "..." : 
                                      this.AboutUs;
    }
}
