namespace HCM.Data.Models
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using HCM.Data.Common;

    /// <summary>
    /// Salary is a fixed amount of money or compensation paid to an employee by an employer in return for work performed.
    /// </summary>
    public class Salary : BaseDeletableModel<string>
    {
        public Salary()
        {
            this.Id = Guid.NewGuid().ToString();
        }

        /// <summary>
        /// Gets or sets the payment interval of the salary.
        /// </summary>
        [Display(Name = GlobalConstants.PaymentIntervalDisplay)]
        [Required(ErrorMessage = GlobalConstants.PaymentIntervalIsRequired)]
        [ForeignKey(nameof(PaymentInterval))]
        public int PaymentIntervalId { get; set; }

        public virtual PaymentInterval PaymentInterval { get; set; }

        [Required(ErrorMessage = GlobalConstants.GrossSalaryIsRequired)]
        public decimal GrossSalary { get; set; }

        [Required(ErrorMessage = GlobalConstants.NetSalaryIsRequired)]
        public decimal NetSalary { get; set; }

        [ForeignKey(nameof(Currency))]
        [Required(ErrorMessage = GlobalConstants.CurrencyIsRequired)]
        public int CurrencyId { get; set; }

        public Currency Currency { get; set; }
    }
}