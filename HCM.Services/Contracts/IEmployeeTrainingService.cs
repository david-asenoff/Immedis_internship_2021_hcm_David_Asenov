namespace HCM.Services.Contracts
{
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using HCM.Web.ViewModels.EmployeeTrainings;
    using HCM.Web.ViewModels.Training;

    public interface IEmployeeTrainingService
    {
        Task<bool> AddAsync(string trainingId, string employeeId);

        Task<bool> DeleteAsync(string trainingId, string employeeId);

        Task<EmployeeTrainingsViewModel> GetAsync(string trainingId);
    }
}
