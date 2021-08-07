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
    using HCM.Web.ViewModels.Currency;
    using Microsoft.EntityFrameworkCore;

    public class CurrencyService : ICurrencyService
    {
        private readonly ApplicationDbContext db;

        public CurrencyService(ApplicationDbContext db)
        {
            this.db = db;
        }

        public async Task<bool> AddAsync(CurrencyAddViewModel model)
        {
            var dublicate = this.db.Currencies.Any(x => x.Description == model.Description || x.Abbreviation == model.Abbreviation);

            if (dublicate)
            {
                throw new ArgumentException(ExceptionMessages.CannotCreateDublicateObject);
            }

            var result = new Currency
            {
                Abbreviation = model.Abbreviation,
                Description = model.Description,
            };

            await this.db.Currencies.AddAsync(result);
            await this.db.SaveChangesAsync();

            return true;
        }

        public async Task<bool> DeleteAsync(CurrencyDeleteViewModel model)
        {
            var result = await this.db.Currencies.FirstOrDefaultAsync(x => x.Id == model.Id);
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

        public async Task<bool> EditAsync(CurrencyEditViewModel model)
        {
            var result = await this.db.Currencies.FirstOrDefaultAsync(x => x.Id == model.Id);
            if (result != null)
            {
                if (result.IsDeleted)
                {
                    throw new ArgumentException(ExceptionMessages.CannotEditDeletedObject);
                }

                result.Abbreviation = model.Abbreviation;
                result.Description = model.Description;
                result.ModifiedOn = DateTime.UtcNow;
                await this.db.SaveChangesAsync();
                return true;
            }

            return false;
        }

        public async Task<ICollection<CurrencyViewModel>> GetAllAsync()
        {
            var result = await this.db.Currencies.Select(x => new CurrencyViewModel
            {
                Abbreviation = x.Abbreviation,
                Description = x.Description,
                Id = x.Id,
                CreatedOn = x.CreatedOn,
                ModifiedOn = x.ModifiedOn,
                DeletedOn = x.DeletedOn,
                IsDeleted = x.IsDeleted,
            }).ToListAsync();

            return result;
        }

        public async Task<CurrencyEditViewModel> GetAsync(int id)
        {
            var dbModel = await this.db.Currencies.FirstOrDefaultAsync(x => x.Id == id);
            var result = new CurrencyEditViewModel
            {
                Abbreviation = dbModel.Abbreviation,
                Description = dbModel.Description,
                Id = dbModel.Id,
            };

            return result;
        }

        public async Task<bool> RestoreAsync(CurrencyRestoreViewModel model)
        {
            var result = await this.db.Currencies.FirstOrDefaultAsync(x => x.Id == model.Id);
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

        public ICollection<CurrencyDropDownViewModel> GetCurrenciesAsDropDown()
        {
            return this.db.Currencies.Select(x => new CurrencyDropDownViewModel { Id = x.Id, Description = x.Description }).ToArray();
        }
    }
}
