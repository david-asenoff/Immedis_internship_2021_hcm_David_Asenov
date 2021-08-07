using HCM.Data.Common;
using System.ComponentModel.DataAnnotations;

namespace HCM.Web.ViewModels.PaymentInterval
{
    public class PaymentIntervalViewBaseModel
    {
        [Required(ErrorMessage = GlobalConstants.PaymentIntervalTypeIsRequired)]
        public string Type { get; set; }
    }
}
