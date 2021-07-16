namespace HCM.Data.Models
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using HCM.Common;
    using HCM.Data.Common;

    /// <summary>
    /// Payment interval of salary.
    /// </summary>
    public class PaymentInterval : BaseDeletableModel<string>
    {
        public PaymentInterval()
        {
            this.Id = Guid.NewGuid().ToString();
        }

        /// <summary>
        /// Gets or sets type of payment interval. Salary is commonly paid in fixed intervals, for example, monthly payments of one-twelfth of the annual salary.
        /// </summary>
        [Required(ErrorMessage = GlobalConstants.PaymentIntervalTypeIsRequired)]
        public string Type { get; set; }
    }
}