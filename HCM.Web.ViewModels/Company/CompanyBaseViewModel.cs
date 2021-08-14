using HCM.Data.Common;
using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;

namespace HCM.Web.ViewModels.Company
{
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

        public IFormFile CompanyLogo { get; set; }

        public string CompanyLogoUrl { get; set; }

        [Display(Name = GlobalConstants.AboutUsDisplay)]
        [Required(ErrorMessage = GlobalConstants.AboutUsIsRequired)]
        public string AboutUs { get; set; }

        public string Id { get; set; }

        public string ShortAboutUs => this.AboutUs.Length > 50 ?
                                      this.AboutUs.Substring(0, 50) + "..." :
                                      this.AboutUs;
    }
}