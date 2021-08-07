using System.ComponentModel.DataAnnotations;

namespace HCM.Web.ViewModels.PaymentInterval
{
    public class PaymentIntervalEditViewModel : PaymentIntervalViewBaseModel
    {
        [Required]
        public int Id { get; set; }
    }
}
