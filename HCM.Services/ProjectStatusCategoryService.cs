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
    using HCM.Web.ViewModels.ProjectStatusCategory;
    using Microsoft.EntityFrameworkCore;

    public class ProjectStatusCategoryService : IProjectStatusCategoryService
    {
        private readonly ApplicationDbContext db;

        public ProjectStatusCategoryService(ApplicationDbContext db)
        {
            this.db = db;
        }

        public async Task<bool> AddAsync(ProjectStatusCategoryAddViewModel model)
        {
            var dublicate = this.db.ProjectStatusCategories.Any(x => x.Type == model.Type);

            if (dublicate)
            {
                throw new ArgumentException(ExceptionMessages.CannotCreateDublicateObject);
            }

            var result = new ProjectStatusCategory
            {
                Type = model.Type,
            };

            await this.db.ProjectStatusCategories.AddAsync(result);
            await this.db.SaveChangesAsync();

            return true;
        }

        public async Task<bool> DeleteAsync(ProjectStatusCategoryDeleteViewModel model)
        {
            var result = await this.db.ProjectStatusCategories.FirstOrDefaultAsync(x => x.Id == model.Id);
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

        public async Task<bool> EditAsync(ProjectStatusCategoryEditViewModel model)
        {
            var result = await this.db.ProjectStatusCategories.FirstOrDefaultAsync(x => x.Id == model.Id);
            if (result != null)
            {
                if (result.IsDeleted)
                {
                    throw new ArgumentException(ExceptionMessages.CannotEditDeletedObject);
                }

                result.Type = model.Type;
                result.ModifiedOn = DateTime.UtcNow;
                await this.db.SaveChangesAsync();
                return true;
            }

            return false;
        }

        public async Task<ICollection<ProjectStatusCategoryViewModel>> GetAllAsync()
        {
            var result = await this.db.ProjectStatusCategories.Select(x => new ProjectStatusCategoryViewModel
            {
                Id = x.Id,
                Type = x.Type,
                CreatedOn = x.CreatedOn,
                ModifiedOn = x.ModifiedOn,
                IsDeleted = x.IsDeleted,
                DeletedOn = x.DeletedOn,
            }).ToListAsync();

            return result;
        }

        public async Task<ProjectStatusCategoryEditViewModel> GetAsync(int id)
        {
            var dbModel = await this.db.ProjectStatusCategories.FirstOrDefaultAsync(x => x.Id == id);
            var result = new ProjectStatusCategoryEditViewModel
            {
                Type = dbModel.Type,
                Id = dbModel.Id,
            };

            return result;
        }

        public async Task<bool> RestoreAsync(ProjectStatusCategoryRestoreViewModel model)
        {
            var result = await this.db.ProjectStatusCategories.FirstOrDefaultAsync(x => x.Id == model.Id);
            if (result != null)
            {
                if (result.IsDeleted == false)
                {
                    throw new ArgumentException(ExceptionMessages.CannotRestoreDeletedObject);
                }

                result.DeletedOn = null;
                result.IsDeleted = false;
                await this.db.SaveChangesAsync();
                return true;
            }

            return false;
        }

        public async Task<ICollection<ProjectStatusCategoryDropDownViewModel>> GetAllAsDropDownAsync()
        {
            return await this.db.ProjectStatusCategories.Select(x => new ProjectStatusCategoryDropDownViewModel { Id = x.Id, Type = x.Type }).ToArrayAsync();
        }
    }
}
