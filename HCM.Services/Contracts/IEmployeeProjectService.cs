namespace HCM.Services.Contracts
{
    using System.Threading.Tasks;
    using HCM.Web.ViewModels.EmployeeProjects;

    public interface IEmployeeProjectService
    {
        Task<bool> AddAsync(string projectId, string employeeId);

        Task<bool> DeleteAsync(string projectId, string employeeId);

        Task<EmployeeProjectsViewModel> GetAsync(string projectId);
    }
}
