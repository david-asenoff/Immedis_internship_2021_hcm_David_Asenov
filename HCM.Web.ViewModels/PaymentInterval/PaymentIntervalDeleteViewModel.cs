using System.ComponentModel.DataAnnotations;

namespace HCM.Web.ViewModels.PaymentInterval
{
    public class PaymentIntervalDeleteViewModel : PaymentIntervalViewBaseModel
    {
        [Required]
        public int Id { get; set; }
    }
}
