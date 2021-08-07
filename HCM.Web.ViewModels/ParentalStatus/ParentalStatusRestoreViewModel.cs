using HCM.Web.ViewModels.PaymentInterval;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace HCM.Web.ViewModels.ParentalStatus
{
    public class ParentalStatusRestoreViewModel: PaymentIntervalViewBaseModel
    {
        public DateTime? DeletedOn { get; set; }

        [Required]
        public int Id { get; set; }
    }
}
