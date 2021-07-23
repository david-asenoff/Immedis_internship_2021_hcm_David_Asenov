namespace HCM.Data.Models
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using HCM.Common;
    using HCM.Data.Common;

    public class ProjectStatus : BaseDeletableModel<string>
    {
        public ProjectStatus()
        {
            this.Id = Guid.NewGuid().ToString();
        }

        [ForeignKey(nameof(ProjectStatusCategory))]
        public int ProjectStatusCategoryId { get; set; }

        public virtual ProjectStatusCategory ProjectStatusCategory { get; set; }

        /// <summary>
        /// Gets or sets the start date of the project status.
        /// </summary>
        [Display(Name = GlobalConstants.StartDateDisplay)]
        [Required(ErrorMessage = GlobalConstants.StartDateIsRequired)]
        public DateTime StartDate { get; set; }

        /// <summary>
        ///  Gets or sets the end date of the project status. The end date may be null.
        /// </summary>
        public DateTime? EndDate { get; set; }

        [ForeignKey(nameof(Project))]
        public string ProjectId { get; set; }

        public virtual Project Project { get; set; }
    }
}