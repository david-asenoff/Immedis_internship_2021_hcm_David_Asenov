namespace HCM.Data.Seeding
{
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public class ApplicationDbContextSeeder : ISeeder
    {
        public async Task SeedAsync(ApplicationDbContext dbContext, IServiceProvider serviceProvider)
        {
            if (dbContext == null)
            {
                throw new ArgumentNullException(nameof(dbContext));
            }

            if (serviceProvider == null)
            {
                throw new ArgumentNullException(nameof(serviceProvider));
            }

            var seeders = new List<ISeeder>
                          {
                              new CompanySeeder(),
                              new AddressSeeder(),
                              new CompanyAdressSeeder(),
                              new GenderSeeder(),
                              new CurrencySeeder(),
                              new EvaluationScoreSeeder(),
                              new IdentityRoleSeeder(),
                              new MaritalStatusSeeder(),
                              new ParentalStatusSeeder(),
                              new PaymentIntervalSeeder(),
                              new ProjectStatusCategorySeeder(),
                              new AdminSeeder(),
                              new EmployeeSeeder(),
                              new DepartmentSeeder(),
                              new LeavesSeeder(),
                              new TrainingSeeder(),
                              new ProjectSeeder(),
                              new PositionSeeder(),
                              new SalarySeeder(),
                              new ContractSeeder(),
                          };

            foreach (var seeder in seeders)
            {
                await seeder.SeedAsync(dbContext, serviceProvider);
            }

            await dbContext.SaveChangesAsync();
        }
    }
}
