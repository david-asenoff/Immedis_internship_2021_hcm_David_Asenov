namespace HCM.Data.Seeding
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using HCM.Data.Common;
    using HCM.Data.Models;

    class LeavesSeeder : ISeeder
    {
        public async Task SeedAsync(ApplicationDbContext dbContext, IServiceProvider serviceProvider)
        {
            if (dbContext.RequestedLeaves.Any())
            {
                return;
            }

            var requestedLeaves = new List<RequestedLeave>();
            var managerId = dbContext.Users.Where(x => x.Username == GlobalConstants.ManagerRoleName).Select(x => x.Id).FirstOrDefault();
            for (int i = 0; i < 100; i++)
            {
                var userId = dbContext.Users.Where(x => x.Username == $"username{i}").Select(x => x.Id).FirstOrDefault();
                // Pending
                var pending = new RequestedLeave
                {
                    IsApproved = null,
                    StartDate = DateTime.UtcNow.AddDays(20),
                    EndDate = DateTime.UtcNow.AddDays(27),
                    RequestedByUserId = userId,
                    IsPaidLeave = true,
                };
                // Approved
                var approved = new RequestedLeave
                {
                    IsApproved = true,
                    StartDate = DateTime.UtcNow.AddDays(-100),
                    EndDate = DateTime.UtcNow.AddDays(-95),
                    RequestedByUserId = userId,
                    IsPaidLeave = false,
                    RevisedByManagerId = managerId,
                };
                // Declined
                var declined = new RequestedLeave
                {
                    IsApproved = false,
                    StartDate = DateTime.UtcNow.AddDays(-200),
                    EndDate = DateTime.UtcNow.AddDays(-190),
                    RequestedByUserId = userId,
                    IsPaidLeave = false,
                    RevisedByManagerId = managerId,
                };
                requestedLeaves.Add(pending);
                requestedLeaves.Add(approved);
                requestedLeaves.Add(declined);
            }

            await dbContext.RequestedLeaves.AddRangeAsync(requestedLeaves);
            await dbContext.SaveChangesAsync();
        }
    }
}
