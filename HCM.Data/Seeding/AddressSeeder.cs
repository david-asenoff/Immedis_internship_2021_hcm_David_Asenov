namespace HCM.Data.Seeding
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using HCM.Data.Models;

    class AddressSeeder : ISeeder
    {
        public async Task SeedAsync(ApplicationDbContext dbContext, IServiceProvider serviceProvider)
        {
            if (dbContext.Addresses.Any())
            {
                return;
            }

            var addresses = new List<Address>
            {
                new Address
                {
                    Location = "Dublin, Dublin, Ireland",
                },
            };

            await dbContext.Addresses.AddRangeAsync(addresses);
            await dbContext.SaveChangesAsync();
        }
    }
}
