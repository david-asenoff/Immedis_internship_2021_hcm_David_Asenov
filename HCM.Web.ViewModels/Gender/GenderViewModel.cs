using HCM.Common;
using System.ComponentModel.DataAnnotations;

namespace HCM.Web.ViewModels.Gender
{
    public class GenderViewModel
    {
        [Required(ErrorMessage = GlobalConstants.GenderTypeIsRequired)]
        public string Type { get; set; }

        public string Id { get; set; }
    }
}