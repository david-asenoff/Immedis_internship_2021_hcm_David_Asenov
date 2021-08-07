namespace HCM.Data.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using HCM.Data.Common;

    /// <summary>
    /// Payment interval of salary.
    /// </summary>
    public class PaymentInterval : BaseDeletableModel<int>
    {
        public PaymentInterval()
        {
            this.Salaries = new HashSet<Salary>();
        }

        /// <summary>
        /// Gets or sets type of payment interval. Salary is commonly paid in fixed intervals, for example, monthly payments of one-twelfth of the annual salary.
        /// </summary>
        [Required(ErrorMessage = GlobalConstants.PaymentIntervalTypeIsRequired)]
        public string Type { get; set; }

        public virtual ICollection<Salary> Salaries { get; set; }
    }
}