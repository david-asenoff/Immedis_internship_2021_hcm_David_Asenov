namespace HCM.Services.Contracts
{
    using System.Threading.Tasks;
    using HCM.Web.ViewModels.EmployeeTrainings;

    public interface IEmployeeTrainingService
    {
        Task<bool> AddAsync(string trainingId, string employeeId);

        Task<bool> DeleteAsync(string trainingId, string employeeId);

        Task<EmployeeTrainingsViewModel> GetAsync(string trainingId);
    }
}
