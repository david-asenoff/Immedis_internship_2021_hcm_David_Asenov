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
                new Gender { Type = "Man" },
                new Gender { Type = "Woman" },
                new Gender { Type = "Other" },
            };

            await dbContext.Genders.AddRangeAsync(genders);
            await dbContext.SaveChangesAsync();
        }
    }
}
