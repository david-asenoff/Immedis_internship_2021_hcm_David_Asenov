namespace HCM.Data.Seeding
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using HCM.Data.Common;
    using HCM.Data.Models;
    using Microsoft.EntityFrameworkCore;

    class AdminSeeder : ISeeder
    {
        public async Task SeedAsync(ApplicationDbContext dbContext, IServiceProvider serviceProvider)
        {
            if (dbContext.Users.Any())
            {
                return;
            }

            var gender = await dbContext.Genders.FirstOrDefaultAsync(x => x.Type == "Man");
            var admin = await dbContext.IdentityRoles.FirstOrDefaultAsync(x => x.Type == GlobalConstants.AdministratorRoleName);
            var manager = await dbContext.IdentityRoles.FirstOrDefaultAsync(x => x.Type == GlobalConstants.ManagerRoleName);
            var users = new List<User>
            {
                new User
                {
                    FirstName = "David",
                    MiddleName = "Rosenov",
                    LastName = "Asenov",
                    Portrait = "https://avatars.githubusercontent.com/u/49104423?v=4",
                    Gender = gender,
                    PhoneNumber = "+359876543210",
                    Email = GlobalConstants.SystemEmail,
                    Password = SecurePasswordHasher.Hash("123456"),
                    Username = GlobalConstants.AdministratorRoleName,
                    DateOfBirth = DateTime.UtcNow.AddYears(-30),
                    Role = admin,
                },
                new User
                {
                    FirstName = "Ruairi",
                    LastName = "Kelleher",
                    Portrait = "https://i.ibb.co/bz3LvxG/ruairi-kelleher-immedis-web2.gif",
                    Gender = gender,
                    PhoneNumber = "+359876543210",
                    Email = "manager@immedis.com",
                    Password = SecurePasswordHasher.Hash("123456"),
                    Username = GlobalConstants.ManagerRoleName,
                    DateOfBirth = DateTime.UtcNow.AddYears(-30),
                    Role = manager,
                },
            };

            await dbContext.Users.AddRangeAsync(users);
            await dbContext.SaveChangesAsync();
        }
    }
}
