namespace HCM.Services.Contracts
{
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using HCM.Data.Models;
    using HCM.Web.ViewModels.Employee;
    using HCM.Web.ViewModels.Profile;

    public interface IUsersService
    {
        public Task<bool> DoesMailExist(string email);

        public Task<bool> DoesUserNameExist(string userName);

        public Task<int> GetUsersCount();

        public Task<User> BanUser(string userId);

        public Task<User> RemoveBanFromUser(string userId);

        public Task<User> CreateEmployeeAsync(EmployeeRegistrationViewModel model);

        public Task<bool> DoesUserNameAndPasswordCombinationExist(EmployeeLoginViewModel model);

        public Task<User> GetUserByUserName(string userName);

        public Task<ICollection<User>> GetAllEmployeesByCompany(string companyId);

        public Task<bool> EditProfileAsync(ProfileViewModel model);

        public Task<ProfileViewModel> GetProfileAsync(string userName);
    }
}
