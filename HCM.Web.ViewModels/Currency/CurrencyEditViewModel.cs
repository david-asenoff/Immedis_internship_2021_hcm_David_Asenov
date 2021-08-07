using System.ComponentModel.DataAnnotations;

namespace HCM.Web.ViewModels.Currency
{
    public class CurrencyEditViewModel : CurrencyBaseViewModel
    {
        [Required]
        public int Id { get; set; }
    }
}
