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

            var manager = dbContext.Users.FirstOrDefault().Id;
            var immedis = dbContext.Companies.FirstOrDefault().Id;
            var taxback = dbContext.Companies.FirstOrDefault().Id;

            var departments = new List<Department>
            {
                new Department { Name = "Marketing", CompanyId = immedis, DepartmentManagerId = manager },
                new Department { Name = "Finance", CompanyId = immedis },
                new Department { Name = "Operations management", CompanyId = immedis },
                new Department { Name = "Human Resource", CompanyId = immedis },
                new Department { Name = "IT", CompanyId = immedis },
                new Department { Name = "Marketing", CompanyId = taxback },
                new Department { Name = "Finance", CompanyId = taxback, DepartmentManagerId = manager },
                new Department { Name = "Operations management", CompanyId = taxback },
                new Department { Name = "Human Resource", CompanyId = taxback },
                new Department { Name = "IT", CompanyId = taxback },
            };

            await dbContext.Departments.AddRangeAsync(departments);
            await dbContext.SaveChangesAsync();
        }
    }
}
