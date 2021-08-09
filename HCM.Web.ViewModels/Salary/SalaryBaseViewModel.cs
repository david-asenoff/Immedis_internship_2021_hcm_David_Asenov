﻿namespace HCM.Web.ViewModels.Salary
{
    using HCM.Data.Common;
    using HCM.Web.ViewModels.Currency;
    using HCM.Web.ViewModels.PaymentInterval;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public abstract class SalaryBaseViewModel
    {
        /// <summary>
        /// Gets or sets the payment interval of the salary.
        /// </summary>
        [Display(Name = GlobalConstants.PaymentIntervalDisplay)]
        [Required(ErrorMessage = GlobalConstants.PaymentIntervalIsRequired)]
        public int PaymentIntervalId { get; set; }

        public string PaymentIntervalType { get; set; }

        public IEnumerable<PaymentIntervalDropDownViewModel> PaymentIntervals { get; set; }

        [Required(ErrorMessage = GlobalConstants.CurrencyIsRequired)]
        public int CurrencyId { get; set; }

        public string CurrencyDescription { get; set; }

        public IEnumerable<CurrencyDropDownViewModel> Currencies { get; set; }

        [Required(ErrorMessage = GlobalConstants.GrossSalaryIsRequired)]
        public decimal GrossSalary { get; set; }

        [Required(ErrorMessage = GlobalConstants.NetSalaryIsRequired)]
        public decimal NetSalary { get; set; }
    }
}