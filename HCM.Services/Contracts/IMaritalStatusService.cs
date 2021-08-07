namespace HCM.Services.Contracts
{
    using System.Collections.Generic;
    using System.Threading.Tasks;

    using HCM.Web.ViewModels.MaritalStatus;

    public interface IMaritalStatusService
    {
        Task<ICollection<MaritalStatusViewModel>> GetAllAsync();

        Task<bool> DeleteAsync(MaritalStatusDeleteViewModel model);

        Task<bool> EditAsync(MaritalStatusEditViewModel model);

        Task<bool> RestoreAsync(MaritalStatusRestoreViewModel model);

        Task<bool> AddAsync(MaritalStatusAddViewModel model);

        Task<MaritalStatusEditViewModel> GetAsync(int id);
    }
}
