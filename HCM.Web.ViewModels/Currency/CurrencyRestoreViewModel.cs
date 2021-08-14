using System;
using System.ComponentModel.DataAnnotations;

namespace HCM.Web.ViewModels.Currency
{
    public class CurrencyRestoreViewModel : EmployeeTrainingsBaseViewModel
    {
        public DateTime? DeletedOn { get; set; }

        [Required]
        public int Id { get; set; }
    }
}