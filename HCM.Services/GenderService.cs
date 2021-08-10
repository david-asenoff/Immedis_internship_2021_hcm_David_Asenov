namespace HCM.Services.Contracts
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using HCM.Data;
    using HCM.Data.Common;
    using HCM.Data.Models;
    using HCM.Web.ViewModels.Gender;
    using Microsoft.EntityFrameworkCore;

    public class GenderService : IGenderService
    {
        private readonly ApplicationDbContext db;

        public GenderService(ApplicationDbContext db)
        {
            this.db = db;
        }

        public async Task<bool> AddAsync(GenderAddViewModel model)
        {
            var dublicate = this.db.Genders.Any(x => x.Type == model.Type);

            if (dublicate)
            {
                throw new ArgumentException(ExceptionMessages.CannotCreateDublicateObject);
            }

            var result = new Gender
            {
                Type = model.Type,
            };

            await this.db.Genders.AddAsync(result);
            await this.db.SaveChangesAsync();

            return true;
        }

        public async Task<bool> DeleteAsync(GenderDeleteViewModel model)
        {
            var result = await this.db.Genders.FirstOrDefaultAsync(x => x.Id == model.Id);
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

        public async Task<bool> EditAsync(GenderEditViewModel model)
        {
            var result = await this.db.Genders.FirstOrDefaultAsync(x => x.Id == model.Id);
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

        public async Task<ICollection<GenderDropDownViewModel>> GetAllAsDropDownAsync()
        {
            return await this.db.Genders.Select(x => new GenderDropDownViewModel
            {
                Id = x.Id,
                Type = x.Type,
            }).ToArrayAsync();
        }

        public async Task<ICollection<GenderViewModel>> GetAllAsync()
        {
            var result = await this.db.Genders.Select(x => new GenderViewModel
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

        public async Task<GenderEditViewModel> GetAsync(string id)
        {
            var dbModel = await this.db.Genders.FirstOrDefaultAsync(x => x.Id == id);
            var result = new GenderEditViewModel
            {
                Type = dbModel.Type,
                Id = dbModel.Id,
            };

            return result;
        }

        public async Task<bool> RestoreAsync(GenderRestoreViewModel model)
        {
            var result = await this.db.Genders.FirstOrDefaultAsync(x => x.Id == model.Id);
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
    }
}