using HCM.Data.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using Xunit;

namespace HCM.Web.ViewModels.MaritalStatus
{
    public class MaritalStatusViewBaseModel
    {
        [Required(ErrorMessage = GlobalConstants.MaritalStatusTypeIsRequired)]
        public string Type { get; set; }
    }
}
