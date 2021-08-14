namespace HCM.Services
{
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using HCM.Data;
    using HCM.Data.Common;
    using HCM.Data.Models;
    using HCM.Services.Contracts;
    using HCM.Web.ViewModels.Employee;
    using Microsoft.EntityFrameworkCore;

    public class UsersService : IUsersService
    {
        private readonly ApplicationDbContext db;

        public UsersService(ApplicationDbContext db)
        {
            this.db = db;
        }

        public async Task<bool> DoesMailExist(string email)
        {
            var result = await this.db.Users.FirstOrDefaultAsync(x => x.Email == email);

            return result == null ? false : true;
        }

        public async Task<bool> DoesUserNameExist(string userName)
        {
            var result = await this.db.Users.FirstOrDefaultAsync(x => x.Username == userName);

            return result == null ? false : true;
        }

        public async Task<int> GetUsersCount()
        {
            var result = await this.db.Users.CountAsync();
            return result;
        }

        public async Task<User> BanUser(string userId)
        {
            var result = await this.db.Users.FirstOrDefaultAsync(x => x.Id == userId);
            result.IsBanned = true;
            await this.db.SaveChangesAsync();
            return result;
        }

        public async Task<User> RemoveBanFromUser(string userId)
        {
            var result = await this.db.Users.FirstOrDefaultAsync(x => x.Id == userId);
            result.IsBanned = false;
            await this.db.SaveChangesAsync();
            return result;
        }

        public async Task<User> CreateEmployeeAsync(EmployeeRegistrationViewModel model)
        {
            var gender = await this.db.Genders.FirstOrDefaultAsync(x => x.Id == model.Gender);
            var role = await this.db.IdentityRoles.FirstOrDefaultAsync(x => x.Type == "Employee");

            var doesUsernameExist = await this.DoesUserNameExist(model.Username);
            var doesEmailExist = await this.DoesMailExist(model.Email);

            if (doesEmailExist)
            {
                throw new ArgumentException("Email is already taken");
            }

            if (doesUsernameExist)
            {
                throw new ArgumentException("Username is already taken");
            }

            var user = new User
            {
                FirstName = model.FirstName,
                MiddleName = model.MiddleName,
                LastName = model.LastName,
                Gender = gender,
                PhoneNumber = model.PhoneNumber,
                Email = model.Email,
                Password = SecurePasswordHasher.Hash(model.Password),
                Username = model.Username,
                DateOfBirth = model.DateOfBirth,
                Role = role,
            };

            await this.db.Users.AddAsync(user);
            await this.db.SaveChangesAsync();
            return user;
        }

        public async Task<bool> DoesUserNameAndPasswordCombinationExist(EmployeeLoginViewModel model)
        {
            var result = await this.db.Users.FirstOrDefaultAsync(x => x.Username == model.Username);
            if (result != null && SecurePasswordHasher.Verify(model.Password, result.Password))
            {
                return true;
            }

            return false;
        }

        public async Task<User> GetUserByUserName(string userName)
        {
            var result = await this.db.Users.Include(x => x.Role).FirstOrDefaultAsync(x => x.Username == userName);

            return result;
        }

        public Task<ICollection<User>> GetAllEmployeesByCompany(string companyId)
        {
            throw new NotImplementedException();
        }

        public async Task<ICollection<User>> GetAllEmployees()
        {
            throw new NotImplementedException();
        }
    }
}
