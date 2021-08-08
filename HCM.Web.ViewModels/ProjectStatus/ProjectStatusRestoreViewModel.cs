namespace HCM.Web.ViewModels.ProjectStatus
{
    using System;
    using System.ComponentModel.DataAnnotations;
    public class ProjectStatusRestoreViewModel : ProjectStatusBaseViewModel
    {
        public DateTime? DeletedOn { get; set; }

        [Required]
        public string Id { get; set; }
    }
}