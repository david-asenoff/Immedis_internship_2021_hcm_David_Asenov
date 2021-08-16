namespace HCM.Data.Seeding
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using HCM.Data.Models;

    class ProjectSeeder : ISeeder
    {
        public async Task SeedAsync(ApplicationDbContext dbContext, IServiceProvider serviceProvider)
        {
            if (dbContext.Projects.Any())
            {
                return;
            }

            var manager = dbContext.Users.FirstOrDefault().Id;
            var immedis = dbContext.Companies.FirstOrDefault().Id;
            var taxback = dbContext.Companies.Skip(1).FirstOrDefault().Id;
            var userIds = dbContext.Users.Select(x => x.Id).ToList();
            var projects = new List<Project>
            {
               new Project
               {
                   Name="U.S. Digital Response Launch",
                   Description="It started with a Zoom call. As COVID-19 began its spread across the United States, a group of technologists got to talking about how the pandemic could stretch local government resources to the breaking point. The group—which included three former U.S. deputy chief technology officers—hatched a plan to recruit volunteer software engineers, data scientists, interaction designers and project managers to provide free, fast help to public agencies struggling to keep pace with rising community needs.",
                   EstimatedWorkHours = 4000,
                   FinalWorkHours = 4300,
                   EstimatedBudget = 8760780M,
                   FinalBudget = 9897676M,
                   OrdererCompanyId = immedis,
               },
               new Project
               {
                   Name="Curie",
                   Description="Data is moving faster in South America after Google successfully installed Curie, a submerged cable stretching from Los Angeles, California, USA to Valparíso, Chile. Roughly 10,500 kilometers (6,524 miles) long, the subsea cable has been delivering 72 terabits per second of much-needed bandwidth to the continent since late 2019—after a team of divers and engineers tested then buried it. Google announced in November it would be extending a branch to Panama.",
                   EstimatedWorkHours = 7000,
                   FinalWorkHours = 6300,
                   EstimatedBudget = 9760780M,
                   FinalBudget = 8897676M,
                   OrdererCompanyId = immedis,
               },
               new Project
               {
                   Name="2Africa",
                   Description="One of the world’s largest subsea projects, 2Africa will deliver a major internet boost to 23 countries in Africa, the Middle East and Europe. Announced in May and backed by the likes of Facebook, Vodafone and China Mobile, the US$1 billion project will add 37,000 kilometers (23,000 miles) of cable and is expected to go live by 2024.",
                   EstimatedWorkHours = 499000,
                   FinalWorkHours = 439900,
                   EstimatedBudget = 78760780M,
                   FinalBudget = 69897676M,
                   OrdererCompanyId = immedis,
               },
               new Project
               {
                   Name="SafeZone",
                   Description="Germany’s Kinexon delivered a wearable tracking device in May that helped sports leagues around the world safely resume workouts and games amid COVID-19. First deployed to promote coronavirus social distancing in the workplace, the SafeZone tags provide anonymized tracing of athletes from German Bundesliga Basketball to the National Basketball Association to the National Football League. If a player tests positive, the software alerts anyone who had close contact so they can be tested as well.",
                   EstimatedWorkHours = 5000,
                   FinalWorkHours = 4300,
                   EstimatedBudget = 80780M,
                   FinalBudget = 98676M,
                   OrdererCompanyId = taxback,
               },
               new Project
               {
                   Name="A.I. Chair",
                   Description="Renowned French industrial designer Philippe Starck worked with Autodesk to create what the U.S. software company billed as the first chair conceived using AI. Unveiled by furniture maker Kartell at Milan’s Salone del Mobile in 2019, it came to life after Starck and Kartell fed ideas—along with parameters like materials, manufacturing methods and cost constraints—into the generative design software, which quickly offered a design option.",
                   EstimatedWorkHours = 95000,
                   FinalWorkHours = 84300,
                   EstimatedBudget = 980780M,
                   FinalBudget = 898676M,
                   OrdererCompanyId = taxback,
               },
            };
            await dbContext.Projects.AddRangeAsync(projects);
            await dbContext.SaveChangesAsync();
            var projectUsers = new List<ProjectUser>();
            var dbProjects = dbContext.Projects.Select(x => x.Id).ToList();
            for (int i = 0; i < projects.Count; i++)
            {
                for (int j = 0; j < userIds.Count; j++)
                {
                    if (j % 2 == 0)
                    {
                        continue;
                    }

                    projectUsers.Add(new ProjectUser { UserId = userIds[j], ProjectId = dbProjects[i] });
                }
            }

            await dbContext.ProjectUsers.AddRangeAsync(projectUsers);
            await dbContext.SaveChangesAsync();
        }
    }
}
