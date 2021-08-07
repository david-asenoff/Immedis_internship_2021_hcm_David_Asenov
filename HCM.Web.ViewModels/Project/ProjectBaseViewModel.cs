using HCM.Web.ViewModels.Company;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace HCM.Web.ViewModels.Project
{
    public abstract class ProjectBaseViewModel
    {
        public string Id { get; set; }

        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the description of the project. Describes the project's objectives and its essential qualities. The project description may include an overview of the following: Project goals and objectives.
        /// </summary>
        public string Description { get; set; }

        public string ShortDescription => this.Description.Length > 50 ?
                                     this.Description.Substring(0, 50) + "..." :
                                     this.Description;

        /// <summary>
        /// Gets or sets the estimated work hours for the project. The amount of time that is calculated and planned to take to complete the project.
        /// </summary>
        public int EstimatedWorkHours { get; set; }

        /// <summary>
        /// Gets or sets the final work hours for the project. The amount of time that actualy took to complete the project.
        /// </summary>
        public int FinalWorkHours { get; set; }

        /// <summary>
        /// Gets or sets the estimated budget for the project. The amount of budget that is calculated and planned to spend to complete the project.
        /// </summary>
        public decimal EstimatedBudget { get; set; }

        /// <summary>
        /// The amount of budget that actualy took to complete the project.
        /// </summary>
        public decimal FinalBudget { get; set; }

        [Display(Name = "Company name")]

        public string OrdererCompanyId { get; set; }

        public string CompanyName { get; set; }

        public IEnumerable<CompanyDropDownViewModel> Companies { get; set; }
    }
}
