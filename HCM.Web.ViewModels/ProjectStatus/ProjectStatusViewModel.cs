using System;
using System.ComponentModel.DataAnnotations;

namespace HCM.Web.ViewModels.ProjectStatus
{
    public class ProjectStatusViewModel : ProjectStatusBaseViewModel
    {
        public DateTime CreatedOn { get; set; }

        public DateTime? ModifiedOn { get; set; }

        public DateTime? DeletedOn { get; set; }

        public bool IsDeleted { get; set; }

        [Required]
        public string Id { get; set; }
    }
}
