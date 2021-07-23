namespace HCM.Services
{
    using System.Threading.Tasks;
    using HCM.Data.Models;
    using HCM.Services.Contracts;

    public class UsersService : IUsersService
    {
        public Task BanUser(string userId)
        {
            throw new System.NotImplementedException();
        }

        public Task<bool> DoesMailExist(string email)
        {
            throw new System.NotImplementedException();
        }

        public Task<User> GetLoggedUserByIdAsync(string userId)
        {
            throw new System.NotImplementedException();
        }

        public Task<string> GetLoggedUserId()
        {
            throw new System.NotImplementedException();
        }

        public Task<int> GetUsersCount()
        {
            throw new System.NotImplementedException();
        }

        public Task<bool> IsAdmin(string userId)
        {
            throw new System.NotImplementedException();
        }

        public Task<bool> IsValid(string username, string password)
        {
            throw new System.NotImplementedException();
        }

        public Task RemoveBanFromUser(string userId)
        {
            throw new System.NotImplementedException();
        }
    }
}
