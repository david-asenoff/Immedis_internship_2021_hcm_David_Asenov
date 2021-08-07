namespace HCM.Web.ViewModels.Position
{
    using HCM.Data.Common;
    using System.ComponentModel.DataAnnotations;

    public class PositionViewBaseModel
    {
        [Required(ErrorMessage = GlobalConstants.PossitionNameIsRequired)]
        public string Name { get; set; }


        public string Id { get; set; }
    }
}
