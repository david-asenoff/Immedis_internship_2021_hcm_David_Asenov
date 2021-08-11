namespace HCM.Services.Contracts
{
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using HCM.Web.ViewModels.ManageUser;

    public interface IManageUserService
    {
        public Task<bool> EditAsync(ManageUserViewModel model);

        public Task<ManageUserViewModel> GetAsync(string userName);

        public Task<ICollection<ManageUserViewModel>> GetAllAsync();
    }
}
