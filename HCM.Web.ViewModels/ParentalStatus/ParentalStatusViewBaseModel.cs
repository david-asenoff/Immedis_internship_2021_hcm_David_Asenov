using HCM.Data.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace HCM.Web.ViewModels.ParentalStatus
{
    public class ParentalStatusViewBaseModel
    {
        [Required(ErrorMessage = GlobalConstants.ParentalStatusTypeIsRequired)]
        public string Type { get; set; }
    }
}
