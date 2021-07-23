namespace HCM.Data.Seeding
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using HCM.Data.Models;

    class MaritalStatusSeeder : ISeeder
    {
        public async Task SeedAsync(ApplicationDbContext dbContext, IServiceProvider serviceProvider)
        {
            if (dbContext.MaritalStatuses.Any())
            {
                return;
            }

            var maritalStatuses = new List<MaritalStatus>
            {
                new MaritalStatus { Type = "single" },
                new MaritalStatus { Type = "married" },
                new MaritalStatus { Type = "widowed" },
                new MaritalStatus { Type = "divorced" },
                new MaritalStatus { Type = "separated" },
                new MaritalStatus { Type = "registered partnership" },
            };

            await dbContext.MaritalStatuses.AddRangeAsync(maritalStatuses);
            await dbContext.SaveChangesAsync();
        }
    }
}
