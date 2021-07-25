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

            var company = dbContext.Companies.FirstOrDefault().Id;

            var departments = new List<Department>
            {
                new Department { Name = "Marketing", CompanyId = company },
                new Department { Name = "Finance", CompanyId = company },
                new Department { Name = "Operations management", CompanyId = company },
                new Department { Name = "Human Resource", CompanyId = company },
                new Department { Name = "IT", CompanyId = company },
            };

            await dbContext.Departments.AddRangeAsync(departments);
            await dbContext.SaveChangesAsync();
        }
    }
}
