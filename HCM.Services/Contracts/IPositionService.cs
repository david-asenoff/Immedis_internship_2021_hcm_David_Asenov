namespace HCM.Services.Contracts
{
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using HCM.Web.ViewModels.Position;

    public interface IPositionService
    {
        Task<ICollection<PositionViewModel>> GetAllAsync();

        Task<bool> DeleteAsync(PositionDeleteViewModel model);

        Task<bool> EditAsync(PositionEditViewModel model);

        Task<bool> RestoreAsync(PositionRestoreViewModel model);

        Task<bool> AddAsync(PositionAddViewModel model);

        Task<PositionEditViewModel> GetAsync(string id);

        Task<ICollection<PositionDropDownViewModel>> GetAllAsDropDownAsync();
    }
}
