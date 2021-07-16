namespace HCM.Data.Models
{
    using System;
    using System.ComponentModel.DataAnnotations;
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
        }

        /// <summary>
        /// Gets or sets name of the department. It may include Marketing, Finance, Operations management, Human Resource, IT or other.
        /// </summary>
        [Required(ErrorMessage = GlobalConstants.DepartmentNameIsRequired)]
        public string Name { get; set; }
    }
}