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
    using HCM.Web.ViewModels.ProjectStatus;
    using Microsoft.EntityFrameworkCore;

    public class ProjectStatusService : IProjectStatusService
    {
        private readonly ApplicationDbContext db;

        public ProjectStatusService(ApplicationDbContext db)
        {
            this.db = db;
        }

        public async Task<bool> AddAsync(ProjectStatusAddViewModel model)
        {
            var projectStatusCategory = this.db.ProjectStatusCategories.FirstOrDefault(x => x.Id == model.ProjectStatusCategoryId);
            var project = this.db.Projects.FirstOrDefault(x => x.Id == model.ProjectId);

            var dublicate = this.db.ProjectStatuses
                .Include(x => x.ProjectStatusCategory)
                .Include(x => x.Project)
                .Any(x => x.StartDate == model.StartDate &&
                          x.EndDate == model.EndDate &&
                          x.ProjectStatusCategory == projectStatusCategory &&
                          x.Project == project);

            if (dublicate)
            {
                throw new ArgumentException(ExceptionMessages.CannotCreateDublicateObject);
            }

            var result = new ProjectStatus
            {
                StartDate = model.StartDate,
                EndDate = model.EndDate,
                ProjectStatusCategory = projectStatusCategory,
                Project = project,
            };

            await this.db.ProjectStatuses.AddAsync(result);

            await this.db.SaveChangesAsync();

            return true;
        }

        public async Task<bool> DeleteAsync(ProjectStatusDeleteViewModel model)
        {
            var result = await this.db.ProjectStatuses.FirstOrDefaultAsync(x => x.Id == model.Id);
            if (result != null)
            {
                if (result.IsDeleted)
                {
                    throw new ArgumentException(ExceptionMessages.CannotDeletedAnAlreadyDeletedObject);
                }

                result.IsDeleted = true;
                result.DeletedOn = DateTime.UtcNow;
                await this.db.SaveChangesAsync();
                return true;
            }

            return false;
        }

        public async Task<bool> EditAsync(ProjectStatusEditViewModel model)
        {
            var projectStatus = this.db.ProjectStatuses.FirstOrDefault(x => x.Id == model.Id);
            var projectStatusCategory = this.db.ProjectStatusCategories.FirstOrDefault(x => x.Id == model.ProjectStatusCategoryId);
            var project = this.db.Projects.FirstOrDefault(x => x.Id == model.ProjectId);

            if (projectStatus != null &&
                projectStatusCategory != null &&
                project != null)
            {
                projectStatus.StartDate = model.StartDate;
                projectStatus.EndDate = model.EndDate;
                projectStatus.Project = project;
                projectStatus.ProjectStatusCategory = projectStatusCategory;
                projectStatus.ModifiedOn = DateTime.UtcNow;

                await this.db.SaveChangesAsync();
                return true;
            }

            return false;
        }

        public async Task<ICollection<ProjectStatusViewModel>> GetAllAsync()
        {
            var result = await this.db.ProjectStatuses
                .Include(x => x.ProjectStatusCategory)
                .Include(x => x.Project)
                .Select(x => new ProjectStatusViewModel
                {
                    Id = x.Id,
                    StartDate = x.StartDate,
                    EndDate = x.EndDate,
                    ProjectStatusCategoryId = x.ProjectStatusCategory.Id,
                    ProjectStatusCategoryType = x.ProjectStatusCategory.Type,
                    ProjectId = x.Project.Id,
                    ProjectName = x.Project.Name,
                    DeletedOn = x.DeletedOn,
                    IsDeleted = x.IsDeleted,
                }).ToListAsync();

            return result;
        }

        public async Task<ProjectStatusEditViewModel> GetAsync(string id)
        {
            var dbModel = await this.db.ProjectStatuses
                .Include(x => x.ProjectStatusCategory)
                .Include(x => x.Project)
                .FirstOrDefaultAsync(x => x.Id == id);
            var result = new ProjectStatusEditViewModel
            {
                Id = dbModel.Id,
                StartDate = dbModel.StartDate,
                EndDate = dbModel.EndDate,
                ProjectStatusCategoryId = dbModel.ProjectStatusCategory.Id,
                ProjectStatusCategoryType = dbModel.ProjectStatusCategory.Type,
                ProjectId = dbModel.Project.Id,
                ProjectName = dbModel.Project.Name,
            };

            return result;
        }

        public async Task<bool> RestoreAsync(ProjectStatusRestoreViewModel model)
        {
            var result = await this.db.ProjectStatuses.FirstOrDefaultAsync(x => x.Id == model.Id);
            if (result != null)
            {
                result.DeletedOn = null;
                result.IsDeleted = false;
                await this.db.SaveChangesAsync();
                return true;
            }

            return false;
        }
    }
}
