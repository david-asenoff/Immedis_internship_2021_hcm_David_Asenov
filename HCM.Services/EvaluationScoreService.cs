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
    using HCM.Web.ViewModels.EvaluationScore;
    using Microsoft.EntityFrameworkCore;

    public class EvaluationScoreService : IEvaluationScoreService
    {
        private readonly ApplicationDbContext db;

        public EvaluationScoreService(ApplicationDbContext db)
        {
            this.db = db;
        }

        public async Task<bool> AddAsync(EvaluationScoreAddViewModel model)
        {
            var dublicate = this.db.EvaluationScores.Any(x => x.Rate == model.Rate || x.Description == model.Description);

            if (dublicate)
            {
                throw new ArgumentException(ExceptionMessages.CannotCreateDublicateObject);
            }

            var result = new EvaluationScore
            {
                Rate = model.Rate,
                Description = model.Description,
            };

            await this.db.EvaluationScores.AddAsync(result);
            await this.db.SaveChangesAsync();

            return true;
        }

        public async Task<bool> DeleteAsync(EvaluationScoreDeleteViewModel model)
        {
            var result = await this.db.EvaluationScores.FirstOrDefaultAsync(x => x.Id == model.Id);
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

        public async Task<bool> EditAsync(EvaluationScoreEditViewModel model)
        {
            var result = await this.db.EvaluationScores.FirstOrDefaultAsync(x => x.Id == model.Id);
            if (result != null)
            {
                if (result.IsDeleted)
                {
                    throw new ArgumentException(ExceptionMessages.CannotEditDeletedObject);
                }

                result.Rate = model.Rate;
                result.Description = model.Description;
                result.ModifiedOn = DateTime.UtcNow;
                await this.db.SaveChangesAsync();
                return true;
            }

            return false;
        }

        public async Task<ICollection<EvaluationScoreViewModel>> GetAllAsync()
        {
            var result = await this.db.EvaluationScores.Select(x => new EvaluationScoreViewModel
            {
                Rate = x.Rate,
                Description = x.Description,
                Id = x.Id,
                CreatedOn = x.CreatedOn,
                ModifiedOn = x.ModifiedOn,
                DeletedOn = x.DeletedOn,
                IsDeleted = x.IsDeleted,
            }).ToListAsync();

            return result;
        }

        public async Task<EvaluationScoreEditViewModel> GetAsync(int id)
        {
            var dbModel = await this.db.EvaluationScores.FirstOrDefaultAsync(x => x.Id == id);
            var result = new EvaluationScoreEditViewModel
            {
                Rate = dbModel.Rate,
                Description = dbModel.Description,
                Id = dbModel.Id,
            };

            return result;
        }

        public async Task<bool> RestoreAsync(EvaluationScoreRestoreViewModel model)
        {
            var result = await this.db.EvaluationScores.FirstOrDefaultAsync(x => x.Id == model.Id);
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
