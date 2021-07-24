namespace HCM.Data.Models
{
    using System.Collections.Generic;
    using HCM.Data.Common;

    /// <summary>
    /// Project status category may be "not started", "cancelled", "in progress", "on hold" and "completed".
    /// </summary>
    public class ProjectStatusCategory : BaseDeletableModel<int>
    {
        public ProjectStatusCategory()
        {
            this.ProjectStatuses = new HashSet<ProjectStatus>();
        }

        /// <summary>
        /// Gets or sets the type of the project status category.
        /// </summary>
        public string Type { get; set; }

        public virtual ICollection<ProjectStatus> ProjectStatuses { get; set; }
    }
}