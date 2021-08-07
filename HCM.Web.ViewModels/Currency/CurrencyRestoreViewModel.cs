namespace HCM.Web.ViewModels.Currency
{
    using System;
    using System.ComponentModel.DataAnnotations;

    public class CurrencyRestoreViewModel : CurrencyBaseViewModel
    {
        public DateTime? DeletedOn { get; set; }

        [Required]
        public int Id { get; set; }
    }
}