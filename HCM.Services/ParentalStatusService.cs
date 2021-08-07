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
    using HCM.Web.ViewModels.ParentalStatus;
    using Microsoft.EntityFrameworkCore;

    public class ParentalStatusService : IParentalStatusService
    {
        private readonly ApplicationDbContext db;

        public ParentalStatusService(ApplicationDbContext db)
        {
            this.db = db;
        }

        public async Task<bool> AddAsync(ParentalStatusAddViewModel model)
        {
            var dublicate = this.db.ParentalStatuses.Any(x => x.Type == model.Type);

            if (dublicate)
            {
                throw new ArgumentException(ExceptionMessages.CannotCreateDublicateObject);
            }

            var result = new ParentalStatus
            {
                Type = model.Type,
            };

            await this.db.ParentalStatuses.AddAsync(result);
            await this.db.SaveChangesAsync();

            return true;
        }

        public async Task<bool> DeleteAsync(ParentalStatusDeleteViewModel model)
        {
            var result = await this.db.ParentalStatuses.FirstOrDefaultAsync(x => x.Id == model.Id);
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

        public async Task<bool> EditAsync(ParentalStatusEditViewModel model)
        {
            var result = await this.db.ParentalStatuses.FirstOrDefaultAsync(x => x.Id == model.Id);
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

        public async Task<ICollection<ParentalStatusViewModel>> GetAllAsync()
        {
            var result = await this.db.ParentalStatuses.Select(x => new ParentalStatusViewModel
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

        public async Task<bool> RestoreAsync(ParentalStatusRestoreViewModel model)
        {
            var result = await this.db.ParentalStatuses.FirstOrDefaultAsync(x => x.Id == model.Id);
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

        public async Task<ParentalStatusEditViewModel> GetAsync(int id)
        {
            var dbModel = await this.db.ParentalStatuses.FirstOrDefaultAsync(x => x.Id == id);
            var result = new ParentalStatusEditViewModel
            {
                Type = dbModel.Type,
                Id = dbModel.Id,
            };

            return result;
        }
    }
}
