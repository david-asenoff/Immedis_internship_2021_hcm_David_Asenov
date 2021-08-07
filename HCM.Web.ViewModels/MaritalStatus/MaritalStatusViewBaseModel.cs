using HCM.Data.Common;
using System.ComponentModel.DataAnnotations;

namespace HCM.Web.ViewModels.MaritalStatus
{
    public class MaritalStatusViewBaseModel
    {
        [Required(ErrorMessage = GlobalConstants.MaritalStatusTypeIsRequired)]
        public string Type { get; set; }
    }
}
