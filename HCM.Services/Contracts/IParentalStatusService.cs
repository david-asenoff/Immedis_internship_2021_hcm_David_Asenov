namespace HCM.Services.Contracts
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    using System.Threading.Tasks;
    using HCM.Web.ViewModels.ParentalStatus;

    public interface IParentalStatusService
    {
        Task<ICollection<ParentalStatusViewModel>> GetAllAsync();

        Task<bool> DeleteAsync(ParentalStatusDeleteViewModel model);

        Task<bool> EditAsync(ParentalStatusEditViewModel model);

        Task<bool> RestoreAsync(ParentalStatusRestoreViewModel model);

        Task<bool> AddAsync(ParentalStatusAddViewModel model);

        Task<ParentalStatusEditViewModel> GetAsync(int id);
    }
}
