namespace HCM.Data.Seeding
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using HCM.Data.Models;

    class ContractSeeder : ISeeder
    {
        public async Task SeedAsync(ApplicationDbContext dbContext, IServiceProvider serviceProvider)
        {
            if (dbContext.EmployeeContracts.Any())
            {
                return;
            }

            var userIds = dbContext.Users.Select(x => x.Id).ToList();
            var departmentIds = dbContext.Departments.Select(x => x.Id).ToList();
            var positionIds = dbContext.Possitions.Select(x => x.Id).ToList();
            var salaryIds = dbContext.Salaries.Select(x => x.Id).ToList();
            var contracts = new List<EmployeeContract>();

            Random random = new Random();
            for (int i = 0; i < userIds.Count; i++)
            {
                contracts.Add(new EmployeeContract
                {
                    UserId = userIds[i],
                    DepartmentId = departmentIds[random.Next(0, departmentIds.Count() - 1)],
                    PossitionId = positionIds[random.Next(0, positionIds.Count() - 1)],
                    StartDate = DateTime.UtcNow.AddYears(random.Next(-10, 0)).AddDays(i),
                    StartOfTheWorkingHours = new TimeSpan(8, 0, 0),
                    EndOfTheWorkingHours = new TimeSpan(17, 0, 0),
                    AreWorkingHoursFlexible = true,
                    IsContractTypeFullTime = true,
                    PaidLeavesAllowedPerYear = 20,
                    UnpaidLeavesAllowedPerYear = 20,
                    SalaryId = salaryIds[i],
                });
            }

            await dbContext.EmployeeContracts.AddRangeAsync(contracts);
            await dbContext.SaveChangesAsync();
        }
    }
}
