namespace HCM.Services.Contracts
{
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using HCM.Web.ViewModels.ApproveLeave;
   
    public interface IApproveLeaveService
    {
        Task<ICollection<ApproveLeaveViewModel>> GetAllAsync();

        Task<bool> EditAsync(ApproveLeaveEditViewModel model, string managerUsername);

        Task<ApproveLeaveEditViewModel> GetAsync(string id);
    }
}
