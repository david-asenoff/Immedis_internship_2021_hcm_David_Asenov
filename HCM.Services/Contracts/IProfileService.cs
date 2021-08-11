namespace HCM.Services.Contracts
{
    using System.Threading.Tasks;
    using HCM.Web.ViewModels.Profile;

    public interface IProfileService
    {
        public Task<bool> EditAsync(ProfileViewModel model, string imagePath);

        public Task<ProfileViewModel> GetAsync(string userName);
    }
}
