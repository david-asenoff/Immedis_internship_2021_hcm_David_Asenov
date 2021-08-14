using HCM.Data.Common;
using System.ComponentModel.DataAnnotations;

namespace HCM.Web.ViewModels.ProjectStatusCategory
{
    public class ProjectStatusCategoryViewBaseModel
    {
        [Required(ErrorMessage = GlobalConstants.ProjectStatusCategoryTypeIsRequired)]
        public string Type { get; set; }
    }
}
