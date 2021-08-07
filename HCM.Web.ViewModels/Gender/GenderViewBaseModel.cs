namespace HCM.Web.ViewModels.Gender
{
    using HCM.Data.Common;
    using System.ComponentModel.DataAnnotations;

    public abstract class GenderViewBaseModel
    {
        [Required(ErrorMessage = GlobalConstants.GenderTypeIsRequired)]
        public string Type { get; set; }
    }
}