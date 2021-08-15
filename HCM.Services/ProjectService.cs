namespace HCM.Services
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using HCM.Data;
    using HCM.Data.Common;
    using HCM.Data.Models;
    using HCM.Services.Contracts;
    using HCM.Web.ViewModels.Project;
    using Microsoft.EntityFrameworkCore;

    public class ProjectService : IProjectService
    {
        private readonly ApplicationDbContext db;

        public ProjectService(ApplicationDbContext db)
        {
            this.db = db;
        }

        public async Task<bool> AddAsync(ProjectAddViewModel model)
        {
            var dublicate = this.db.Companies
                .Include(x => x.OrderedProjects)
                .Where(x => x.Id == model.OrdererCompanyId)
                .Any(x => x.OrderedProjects.Any(x => x.Name == model.Name && x.Description == model.Description));

            if (dublicate)
            {
                throw new ArgumentException(ExceptionMessages.CannotCreateDublicateObject);
            }

            var company = this.db.Companies.FirstOrDefault(x => x.Id == model.OrdererCompanyId);

            var result = new Project
            {
                Name = model.Name,
                Description = model.Description,
                EstimatedWorkHours = model.EstimatedWorkHours,
                FinalWorkHours = model.FinalWorkHours,
                EstimatedBudget = model.EstimatedBudget,
                FinalBudget = model.FinalBudget,
                OrdererCompany = company,
            };
            var inProgress = this.db.ProjectStatusCategories.FirstOrDefault(x => x.Type == "in progress");

            await this.db.ProjectStatuses.AddAsync(new ProjectStatus { Project = result, ProjectStatusCategory = inProgress });

            await this.db.Projects.AddAsync(result);

            await this.db.SaveChangesAsync();

            return true;
        }

        public async Task<bool> DeleteAsync(ProjectDeleteViewModel model)
        {
            var result = await this.db.Projects.FirstOrDefaultAsync(x => x.Id == model.Id);
            if (result != null)
            {
                result.IsDeleted = true;
                result.DeletedOn = DateTime.UtcNow;
                await this.db.SaveChangesAsync();
                return true;
            }

            return false;
        }

        public async Task<bool> EditAsync(ProjectEditViewModel model)
        {
            var department = await this.db.Projects.FirstOrDefaultAsync(x => x.Id == model.Id);
            var company = this.db.Companies.FirstOrDefault(x => x.Id == model.OrdererCompanyId);

            if (department != null)
            {
                department.Name = model.Name;
                department.Description = model.Description;
                department.EstimatedWorkHours = model.EstimatedWorkHours;
                department.FinalWorkHours = model.FinalWorkHours;
                department.EstimatedBudget = model.EstimatedBudget;
                department.FinalBudget = model.FinalBudget;
                department.OrdererCompany = company;

                department.ModifiedOn = DateTime.UtcNow;

                await this.db.SaveChangesAsync();
                return true;
            }

            return false;
        }

        public async Task<ICollection<ProjectViewModel>> GetAllAsync()
        {
            var result = await this.db.Projects
                .Include(x => x.OrdererCompany)
                .Include(x => x.ProjectStatuses)
                .ThenInclude(x => x.ProjectStatusCategory)
                .Select(x => new ProjectViewModel
                {
                    Id = x.Id,
                    Name = x.Name,
                    Description = x.Description,
                    EstimatedWorkHours = x.EstimatedWorkHours,
                    FinalWorkHours = x.FinalWorkHours,
                    EstimatedBudget = x.EstimatedBudget,
                    FinalBudget = x.FinalBudget,
                    OrdererCompanyId = x.OrdererCompany.Id,
                    CreatedOn = x.CreatedOn,
                    ModifiedOn = x.ModifiedOn,
                    DeletedOn = x.DeletedOn,
                    IsDeleted = x.IsDeleted,
                    CompanyName = x.OrdererCompany.Name,
                    ProjectStatus = x.ProjectStatuses.OrderByDescending(x => x.CreatedOn).ThenByDescending(x => x.ModifiedOn).Select(x => x.ProjectStatusCategory.Type).FirstOrDefault(),
                }).ToListAsync();

            return result;
        }

        public async Task<ProjectEditViewModel> GetAsync(string id)
        {
            var dbModel = await this.db.Projects
                .Include(x => x.OrdererCompany)
                .FirstOrDefaultAsync(x => x.Id == id);
            var result = new ProjectEditViewModel
            {
                Id = dbModel.Id,
                Name = dbModel.Name,
                Description = dbModel.Description,
                EstimatedWorkHours = dbModel.EstimatedWorkHours,
                FinalWorkHours = dbModel.FinalWorkHours,
                EstimatedBudget = dbModel.EstimatedBudget,
                FinalBudget = dbModel.FinalBudget,
                OrdererCompanyId = dbModel.OrdererCompany.Id,
            };

            return result;
        }

        public async Task<bool> RestoreAsync(ProjectRestoreViewModel model)
        {
            var result = await this.db.Projects.FirstOrDefaultAsync(x => x.Id == model.Id);
            if (result != null)
            {
                result.DeletedOn = null;
                result.IsDeleted = false;
                await this.db.SaveChangesAsync();
                return true;
            }

            return false;
        }

        public async Task<ICollection<ProjectDropDownViewModel>> GetAllAsDropDown()
        {
            return await this.db.Projects.Select(x => new ProjectDropDownViewModel { Id = x.Id, Name = x.Name }).ToArrayAsync();
        }

        public async Task<ICollection<ProjectViewModel>> GetAllByUsernameAsync(string username)
        {
            var result = await this.db.Projects
                .Include(x => x.ProjectUsers)
                .ThenInclude(x => x.User)
                .Where(x => x.ProjectUsers.Any(x => x.User.Username == username))
                .Include(x => x.OrdererCompany)
                .Include(x => x.ProjectStatuses)
                .ThenInclude(x => x.ProjectStatusCategory)
                .Select(x => new ProjectViewModel
                {
                    Id = x.Id,
                    Name = x.Name,
                    Description = x.Description,
                    EstimatedWorkHours = x.EstimatedWorkHours,
                    FinalWorkHours = x.FinalWorkHours,
                    EstimatedBudget = x.EstimatedBudget,
                    FinalBudget = x.FinalBudget,
                    OrdererCompanyId = x.OrdererCompany.Id,
                    CreatedOn = x.CreatedOn,
                    ModifiedOn = x.ModifiedOn,
                    DeletedOn = x.DeletedOn,
                    IsDeleted = x.IsDeleted,
                    CompanyName = x.OrdererCompany.Name,
                    ProjectStatus = x.ProjectStatuses.OrderByDescending(x => x.CreatedOn).ThenByDescending(x => x.ModifiedOn).Select(x => x.ProjectStatusCategory.Type).FirstOrDefault(),
                }).ToListAsync();

            return result;
        }
    }
}
