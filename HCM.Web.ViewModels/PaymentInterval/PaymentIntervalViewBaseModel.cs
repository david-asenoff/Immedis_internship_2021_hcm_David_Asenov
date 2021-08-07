using HCM.Data.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace HCM.Web.ViewModels.PaymentInterval
{
    public class PaymentIntervalViewBaseModel
    {
        [Required(ErrorMessage = GlobalConstants.PaymentIntervalTypeIsRequired)]
        public string Type { get; set; }
    }
}
