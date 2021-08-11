namespace HCM.Web.ViewModels.ProjectStatus
{
    using HCM.Data.Common;
    using HCM.Web.ViewModels.Project;
    using HCM.Web.ViewModels.ProjectStatusCategory;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public abstract class ProjectStatusBaseViewModel
    {
        [Display(Name = GlobalConstants.ProjectStatusCategoryDisplay)]
        [Required(ErrorMessage = GlobalConstants.ProjectStatusCategoryIsRequired)]
        public int ProjectStatusCategoryId { get; set; }

        public string ProjectStatusCategoryType { get; set; }

        public IEnumerable<ProjectStatusCategoryDropDownViewModel> ProjectStatusCategories { get; set; }

        [Required]
        public string ProjectId { get; set; }

        public string ProjectName { get; set; }

        public IEnumerable<ProjectDropDownViewModel> Projects { get; set; }

        [Display(Name = GlobalConstants.StartDateDisplay)]
        [Required(ErrorMessage = GlobalConstants.StartDateIsRequired)]
        public DateTime StartDate { get; set; }

        public DateTime? EndDate { get; set; }
    }
}
