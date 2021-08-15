namespace HCM.Services
{
    using System;
    using System.Linq;
    using System.Threading.Tasks;
    using HCM.Data;
    using HCM.Data.Common;
    using HCM.Data.Models;
    using HCM.Services.Contracts;
    using HCM.Web.ViewModels.Employee;
    using HCM.Web.ViewModels.EmployeeProjects;
    using HCM.Web.ViewModels.Project;
    using Microsoft.EntityFrameworkCore;

    public class EmployeeProjectService : IEmployeeProjectService
    {
        private readonly ApplicationDbContext db;
        private readonly IUsersService usersService;
        private readonly IProjectService projectService;

        public EmployeeProjectService(ApplicationDbContext db, IUsersService usersService, IProjectService projectService)
        {
            this.db = db;
            this.usersService = usersService;
            this.projectService = projectService;
        }

        public async Task<bool> AddAsync(string projectId, string employeeId)
        {
            var dublicate = this.db.ProjectUsers.Any(x => x.ProjectId == projectId && x.UserId == employeeId);

            if (dublicate)
            {
                throw new ArgumentException(ExceptionMessages.CannotCreateDublicateObject);
            }

            await this.db.ProjectUsers.AddAsync(new ProjectUser
            {
                ProjectId = projectId,
                UserId = employeeId,
            });
            await this.db.SaveChangesAsync();
            return true;
        }

        public async Task<bool> DeleteAsync(string projectId, string employeeId)
        {
            var doesExist = this.db.ProjectUsers.Any(x => x.ProjectId == projectId && x.UserId == employeeId);

            if (!doesExist)
            {
                throw new ArgumentException("Emlpoyee is not added to this project, therefore cannot be deleted");
            }

            var projectUser = this.db.ProjectUsers.FirstOrDefault(x => x.ProjectId == projectId && x.UserId == employeeId);
            this.db.ProjectUsers.Remove(projectUser);
            await this.db.SaveChangesAsync();
            return true;
        }

        public async Task<EmployeeProjectsViewModel> GetAsync(string projectId)
        {
            var project = await this.projectService.GetAsync(projectId);

            var allParticipants = await this.db.ProjectUsers
                .Where(tu => tu.ProjectId == projectId)
                .Select(x => new ProjectUserViewModel
                {
                    UserId = x.UserId,
                    ProjectId = x.ProjectId,
                })
                .ToListAsync();

            var employees = await this.db.Users
                .Select(x => new EmployeeInformationBaseViewModel
                {
                    FirstName = x.FirstName,
                    MiddleName = x.MiddleName,
                    LastName = x.LastName,
                    Gender = x.GenderId,
                    PhoneNumber = x.PhoneNumber,
                    Email = x.Email,
                    Username = x.Username,
                    UserId = x.Id,
                    DateOfBirth = x.DateOfBirth,
                    AvatarUrl = x.Portrait,
                    IdentityRoleId = x.IdentityRoleId,
                    IdentityRoleType = x.Role.Type,
                    IsBanned = x.IsBanned,
                }).ToListAsync();

            var result = new EmployeeProjectsViewModel
            {
                Project = project,
                Employees = employees,
                AllParticipants = allParticipants,
            };

            return result;
        }
    }
}
