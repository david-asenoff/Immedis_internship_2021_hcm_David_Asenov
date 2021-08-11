namespace HCM.Services.Contracts
{
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using HCM.Web.ViewModels.RequestedLeave;

    public interface IRequestedLeavesService
    {
        Task<ICollection<RequestedLeaveViewModel>> GetAllAsync(string userName);

        Task<bool> DeleteAsync(RequestedLeaveDeleteViewModel model, string userName);

        Task<bool> EditAsync(RequestedLeaveEditViewModel model, string userName);

        Task<bool> RestoreAsync(RequestedLeaveRestoreViewModel model, string userName);

        Task<bool> AddAsync(RequestedLeaveAddViewModel model, string userName);

        Task<RequestedLeaveEditViewModel> GetAsync(string id, string userName);
    }
}
