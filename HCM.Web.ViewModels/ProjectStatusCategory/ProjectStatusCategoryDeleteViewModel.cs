using System.ComponentModel.DataAnnotations;

namespace HCM.Web.ViewModels.ProjectStatusCategory
{
    public class ProjectStatusCategoryDeleteViewModel : ProjectStatusCategoryViewBaseModel
    {
        [Required]
        public int Id { get; set; }
    }
}
