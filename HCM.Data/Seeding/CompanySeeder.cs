namespace HCM.Data.Seeding
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using HCM.Data.Models;

    class CompanySeeder : ISeeder
    {
        public async Task SeedAsync(ApplicationDbContext dbContext, IServiceProvider serviceProvider)
        {
            if (dbContext.Companies.Any())
            {
                return;
            }

            var companies = new List<Company>
            {
                new Company
                {
                    Name = "Immedis",
                    Email = "info@immedis.com",
                    PhoneNumber = "+35314871537",
                    Logo = "https://res.cloudinary.com/crunchbase-production/image/upload/c_lpad,h_170,w_170,f_auto,b_white,q_auto:eco,dpr_1/qae0wxejgymbfqzb3gf9",
                    AboutUs = @"Immedis is a specialist division of The Taxback Group, a multi award-winning global financial services group. The company is a specialist provider of enterprise technology solutions for global payroll and mobility tax services. With over 170 experts worldwide, It delivers fully managed multi-country payroll and employment tax solutions fororganizations with overseas staff – whether local or expatriate. Its cloud-based payroll platform, iConnect provides a consolidated view of global payrolls, improves process efficiency, and ensures data, payroll, and tax compliance in over 130 countries worldwide.
Immedis was founded in 2016 and has offices in Dublin, Kilkenny, New Jersey, Sydney, and Varna.",
                },
            };

            await dbContext.Companies.AddRangeAsync(companies);
            await dbContext.SaveChangesAsync();
        }
    }
}
