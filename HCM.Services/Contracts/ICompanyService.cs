namespace HCM.Services.Contracts
{
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using HCM.Web.ViewModels.Company;

    public interface ICompanyService
    {
        Task<ICollection<CompanyViewModel>> GetAllAsync();

        Task<bool> EditAsync(CompanyEditViewModel model,
            string imagePath);

        Task<bool> DeleteAsync(CompanyDeleteViewModel model);

        Task<bool> RestoreAsync(CompanyRestoreViewModel model);

        Task<bool> AddAsync(CompanyAddViewModel model,
            string imagePath);

        Task<CompanyEditViewModel> GetAsync(string id);

        ICollection<CompanyDropDownViewModel> GetAllAsDropDown();
    }
}
