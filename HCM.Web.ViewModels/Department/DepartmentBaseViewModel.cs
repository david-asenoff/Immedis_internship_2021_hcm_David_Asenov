using HCM.Data.Common;
using HCM.Web.ViewModels.Company;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace HCM.Web.ViewModels.Department
{
    public abstract class DepartmentBaseViewModel
    {
        public string Id { get; set; }

        /// <summary>
        /// Gets or sets name of the department. It may include Marketing, Finance, Operations management, Human Resource, IT or other.
        /// </summary>
        [Display(Name = GlobalConstants.DepartmentNameDisplay)]
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the company id for the department.
        /// </summary>
        [Display(Name = "CompanyName")]
        public string CompanyId { get; set; }

        public string CompanyName { get; set; }

        public IEnumerable<CompanyDropDownViewModel> Companies { get; set; }
    }
}
