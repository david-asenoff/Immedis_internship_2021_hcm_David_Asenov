namespace HCM.Services
{
    using System.Threading.Tasks;
    using HCM.Data;
    using HCM.Data.Models;
    using HCM.Services.Contracts;
    using Microsoft.EntityFrameworkCore;

    public class UsersService : IUsersService
    {
        private readonly ApplicationDbContext db;

        public UsersService(ApplicationDbContext db)
        {
            this.db = db;
        }

        public Task BanUser(string userId)
        {
            throw new System.NotImplementedException();
        }

        public async Task<bool> DoesMailExist(string email)
        {
            var dbUser = await this.db.Users.FirstOrDefaultAsync(x => x.Email == email);

            return dbUser == null ? false : true;
        }

        public async Task<bool> DoesUserNameExist(string userName)
        {
            var dbUser = await this.db.Users.FirstOrDefaultAsync(x => x.Username == userName);

            return dbUser == null ? false : true;
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
