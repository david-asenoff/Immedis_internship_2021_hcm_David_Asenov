using System;
using System.ComponentModel.DataAnnotations;

namespace HCM.Web.ViewModels.ProjectStatus
{
    public class ProjectStatusRestoreViewModel : ProjectStatusBaseViewModel
    {
        public DateTime? DeletedOn { get; set; }

        [Required]
        public string Id { get; set; }
    }
}