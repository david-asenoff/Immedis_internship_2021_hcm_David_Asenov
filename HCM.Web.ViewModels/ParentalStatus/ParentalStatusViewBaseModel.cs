using HCM.Data.Common;
using System.ComponentModel.DataAnnotations;

namespace HCM.Web.ViewModels.ParentalStatus
{
    public abstract class ParentalStatusViewBaseModel
    {
        [Required(ErrorMessage = GlobalConstants.ParentalStatusTypeIsRequired)]
        public string Type { get; set; }
    }
}
