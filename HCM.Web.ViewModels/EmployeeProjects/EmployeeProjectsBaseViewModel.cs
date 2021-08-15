namespace HCM.Web.ViewModels.EmployeeProjects
{
using HCM.Web.ViewModels.Employee;
using HCM.Web.ViewModels.Project;
using System.Collections.Generic;

    public abstract class EmployeeProjectsBaseViewModel
    {
        public EmployeeProjectsBaseViewModel()
        {
            Employees = new List<EmployeeInformationBaseViewModel>();
            AllParticipants = new List<ProjectUserViewModel>();
        }
        public ICollection<EmployeeInformationBaseViewModel> Employees { get; set; }

        public ProjectEditViewModel Project { get; set; }

        public ICollection<ProjectUserViewModel> AllParticipants { get; set; }
    }
}