namespace HCM.Data.Seeding
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using HCM.Data.Models;

    class PositionSeeder : ISeeder
    {
        public async Task SeedAsync(ApplicationDbContext dbContext, IServiceProvider serviceProvider)
        {
            if (dbContext.Possitions.Any())
            {
                return;
            }

            string[] examples = new string[]
            {

                "UX designer",
                "UI developer",
                "IT manager",
                "Computer programmer",
                "SQL developer",
                "Software developer",
                "Web administrator",
                "Data architect",
                "Business intelligence developer",
                "Mobile application developer",
                "Information security analyst",
                "Front-end web developer",
                "Java developer",
                ".NET Developer",
                "Database manager",
                "Software engineer",
            };

            var positions = new List<Possition>();

            for (int i = 0; i < examples.Length; i++)
            {
                positions.Add(new Possition { Name = examples[i] });
            }

            await dbContext.Possitions.AddRangeAsync(positions);
            await dbContext.SaveChangesAsync();
        }
    }
}
