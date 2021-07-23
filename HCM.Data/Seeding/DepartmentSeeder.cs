namespace HCM.Data.Seeding
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using HCM.Data.Models;

    class DepartmentSeeder : ISeeder
    {
        public async Task SeedAsync(ApplicationDbContext dbContext, IServiceProvider serviceProvider)
        {
            if (dbContext.Departments.Any())
            {
                return;
            }

            var departments = new List<Department>
            {
                new Department { Name = "Marketing" },
                new Department { Name = "Finance" },
                new Department { Name = "Operations management" },
                new Department { Name = "Human Resource" },
                new Department { Name = "IT" },
            };

            await dbContext.Departments.AddRangeAsync(departments);
            await dbContext.SaveChangesAsync();
        }
    }
}
