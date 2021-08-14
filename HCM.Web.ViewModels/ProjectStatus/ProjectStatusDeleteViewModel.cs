using System.ComponentModel.DataAnnotations;

namespace HCM.Web.ViewModels.ProjectStatus
{
    public class ProjectStatusDeleteViewModel : ProjectStatusBaseViewModel
    {
        [Required]
        public string Id { get; set; }
    }
}