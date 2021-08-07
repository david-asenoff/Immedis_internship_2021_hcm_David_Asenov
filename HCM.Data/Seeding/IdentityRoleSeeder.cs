namespace HCM.Data.Seeding
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using HCM.Data.Common;

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
                new IdentityRole { Type = GlobalConstants.AdministratorRoleName },
                new IdentityRole { Type = GlobalConstants.ManagerRoleName },
                new IdentityRole { Type = GlobalConstants.HRRoleName },
                new IdentityRole { Type = GlobalConstants.EmployeeRoleName },
            };

            await dbContext.IdentityRoles.AddRangeAsync(identityRoles);
            await dbContext.SaveChangesAsync();
        }
    }
}
