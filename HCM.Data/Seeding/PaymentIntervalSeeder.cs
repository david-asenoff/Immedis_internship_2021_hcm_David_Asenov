namespace HCM.Data.Seeding
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using HCM.Data.Models;

    class PaymentIntervalSeeder : ISeeder
    {
        public async Task SeedAsync(ApplicationDbContext dbContext, IServiceProvider serviceProvider)
        {
            if (dbContext.PaymentIntervals.Any())
            {
                return;
            }

            var paymentIntervals = new List<PaymentInterval>
            {
                new PaymentInterval { Type = "daily" },
                new PaymentInterval { Type = "weekly" },
                new PaymentInterval { Type = "bi-weekly" },
                new PaymentInterval { Type = "semi-monthly" },
                new PaymentInterval { Type = "monthly" },
                new PaymentInterval { Type = "fixed length" },
                new PaymentInterval { Type = "custom" },
            };

            await dbContext.PaymentIntervals.AddRangeAsync(paymentIntervals);
            await dbContext.SaveChangesAsync();
        }
    }
}
