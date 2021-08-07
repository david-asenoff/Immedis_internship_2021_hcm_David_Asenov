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
            var role = await dbContext.IdentityRoles.FirstOrDefaultAsync(x => x.Type == GlobalConstants.AdministratorRoleName);
            var users = new List<User>
            {
                new User
                {
                    FirstName = "David",
                    MiddleName = "Rosenov",
                    LastName = "Asenov",
                    Gender = gender,
                    PhoneNumber = "+359876543210",
                    Email = GlobalConstants.SystemEmail,
                    Password = SecurePasswordHasher.Hash("123456"),
                    Username = GlobalConstants.AdministratorRoleName,
                    DateOfBirth = DateTime.UtcNow.AddYears(-20),
                    Role = role,
                },
            };

            await dbContext.Users.AddRangeAsync(users);
            await dbContext.SaveChangesAsync();
        }
    }
}
