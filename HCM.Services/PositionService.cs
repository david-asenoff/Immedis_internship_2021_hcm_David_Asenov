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
    using HCM.Web.ViewModels.Position;
    using Microsoft.EntityFrameworkCore;

    public class PositionService : IPositionService
    {
        private readonly ApplicationDbContext db;

        public PositionService(ApplicationDbContext db)
        {
            this.db = db;
        }

        public async Task<bool> AddAsync(PositionAddViewModel model)
        {
            var dublicate = this.db.Possitions.Any(x => x.Name == model.Name);

            if (dublicate)
            {
                throw new ArgumentException(ExceptionMessages.CannotCreateDublicateObject);
            }

            var result = new Possition
            {
                Name = model.Name,
            };

            await this.db.Possitions.AddAsync(result);
            await this.db.SaveChangesAsync();

            return true;
        }

        public async Task<bool> DeleteAsync(PositionDeleteViewModel model)
        {
            var result = await this.db.Possitions.FirstOrDefaultAsync(x => x.Id == model.Id);
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

        public async Task<bool> EditAsync(PositionEditViewModel model)
        {
            var result = await this.db.Possitions.FirstOrDefaultAsync(x => x.Id == model.Id);
            if (result != null)
            {
                if (result.IsDeleted)
                {
                    throw new ArgumentException(ExceptionMessages.CannotEditDeletedObject);
                }

                result.Name = model.Name;
                result.ModifiedOn = DateTime.UtcNow;
                await this.db.SaveChangesAsync();
                return true;
            }

            return false;
        }

        public async Task<ICollection<PositionViewModel>> GetAllAsync()
        {
            var result = await this.db.Possitions.Select(x => new PositionViewModel
            {
                Name = x.Name,
                Id = x.Id,
                CreatedOn = x.CreatedOn,
                ModifiedOn = x.ModifiedOn,
                DeletedOn = x.DeletedOn,
                IsDeleted = x.IsDeleted,
            }).ToListAsync();

            return result;
        }

        public async Task<PositionEditViewModel> GetAsync(string id)
        {
            var dbModel = await this.db.Possitions.FirstOrDefaultAsync(x => x.Id == id);
            var result = new PositionEditViewModel
            {
                Name = dbModel.Name,
                Id = dbModel.Id,
            };

            return result;
        }

        public async Task<bool> RestoreAsync(PositionRestoreViewModel model)
        {
            var result = await this.db.Possitions.FirstOrDefaultAsync(x => x.Id == model.Id);
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

        public async Task<ICollection<PositionDropDownViewModel>> GetAllAsDropDownAsync()
        {
            return await this.db.Possitions.Select(x => new PositionDropDownViewModel { Id = x.Id, Name = x.Name }).OrderBy(x => x.Name).ToArrayAsync();
        }
    }
}
