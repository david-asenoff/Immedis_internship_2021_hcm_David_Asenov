namespace HCM.Services
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using HCM.Data;
    using HCM.Data.Common;
    using HCM.Services.Contracts;
    using HCM.Web.ViewModels.ManageUser;
    using Microsoft.EntityFrameworkCore;

    public class ManageUserService : IManageUserService
    {
        private readonly ApplicationDbContext db;
        private readonly IUsersService usersService;
        private readonly IRoleService roleService;
        private readonly string[] allowedExtensions = new[] { "jpg", "png", "gif", "jpeg" };

        public ManageUserService(ApplicationDbContext db, IUsersService usersService, IRoleService roleService)
        {
            this.db = db;
            this.usersService = usersService;
            this.roleService = roleService;
        }

        public async Task<bool> EditAsync(ManageUserViewModel model)
        {
            var user = await this.usersService.GetUserByUserName(model.Username);

            if (user.IsDeleted)
            {
                throw new ArgumentException(ExceptionMessages.CannotEditDeletedObject);
            }

            user.IsBanned = model.IsBanned;
            user.IdentityRoleId = model.IdentityRoleId;

            await this.db.SaveChangesAsync();
            return true;
        }

        public async Task<ManageUserViewModel> GetAsync(string userName)
        {
            var result = await this.usersService.GetUserByUserName(userName);
            var roles = await this.roleService.GetAllAsDropDownAsync();

            if (result != null)
            {
                var manageUserViewModel = new ManageUserViewModel();

                manageUserViewModel.FirstName = result.FirstName;
                manageUserViewModel.MiddleName = result.MiddleName;
                manageUserViewModel.LastName = result.LastName;
                manageUserViewModel.Gender = result.GenderId;
                manageUserViewModel.PhoneNumber = result.PhoneNumber;
                manageUserViewModel.Email = result.Email;
                manageUserViewModel.Username = result.Username;
                manageUserViewModel.DateOfBirth = result.DateOfBirth;
                manageUserViewModel.AvatarUrl = result.Portrait;
                manageUserViewModel.Roles = roles;
                manageUserViewModel.IdentityRoleType = result.Role.Type;
                manageUserViewModel.IdentityRoleId = result.IdentityRoleId;
                manageUserViewModel.IsBanned = result.IsBanned;
                manageUserViewModel.UserId = result.Id;

                return manageUserViewModel;
            }

            throw new ArgumentNullException(GlobalConstants.UsernameIsInvalid);
        }

        public async Task<ICollection<ManageUserViewModel>> GetAllAsync()
        {
            var roles = await this.roleService.GetAllAsDropDownAsync();
            var result = await this.db.Users.Include(x => x.Role).Select(x => new ManageUserViewModel
            {
                FirstName = x.FirstName,
                MiddleName = x.MiddleName,
                LastName = x.LastName,
                Gender = x.GenderId,
                PhoneNumber = x.PhoneNumber,
                Email = x.Email,
                Username = x.Username,
                UserId = x.Id,
                DateOfBirth = x.DateOfBirth,
                AvatarUrl = x.Portrait,
                IdentityRoleId = x.IdentityRoleId,
                IdentityRoleType = x.Role.Type,
                Roles = roles,
                IsBanned = x.IsBanned,
            }).ToListAsync();

            return result;
        }
    }
}
