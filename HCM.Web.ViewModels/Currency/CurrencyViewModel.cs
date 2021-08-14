namespace HCM.Web.ViewModels.Currency
{
using System;
using System.ComponentModel.DataAnnotations;

    public class CurrencyViewModel : EmployeeTrainingsBaseViewModel
    {
        public DateTime CreatedOn { get; set; }

        public DateTime? ModifiedOn { get; set; }

        public DateTime? DeletedOn { get; set; }

        public bool IsDeleted { get; set; }

        [Required]
        public int Id { get; set; }
    }
}
