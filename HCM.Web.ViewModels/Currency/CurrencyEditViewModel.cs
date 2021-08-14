using System.ComponentModel.DataAnnotations;

namespace HCM.Web.ViewModels.Currency
{
    public class CurrencyEditViewModel : EmployeeTrainingsBaseViewModel
    {
        [Required]
        public int Id { get; set; }
    }
}
