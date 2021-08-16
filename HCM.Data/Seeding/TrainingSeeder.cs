namespace HCM.Data.Seeding
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using HCM.Data.Models;

    class TrainingSeeder : ISeeder
    {
        public async Task SeedAsync(ApplicationDbContext dbContext, IServiceProvider serviceProvider)
        {
            if (dbContext.Trainings.Any())
            {
                return;
            }

            var manager = dbContext.Users.FirstOrDefault().Id;
            var immedis = dbContext.Companies.FirstOrDefault().Id;
            var taxback = dbContext.Companies.Skip(1).FirstOrDefault().Id;
            var userIds = dbContext.Users.Select(x => x.Id).ToList();
            var trainings = new List<Training>
            {
                new Training{ Name = "Immedis Internship 2021",
                    Description = "The application should hold people records, which are the main app entities. The functionality of the app should support creating, listing, editing and deleting people's records, salary information, department. System should have login functionality i.e. security module and at least 2 types of users. The application should persist the data into a databases. Application should be containerized and have at least 2 APIs communicating with each other. Data validation and error handling is a plus but is not mandatory. Designing the functionality in terms of functionalities and capabilities will depend on you. The goal is to create a production like software that could cover the needs of an HR team in a small/medium company.",
                    //assign year, month, day, hour, min, seconds, UTC timezone
                    StartDate = new DateTime(2021, 7, 4, 5, 10, 20, DateTimeKind.Utc),
                    EndDate = new DateTime(2021, 8, 14, 5, 10, 20, DateTimeKind.Utc),
                    TotalHours = 40,
                },
                new Training{ Name = "Juniors onboarding",
                    Description = "Onboarding; also known as organizational socialization, is management jargon first created in the 1970s that refers to the mechanism through which new employees acquire the necessary knowledge, skills, and behaviors in order to become effective organizational members and insiders.",
                    //assign year, month, day, hour, min, seconds, UTC timezone
                    StartDate = new DateTime(2021, 8, 20, 5, 10, 20, DateTimeKind.Utc),
                    EndDate = new DateTime(2021, 8, 30, 5, 10, 20, DateTimeKind.Utc),
                    TotalHours = 40,
                },
                new Training{ Name = "Jira",
                    Description = "Jira is a proprietary issue tracking product developed by Atlassian that allows bug tracking and agile project management.",
                    //assign year, month, day, hour, min, seconds, UTC timezone
                    StartDate = new DateTime(2021, 9, 20, 5, 10, 20, DateTimeKind.Utc),
                    EndDate = new DateTime(2021, 9, 30, 5, 10, 20, DateTimeKind.Utc),
                    TotalHours = 40,
                },
                new Training{ Name = "NHibernate",
                    Description = "NHibernate is an object–relational mapping solution for the Microsoft .NET platform. It provides a framework for mapping an object-oriented domain model to a traditional relational database. Its purpose is to relieve the developer from a significant portion of relational data persistence-related programming tasks.",
                    //assign year, month, day, hour, min, seconds, UTC timezone
                    StartDate = new DateTime(2021, 10, 20, 5, 10, 20, DateTimeKind.Utc),
                    EndDate = new DateTime(2021, 10, 30, 5, 10, 20, DateTimeKind.Utc),
                    TotalHours = 40,
                },
                new Training{ Name = "Grafana",
                    Description = "Grafana is a multi-platform open source analytics and interactive visualization web application. It provides charts, graphs, and alerts for the web when connected to supported data sources.",
                    //assign year, month, day, hour, min, seconds, UTC timezone
                    StartDate = new DateTime(2021, 11, 20, 5, 10, 20, DateTimeKind.Utc),
                    EndDate = new DateTime(2021, 11, 30, 5, 10, 20, DateTimeKind.Utc),
                    TotalHours = 40,
                },
            };
            await dbContext.Trainings.AddRangeAsync(trainings);
            await dbContext.SaveChangesAsync();
            var trainingUsers = new List<TrainingUser>();
            var dbtrainings = dbContext.Trainings.Select(x => x.Id).ToList();
            for (int i = 0; i < trainings.Count; i++)
            {
                for (int j = 0; j < userIds.Count; j++)
                {
                    if (j % 2 == 0)
                    {
                        continue;
                    }

                    trainingUsers.Add(new TrainingUser { UserId = userIds[j], TrainingId = dbtrainings[i] });
                }
            }

            await dbContext.TrainingUsers.AddRangeAsync(trainingUsers);
            await dbContext.SaveChangesAsync();
        }
    }
}
