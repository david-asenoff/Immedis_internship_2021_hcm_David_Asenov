namespace HCM.Web.ViewModels.ProjectStatusCategory
{
    using HCM.Data.Common;
    using System.ComponentModel.DataAnnotations;
    public class ProjectStatusCategoryViewBaseModel
    {
        [Required(ErrorMessage = GlobalConstants.ProjectStatusCategoryTypeIsRequired)]
        public string Type { get; set; }
    }
}
