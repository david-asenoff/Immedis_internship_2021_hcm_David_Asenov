using HCM.Web.ViewModels.PaymentInterval;
using System;
using System.ComponentModel.DataAnnotations;

namespace HCM.Web.ViewModels.ParentalStatus
{
    public class ParentalStatusRestoreViewModel : PaymentIntervalViewBaseModel
    {
        public DateTime? DeletedOn { get; set; }

        [Required]
        public int Id { get; set; }
    }
}
