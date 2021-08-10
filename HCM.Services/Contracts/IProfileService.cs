namespace HCM.Services.Contracts
{
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using HCM.Data.Models;
    using HCM.Web.ViewModels.Employee;
    using HCM.Web.ViewModels.Profile;

    public interface IProfileService
    {
        public Task<bool> EditAsync(ProfileViewModel model, string imagePath);

        public Task<ProfileViewModel> GetAsync(string userName);
    }
}
