using System.ComponentModel.DataAnnotations;

namespace HCM.Web.ViewModels.ProjectStatus
{
    public class ProjectStatusEditViewModel : ProjectStatusBaseViewModel
    {
        [Required]
        public string Id { get; set; }
    }
}
