using System.ComponentModel.DataAnnotations;

namespace HCM.Web.ViewModels.ProjectStatusCategory
{
    public class ProjectStatusCategoryAddViewModel : ProjectStatusCategoryViewBaseModel
    {
        [Required]
        public int Id { get; set; }
    }
}
