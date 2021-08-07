namespace HCM.Services.Contracts
{
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using HCM.Web.ViewModels.Company;

    public interface ICompanyService
    {
        Task<ICollection<CompanyViewModel>> GetAllAsync();

        Task<bool> EditAsync(CompanyEditViewModel model);

        Task<bool> DeleteAsync(CompanyDeleteViewModel model);

        Task<bool> RestoreAsync(CompanyRestoreViewModel model);

        Task<bool> AddAsync(CompanyAddViewModel model);

        Task<CompanyEditViewModel> GetAsync(string id);

        ICollection<CompanyDropDownViewModel> GetCompanies();
    }
}
