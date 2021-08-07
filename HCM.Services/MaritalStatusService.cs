

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
    using HCM.Web.ViewModels.MaritalStatus;
    using Microsoft.EntityFrameworkCore;

    public class MaritalStatusService : IMaritalStatusService
    {
        private readonly ApplicationDbContext db;

        public MaritalStatusService(ApplicationDbContext db)
        {
            this.db = db;
        }

        public async Task<bool> AddAsync(MaritalStatusAddViewModel model)
        {
            var dublicate = this.db.MaritalStatuses.Any(x => x.Type == model.Type);

            if (dublicate)
            {
                throw new ArgumentException(ExceptionMessages.CannotCreateDublicateObject);
            }

            var result = new MaritalStatus
            {
                Type = model.Type,
            };

            await this.db.MaritalStatuses.AddAsync(result);
            await this.db.SaveChangesAsync();

            return true;
        }

        public async Task<bool> DeleteAsync(MaritalStatusDeleteViewModel model)
        {
            var result = await this.db.MaritalStatuses.FirstOrDefaultAsync(x => x.Id == model.Id);
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

        public async Task<bool> EditAsync(MaritalStatusEditViewModel model)
        {
            var result = await this.db.MaritalStatuses.FirstOrDefaultAsync(x => x.Id == model.Id);
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

        public async Task<ICollection<MaritalStatusViewModel>> GetAllAsync()
        {
            var result = await this.db.MaritalStatuses.Select(x => new MaritalStatusViewModel
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

        public async Task<bool> RestoreAsync(MaritalStatusRestoreViewModel model)
        {
            var result = await this.db.MaritalStatuses.FirstOrDefaultAsync(x => x.Id == model.Id);
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

        public async Task<MaritalStatusEditViewModel> GetAsync(int id)
        {
            var dbModel = await this.db.MaritalStatuses.FirstOrDefaultAsync(x => x.Id == id);
            var result = new MaritalStatusEditViewModel
            {
                Type = dbModel.Type,
                Id = dbModel.Id,
            };

            return result;
        }
    }
}
