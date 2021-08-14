namespace HCM.Services.Contracts
{
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using HCM.Web.ViewModels.EmployeeContract;

    public interface IEmployeeContractService
    {
        Task<ICollection<EmployeeContractViewModel>> GetAllAsync();

        Task<bool> EditAsync(EmployeeContractViewModel model);

        Task<EmployeeContractViewModel> GetAsync(string contractId);

        Task<bool> EndTheContractAsync(string contractId);

        Task<ICollection<EmployeeContractViewModel>> GetAllByEmployeeIdAsync(string employeeId);

        Task<bool> CreateForEmployeeAsync(string employeeId);
    }
}
