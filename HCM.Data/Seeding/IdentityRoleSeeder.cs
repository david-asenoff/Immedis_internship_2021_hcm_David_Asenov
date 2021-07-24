namespace HCM.Data.Seeding
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    class IdentityRoleSeeder : ISeeder
    {
        public async Task SeedAsync(ApplicationDbContext dbContext, IServiceProvider serviceProvider)
        {
            if (dbContext.IdentityRoles.Any())
            {
                return;
            }

            var identityRoles = new List<IdentityRole>
            {
                new IdentityRole { Type = "Admin" },
                new IdentityRole { Type = "Manager" },
                new IdentityRole { Type = "HR" },
                new IdentityRole { Type = "Employee" },
            };

            await dbContext.IdentityRoles.AddRangeAsync(identityRoles);
            await dbContext.SaveChangesAsync();
        }
    }
}
