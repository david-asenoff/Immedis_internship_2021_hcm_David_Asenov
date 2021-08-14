using System.ComponentModel.DataAnnotations;

namespace HCM.Web.ViewModels.Currency
{
    public class CurrencyDeleteViewModel : EmployeeTrainingsBaseViewModel
    {
        [Required]
        public int Id { get; set; }
    }
}