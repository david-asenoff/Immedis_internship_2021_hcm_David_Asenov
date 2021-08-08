namespace HCM.Web.ViewModels.ProjectStatus
{
    using System.ComponentModel.DataAnnotations;

    public class ProjectStatusDeleteViewModel : ProjectStatusBaseViewModel
    {
        [Required]
        public string Id { get; set; }
    }
}