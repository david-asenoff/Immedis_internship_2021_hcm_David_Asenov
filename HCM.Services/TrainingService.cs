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
    using HCM.Web.ViewModels.Training;
    using Microsoft.EntityFrameworkCore;

    public class TrainingService : ITrainingService
    {
        private readonly ApplicationDbContext db;

        public TrainingService(ApplicationDbContext db)
        {
            this.db = db;
        }

        public async Task<bool> AddAsync(TrainingAddViewModel model)
        {
            var dublicate = this.db.Trainings.Any(x => x.Name == model.Name &&
                                                       x.Description == model.Description);

            if (dublicate)
            {
                throw new ArgumentException(ExceptionMessages.CannotCreateDublicateObject);
            }

            var result = new Training
            {
                Name = model.Name,
                Description = model.Description,
                StartDate = model.StartDate,
                EndDate = model.EndDate,
                TotalHours = model.TotalHours,
            };

            await this.db.Trainings.AddAsync(result);
            await this.db.SaveChangesAsync();

            return true;
        }

        public async Task<bool> DeleteAsync(TrainingDeleteViewModel model)
        {
            var result = await this.db.Trainings.FirstOrDefaultAsync(x => x.Id == model.Id);
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

        public async Task<bool> EditAsync(TrainingEditViewModel model)
        {
            var result = await this.db.Trainings.FirstOrDefaultAsync(x => x.Id == model.Id);
            if (result != null)
            {
                if (result.IsDeleted)
                {
                    throw new ArgumentException(ExceptionMessages.CannotEditDeletedObject);
                }

                result.Name = model.Name;
                result.Description = model.Description;
                result.StartDate = model.StartDate;
                result.EndDate = model.EndDate;
                result.TotalHours = model.TotalHours;
                result.ModifiedOn = DateTime.UtcNow;
                await this.db.SaveChangesAsync();
                return true;
            }

            return false;
        }

        public async Task<ICollection<TrainingViewModel>> GetAllAsync()
        {
            var result = await this.db.Trainings.Select(x => new TrainingViewModel
            {
                Id = x.Id,
                Description = x.Description,
                Name = x.Name,
                StartDate = x.StartDate,
                EndDate = x.EndDate,
                TotalHours = x.TotalHours,
                CreatedOn = x.CreatedOn,
                ModifiedOn = x.ModifiedOn,
                DeletedOn = x.DeletedOn,
                IsDeleted = x.IsDeleted,
            }).ToListAsync();

            return result;
        }

        public async Task<bool> RestoreAsync(TrainingRestoreViewModel model)
        {
            var result = await this.db.Trainings.FirstOrDefaultAsync(x => x.Id == model.Id);
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

        public async Task<TrainingEditViewModel> GetAsync(string id)
        {
            var dbModel = await this.db.Trainings.FirstOrDefaultAsync(x => x.Id == id);
            var result = new TrainingEditViewModel
            {
                Id = dbModel.Id,
                Name = dbModel.Name,
                Description = dbModel.Description,
                TotalHours = dbModel.TotalHours,
                StartDate = dbModel.StartDate,
                EndDate = dbModel.EndDate,
            };

            return result;
        }
    }
}
