namespace HCM.Web.ViewModels.EmployeeTrainings
{
using HCM.Web.ViewModels.Employee;
using HCM.Web.ViewModels.Training;
using System.Collections.Generic;

    public abstract class EmployeeTrainingsBaseViewModel
    {
        public EmployeeTrainingsBaseViewModel()
        {
            Employees = new List<EmployeeInformationBaseViewModel>();
            AllParticipants = new List<TrainingUserViewModel>();
        }
        public ICollection<EmployeeInformationBaseViewModel> Employees { get; set; }

        public TrainingEditViewModel Training { get; set; }

        public ICollection<TrainingUserViewModel> AllParticipants { get; set; }
    }
}