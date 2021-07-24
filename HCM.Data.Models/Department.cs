namespace HCM.Data.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using HCM.Common;
    using HCM.Data.Common;

    /// <summary>
    /// Department is specialized division in a company.
    /// </summary>
    public class Department : BaseDeletableModel<string>
    {
        public Department()
        {
            this.Id = Guid.NewGuid().ToString();
            this.DepartmentAddresses = new HashSet<DepartmentAddress>();
        }

        /// <summary>
        /// Gets or sets name of the department. It may include Marketing, Finance, Operations management, Human Resource, IT or other.
        /// </summary>
        [Display(Name = GlobalConstants.DepartmentNameDisplay)]
        [Required(ErrorMessage = GlobalConstants.DepartmentNameIsRequired)]
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the company id for the department.
        /// </summary>
        [ForeignKey(nameof(Company))]
        [Required(ErrorMessage = GlobalConstants.CompanyIsRequired)]
        public string CompanyId { get; set; }

        public virtual Company Company { get; set; }

        /// <summary>
        /// Gets or sets department manager's id. Department managers oversee the functioning and productivity of a company division.
        /// </summary>
        [ForeignKey(nameof(User))]
        public string DepartmentManagerId { get; set; }

        public virtual User DepartmentManager { get; set; }

        /// <summary>
        /// Gets or sets department deputy manager's id.
        /// </summary>
        [ForeignKey(nameof(User))]
        public string DepartmentDeputyManagerId { get; set; }

        public virtual User DepartmentDeputyManager { get; set; }

        public virtual ICollection<DepartmentAddress> DepartmentAddresses { get; set; }
    }
}