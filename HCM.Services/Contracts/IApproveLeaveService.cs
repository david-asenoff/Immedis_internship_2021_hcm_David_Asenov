namespace HCM.Services.Contracts
{
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using HCM.Web.ViewModels.ApproveLeave;
    using HCM.Web.ViewModels.Gender;

    public interface IApproveLeaveService
    {
        Task<ICollection<ApproveLeaveViewModel>> GetAllAsync();

        Task<bool> EditAsync(ApproveLeaveEditViewModel model, string managerUsername);

        Task<ApproveLeaveEditViewModel> GetAsync(string id);
    }
}
