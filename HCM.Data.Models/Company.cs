namespace HCM.Data.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using HCM.Common;
    using HCM.Data.Common;

    public class Company : BaseDeletableModel<string>
    {
        public Company()
        {
            this.Departments = new HashSet<Department>();
            this.CompanyAddresses = new HashSet<CompanyAddress>();
            this.OrderedProjects = new HashSet<Project>();
        }

        [Required(ErrorMessage = GlobalConstants.CompanyNameIsRequired)]
        [StringLength(GlobalConstants.CompanyNameMaxLength, MinimumLength = GlobalConstants.CompanyNameMinLength, ErrorMessage = GlobalConstants.CompanyNameIsInvalid)]
        public string Name { get; set; }

        [Display(Name = GlobalConstants.EmailDisplay)]
        [Required(ErrorMessage = GlobalConstants.EmailIsRequired)]
        [EmailAddress(ErrorMessage = GlobalConstants.EmailIsInvalid)]
        public string Email { get; set; }

        [Display(Name = GlobalConstants.PhoneNumberDisplay)]
        [Required(ErrorMessage = "Phone number is required")]
        [Phone(ErrorMessage = "Phone number is not valid")]
        public string PhoneNumber { get; set; }

        [Required(ErrorMessage = GlobalConstants.LogoIsRequired)]
        public string Logo { get; set; }

        [Required(ErrorMessage = GlobalConstants.AboutUsIsRequired)]
        public string AboutUs { get; set; }

        public virtual ICollection<Project> OrderedProjects { get; set; }

        public virtual ICollection<Department> Departments { get; set; }

        public virtual ICollection<CompanyAddress> CompanyAddresses { get; set; }
    }
}
