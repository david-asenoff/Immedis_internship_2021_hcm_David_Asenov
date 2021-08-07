using System.ComponentModel.DataAnnotations;

namespace HCM.Web.ViewModels.Currency
{
    public class CurrencyDeleteViewModel : CurrencyBaseViewModel
    {
        [Required]
        public int Id { get; set; }
    }
}