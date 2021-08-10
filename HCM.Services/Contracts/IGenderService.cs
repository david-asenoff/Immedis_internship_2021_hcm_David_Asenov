namespace HCM.Services.Contracts
{
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using HCM.Web.ViewModels.Gender;

    public interface IGenderService
    {
        Task<ICollection<GenderViewModel>> GetAllAsync();

        Task<bool> DeleteAsync(GenderDeleteViewModel model);

        Task<bool> EditAsync(GenderEditViewModel model);

        Task<bool> RestoreAsync(GenderRestoreViewModel model);

        Task<bool> AddAsync(GenderAddViewModel model);

        Task<GenderEditViewModel> GetAsync(string id);

        Task<ICollection<GenderDropDownViewModel>> GetAllAsDropDownAsync();
    }
}
