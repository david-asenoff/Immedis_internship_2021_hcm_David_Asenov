namespace HCM.Data.Seeding
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using HCM.Data.Models;

    class GenderSeeder : ISeeder
    {
        public async Task SeedAsync(ApplicationDbContext dbContext, IServiceProvider serviceProvider)
        {
            if (dbContext.Genders.Any())
            {
                return;
            }

            var genders = new List<Gender>
            {
                new Gender { Type = "masculine" },
                new Gender { Type = "feminine" },
                new Gender { Type = "other" },
            };

            await dbContext.Genders.AddRangeAsync(genders);
            await dbContext.SaveChangesAsync();
        }
    }
}
