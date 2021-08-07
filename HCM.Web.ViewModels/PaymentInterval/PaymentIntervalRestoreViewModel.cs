using System;
using System.ComponentModel.DataAnnotations;

namespace HCM.Web.ViewModels.PaymentInterval
{
    public class PaymentIntervalRestoreViewModel : PaymentIntervalViewBaseModel
    {
        public DateTime? DeletedOn { get; set; }

        [Required]
        public int Id { get; set; }
    }
}
