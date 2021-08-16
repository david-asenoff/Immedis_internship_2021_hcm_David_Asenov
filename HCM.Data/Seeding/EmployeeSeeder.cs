namespace HCM.Data.Seeding
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using HCM.Data.Common;
    using HCM.Data.Models;
    using Microsoft.EntityFrameworkCore;

    class EmployeeSeeder : ISeeder
    {
        public async Task SeedAsync(ApplicationDbContext dbContext, IServiceProvider serviceProvider)
        {
            var role = await dbContext.IdentityRoles.FirstOrDefaultAsync(x => x.Type == GlobalConstants.EmployeeRoleName);

            if (dbContext.Users.Any(x => x.Role == role))
            {
                return;
            }

            var man = await dbContext.Genders.FirstOrDefaultAsync(x => x.Type == "Man");
            var woman = await dbContext.Genders.FirstOrDefaultAsync(x => x.Type == "Woman");
            var users = new List<User>();

            for (int i = 0; i < 100; i++)
            {
                var person = FakeNamesGenerator.Get();
                var age = i <= 50 ? 18 + i : 118 - i;
                User user = new User
                {
                    FirstName = person.FirstName,
                    MiddleName = person.MiddleName,
                    Portrait = i < 50 ?
                    $@"https://randomuser.me/api/portraits/men/{i}.jpg" :
                    $@"https://randomuser.me/api/portraits/women/{i}.jpg",
                    LastName = person.LastName,
                    Gender = i < 50 ? man : woman,
                    PhoneNumber = $"+3598765432{i}",
                    Email = $"{person.FirstName}.{person.LastName}{i}@gmail.com",
                    Password = SecurePasswordHasher.Hash("123456"),
                    Username = $"username{i}",
                    DateOfBirth = DateTime.UtcNow.AddYears(-age),
                    Role = role,
                };
                users.Add(user);
            }

            await dbContext.Users.AddRangeAsync(users);
            await dbContext.SaveChangesAsync();
        }
    }
}
