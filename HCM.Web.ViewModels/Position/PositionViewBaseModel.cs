using HCM.Data.Common;
using System.ComponentModel.DataAnnotations;

namespace HCM.Web.ViewModels.Position
{
    public class PositionViewBaseModel
    {
        [Required(ErrorMessage = GlobalConstants.PossitionNameIsRequired)]
        public string Name { get; set; }


        public string Id { get; set; }
    }
}
