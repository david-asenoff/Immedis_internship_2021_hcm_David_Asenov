namespace HCM.Data.Seeding
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using HCM.Data.Models;

    class CompanyAdressSeeder : ISeeder
    {
        public async Task SeedAsync(ApplicationDbContext dbContext, IServiceProvider serviceProvider)
        {
            if (dbContext.CompanyAddresses.Any())
            {
                return;
            }

            var company = dbContext.Companies.FirstOrDefault().Id;
            var address = dbContext.Addresses.FirstOrDefault().Id;
            var companyAddresses = new List<CompanyAddress>
            {
                new CompanyAddress
                {
                    CompanyId = company,
                    AddressId = address,
                },
            };

            await dbContext.CompanyAddresses.AddRangeAsync(companyAddresses);
            await dbContext.SaveChangesAsync();
        }
    }
}
