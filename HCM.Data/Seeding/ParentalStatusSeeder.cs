namespace HCM.Data.Seeding
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using HCM.Data.Models;

    public class ParentalStatusSeeder : ISeeder
    {
        public async Task SeedAsync(ApplicationDbContext dbContext, IServiceProvider serviceProvider)
        {
            if (dbContext.ParentalStatuses.Any())
            {
                return;
            }

            var parentalStatuses = new List<ParentalStatus>
            {
                new ParentalStatus { Type = "parent" },
                new ParentalStatus { Type = "step-parent" },
                new ParentalStatus { Type = "adoptive parent" },
                new ParentalStatus { Type = "guardian" },
                new ParentalStatus { Type = "not having children" },
            };

            await dbContext.ParentalStatuses.AddRangeAsync(parentalStatuses);
            await dbContext.SaveChangesAsync();
        }
    }
}
