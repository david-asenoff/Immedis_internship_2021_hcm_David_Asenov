namespace HCM.Data.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using HCM.Data.Common;

    /// <summary>
    /// Currency is a generally accepted form of payment for the employees hours worked.
    /// </summary>
    public class Currency : BaseDeletableModel<int>
    {

        public Currency()
        {
            this.Salaries = new HashSet<Salary>();
        }

        /// <summary>
        /// Gets or sets currency description.
        /// </summary>
        [Required]
        public string Description { get; set; }

        /// <summary>
        /// Gets or sets currency abbreviation.
        /// </summary>
        [Required]
        public string Abbreviation { get; set; }

        public virtual ICollection<Salary> Salaries { get; set; }
    }
}