namespace HCM.Data.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations.Schema;
    using HCM.Data.Common;

    /// <summary>
    /// A project is defined as a sequence of tasks that must be completed to attain a certain outcome. Depending on its complexity, it can be managed by a single person or hundreds.
    /// </summary>
    public class Project : BaseDeletableModel<string>
    {
        public Project()
        {
            this.Id = Guid.NewGuid().ToString();
            this.ProjectStatuses = new HashSet<ProjectStatus>();
        }

        /// <summary>
        /// Gets or sets the name of the project.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the description of the project. Describes the project's objectives and its essential qualities. The project description may include an overview of the following: Project goals and objectives.
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// Gets or sets the estimated work hours for the project. The amount of time that is calculated and planned to take to complete the project.
        /// </summary>
        public TimeSpan EstimatedWorkHours { get; set; }

        /// <summary>
        /// Gets or sets the final work hours for the project. The amount of time that actualy took to complete the project.
        /// </summary>
        public TimeSpan FinalWorkHours { get; set; }

        /// <summary>
        /// Gets or sets the estimated budget for the project. The amount of budget that is calculated and planned to spend to complete the project.
        /// </summary>
        public decimal EstimatedBudget { get; set; }

        /// <summary>
        /// The amount of budget that actualy took to complete the project.
        /// </summary>
        public decimal FinalBudget { get; set; }

        [ForeignKey(nameof(Company))]
        public string OrdererCompanyId { get; set; }

        public virtual Company OrdererCompany { get; set; }

        public virtual ICollection<ProjectStatus> ProjectStatuses { get; set; }

        public virtual ICollection<ProjectUser> ProjectUsers { get; set; }
    }
}