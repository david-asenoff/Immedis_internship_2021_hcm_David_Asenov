using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace HCM.Web.ViewModels.PaymentInterval
{
    public class PaymentIntervalDeleteViewModel : PaymentIntervalViewBaseModel
    {
        [Required]
        public int Id { get; set; }
    }
}
