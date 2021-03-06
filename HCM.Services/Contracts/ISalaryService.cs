namespace HCM.Services.Contracts
{
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using HCM.Data.Models;
    using HCM.Web.ViewModels.Salary;

    public interface ISalaryService
    {
        Task<ICollection<SalaryViewModel>> GetAllAsync();

        Task<bool> EditAsync(SalaryEditViewModel model);

        Task<bool> DeleteAsync(SalaryDeleteViewModel model);

        Task<bool> RestoreAsync(SalaryRestoreViewModel model);

        Task<Salary> AddAsync(SalaryAddViewModel model);

        Task<SalaryEditViewModel> GetAsync(string id);
    }
}
