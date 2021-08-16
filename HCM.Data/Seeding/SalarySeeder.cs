namespace HCM.Data.Seeding
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using HCM.Data.Models;

    class SalarySeeder : ISeeder
    {
        public async Task SeedAsync(ApplicationDbContext dbContext, IServiceProvider serviceProvider)
        {
            if (dbContext.Salaries.Any())
            {
                return;
            }

            var salaries = new List<Salary>();
            var usersCount = dbContext.Users.Count();
            var currencies = dbContext.Currencies.Select(x => x.Id).ToList();
            var paymentIntervals = dbContext.PaymentIntervals.Select(x => x.Id).ToList();
            Random random = new Random();
            for (int i = 0; i < usersCount; i++)
            {
                var salary = random.Next(1800, 5000);
                salaries.Add(new Salary
                {
                    GrossSalary = salary,
                    NetSalary = salary * 0.7M,
                    CurrencyId = currencies[random.Next(0, currencies.Count())],
                    PaymentIntervalId = paymentIntervals[random.Next(0,paymentIntervals.Count())],
                });
            }

            await dbContext.Salaries.AddRangeAsync(salaries);
            await dbContext.SaveChangesAsync();
        }
    }
}
