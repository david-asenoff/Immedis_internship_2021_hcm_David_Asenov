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
    using HCM.Web.ViewModels.Salary;
    using Microsoft.EntityFrameworkCore;

    public class SalaryService : ISalaryService
    {
        private readonly ApplicationDbContext db;

        public SalaryService(ApplicationDbContext db)
        {
            this.db = db;
        }

        public async Task<Salary> AddAsync(SalaryAddViewModel model)
        {
            var currency = this.db.Currencies.FirstOrDefault(x => x.Id == model.CurrencyId);
            var paymentInterval = this.db.PaymentIntervals.FirstOrDefault(x => x.Id == model.PaymentIntervalId);

            var result = new Salary
            {
                GrossSalary = model.GrossSalary,
                NetSalary = model.NetSalary,
                PaymentInterval = paymentInterval,
                Currency = currency,
            };

            await this.db.Salaries.AddAsync(result);

            await this.db.SaveChangesAsync();

            return result;
        }

        public async Task<bool> DeleteAsync(SalaryDeleteViewModel model)
        {
            var result = await this.db.Salaries.FirstOrDefaultAsync(x => x.Id == model.Id);
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

        public async Task<bool> EditAsync(SalaryEditViewModel model)
        {
            var salary = this.db.Salaries.FirstOrDefault(x => x.Id == model.Id);
            var currency = this.db.Currencies.FirstOrDefault(x => x.Id == model.CurrencyId);
            var paymentInterval = this.db.PaymentIntervals.FirstOrDefault(x => x.Id == model.PaymentIntervalId);

            if (salary != null &&
                currency != null &&
                paymentInterval != null)
            {
                salary.GrossSalary = model.GrossSalary;
                salary.NetSalary = model.NetSalary;
                salary.PaymentInterval = paymentInterval;
                salary.Currency = currency;
                salary.ModifiedOn = DateTime.UtcNow;

                await this.db.SaveChangesAsync();
                return true;
            }

            return false;
        }

        public async Task<ICollection<SalaryViewModel>> GetAllAsync()
        {
            var result = await this.db.Salaries
                .Include(x => x.PaymentInterval)
                .Include(x => x.Currency)
                .Select(x => new SalaryViewModel
                {
                    Id = x.Id,
                    GrossSalary = x.GrossSalary,
                    NetSalary = x.NetSalary,
                    PaymentIntervalType = x.PaymentInterval.Type,
                    CurrencyDescription = x.Currency.Description,
                    DeletedOn = x.DeletedOn,
                    IsDeleted = x.IsDeleted,
                }).ToListAsync();

            return result;
        }

        public async Task<SalaryEditViewModel> GetAsync(string id)
        {
            var dbModel = await this.db.Salaries
                .Include(x => x.PaymentInterval)
                .Include(x => x.Currency)
                .FirstOrDefaultAsync(x => x.Id == id);
            var result = new SalaryEditViewModel
            {
                Id = dbModel.Id,
                GrossSalary = dbModel.GrossSalary,
                NetSalary = dbModel.NetSalary,
                PaymentIntervalId = dbModel.PaymentInterval.Id,
                PaymentIntervalType = dbModel.PaymentInterval.Type,
                CurrencyDescription = dbModel.Currency.Description,
                CurrencyId = dbModel.Currency.Id,
            };

            return result;
        }

        public async Task<bool> RestoreAsync(SalaryRestoreViewModel model)
        {
            var result = await this.db.Salaries.FirstOrDefaultAsync(x => x.Id == model.Id);
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
