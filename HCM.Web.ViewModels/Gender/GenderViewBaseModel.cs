using HCM.Data.Common;
using System.ComponentModel.DataAnnotations;

namespace HCM.Web.ViewModels.Gender
{
    public abstract class GenderViewBaseModel
    {
        [Required(ErrorMessage = GlobalConstants.GenderTypeIsRequired)]
        public string Type { get; set; }
    }
}