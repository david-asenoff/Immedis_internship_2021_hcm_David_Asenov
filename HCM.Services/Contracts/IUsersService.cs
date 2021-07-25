namespace HCM.Services.Contracts
{
    using System.Threading.Tasks;
    using HCM.Data.Models;

    public interface IUsersService
    {
        Task<string> GetLoggedUserId();

        Task<User> GetLoggedUserByIdAsync(string userId);

        Task<bool> DoesMailExist(string email);

        Task<int> GetUsersCount();

        Task BanUser(string userId);

        Task RemoveBanFromUser(string userId);

        Task<bool> IsAdmin(string userId);

        Task<bool> IsValid(string username, string password);

        Task<bool> DoesUserNameExist(string userName);
    }
}
