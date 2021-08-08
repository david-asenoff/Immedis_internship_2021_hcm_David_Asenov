namespace HCM.Web.ViewModels.ProjectStatus
{
    using System.ComponentModel.DataAnnotations;
    public class ProjectStatusEditViewModel : ProjectStatusBaseViewModel
    {
        [Required]
        public string Id { get; set; }
    }
}
