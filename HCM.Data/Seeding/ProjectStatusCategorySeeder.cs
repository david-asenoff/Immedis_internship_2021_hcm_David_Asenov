namespace HCM.Data.Seeding
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using HCM.Data.Models;

    class ProjectStatusCategorySeeder : ISeeder
    {
        public async Task SeedAsync(ApplicationDbContext dbContext, IServiceProvider serviceProvider)
        {
            if (dbContext.ProjectStatusCategories.Any())
            {
                return;
            }

            var projectStatusCategories = new List<ProjectStatusCategory>
            {
                new ProjectStatusCategory { Type = "not started" },
                new ProjectStatusCategory { Type = "cacelled" },
                new ProjectStatusCategory { Type = "in progress" },
                new ProjectStatusCategory { Type = "on hold" },
                new ProjectStatusCategory { Type = "completed" },
            };

            await dbContext.ProjectStatusCategories.AddRangeAsync(projectStatusCategories);
            await dbContext.SaveChangesAsync();
        }
    }
}
