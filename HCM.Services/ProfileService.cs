namespace HCM.Services
{
    using System;
    using System.IO;
    using System.Linq;
    using System.Threading.Tasks;
    using HCM.Data;
    using HCM.Data.Common;
    using HCM.Services.Contracts;
    using HCM.Web.ViewModels.Employee;
    using HCM.Web.ViewModels.Profile;
    using Microsoft.EntityFrameworkCore;

    public class ProfileService : IProfileService
    {
        private readonly ApplicationDbContext db;
        private readonly IUsersService usersService;
        private readonly string[] allowedExtensions = new[] { "jpg", "png", "gif", "jpeg" };

        public ProfileService(ApplicationDbContext db, IUsersService usersService)
        {
            this.db = db;
            this.usersService = usersService;
        }

        public async Task<bool> EditAsync(ProfileViewModel model, string imagePath)
        {
            var emlpoyeeLoginModel = new EmployeeLoginViewModel
            {
                Username = model.Username,
                Password = model.Password,
            };
            var isValidCombinationOfUserAndPassword = await this.usersService.DoesUserNameAndPasswordCombinationExist(emlpoyeeLoginModel);

            if (isValidCombinationOfUserAndPassword)
            {
                var gender = await this.db.Genders.FirstOrDefaultAsync(x => x.Id == model.Gender);
                var user = await this.usersService.GetUserByUserName(model.Username);

                if (user.IsDeleted)
                {
                    throw new ArgumentException(ExceptionMessages.CannotEditDeletedObject);
                }

                Directory.CreateDirectory($"{imagePath}/profiles/");
                if (model.ProfileAvatar != null)
                {
                    var extension = Path.GetExtension(model.ProfileAvatar.FileName).TrimStart('.');
                    if (!this.allowedExtensions.Any(x => extension.EndsWith(x.ToLower())))
                    {
                        throw new ArgumentException($"Invalid image extension {extension}");
                    }

                    // To do:  delete the old avatar. If its different format than the new one will persist in the root.
                    var physicalPath = $"{imagePath}/profiles/{user.Id}.{extension}";
                    using Stream fileStream = new FileStream(physicalPath, FileMode.Create);
                    await model.ProfileAvatar.CopyToAsync(fileStream);
                    user.Portrait = $"/images/profiles/{user.Id}.{extension}";
                }

                user.Gender = gender;
                user.FirstName = model.FirstName;
                user.MiddleName = model.MiddleName;
                user.LastName = model.LastName;

                user.PhoneNumber = model.PhoneNumber;
                user.DateOfBirth = model.DateOfBirth;

                var doesEmailChanged = model.Email != user.Email;
                var doesEmailExist = await this.usersService.DoesMailExist(model.Email);
                if (doesEmailChanged && !doesEmailExist)
                {
                    user.Email = model.Email;
                }

                await this.db.SaveChangesAsync();
                return true;
            }

            return false;
        }

        public async Task<ProfileViewModel> GetAsync(string userName)
        {
            var result = await this.usersService.GetUserByUserName(userName);
            if (result != null)
            {
                var profileModel = new ProfileViewModel();
                profileModel.FirstName = result.FirstName;
                profileModel.MiddleName = result.MiddleName;
                profileModel.LastName = result.LastName;
                profileModel.Gender = result.GenderId;
                profileModel.PhoneNumber = result.PhoneNumber;
                profileModel.Email = result.Email;
                profileModel.Username = result.Username;
                profileModel.DateOfBirth = result.DateOfBirth;
                profileModel.ProfileAvatarUrl = result.Portrait;
                return profileModel;
            }

            throw new ArgumentNullException(GlobalConstants.UsernameIsInvalid);
        }
    }
}
