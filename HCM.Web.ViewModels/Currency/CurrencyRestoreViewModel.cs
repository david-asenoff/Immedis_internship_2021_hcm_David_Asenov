namespace HCM.Web.ViewModels.Currency
{
using System;
using System.ComponentModel.DataAnnotations;

    public class CurrencyRestoreViewModel : EmployeeTrainingsBaseViewModel
    {
        public DateTime? DeletedOn { get; set; }

        [Required]
        public int Id { get; set; }
    }
}