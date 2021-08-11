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
    using HCM.Web.ViewModels.PaymentInterval;
    using Microsoft.EntityFrameworkCore;


    public class PaymentIntervalService : IPaymentIntervalService
    {
        private readonly ApplicationDbContext db;

        public PaymentIntervalService(ApplicationDbContext db)
        {
            this.db = db;
        }

        public async Task<bool> AddAsync(PaymentIntervalAddViewModel model)
        {
            var dublicate = this.db.PaymentIntervals.Any(x => x.Type == model.Type);

            if (dublicate)
            {
                throw new ArgumentException(ExceptionMessages.CannotCreateDublicateObject);
            }

            var result = new PaymentInterval
            {
                Type = model.Type,
            };

            await this.db.PaymentIntervals.AddAsync(result);
            await this.db.SaveChangesAsync();

            return true;
        }

        public async Task<bool> DeleteAsync(PaymentIntervalDeleteViewModel model)
        {
            var result = await this.db.PaymentIntervals.FirstOrDefaultAsync(x => x.Id == model.Id);
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

        public async Task<bool> EditAsync(PaymentIntervalEditViewModel model)
        {
            var result = await this.db.PaymentIntervals.FirstOrDefaultAsync(x => x.Id == model.Id);
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

        public async Task<ICollection<PaymentIntervalViewModel>> GetAllAsync()
        {
            var result = await this.db.PaymentIntervals.Select(x => new PaymentIntervalViewModel
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

        public async Task<PaymentIntervalEditViewModel> GetAsync(int id)
        {
            var dbModel = await this.db.PaymentIntervals.FirstOrDefaultAsync(x => x.Id == id);
            var result = new PaymentIntervalEditViewModel
            {
                Type = dbModel.Type,
                Id = dbModel.Id,
            };

            return result;
        }

        public async Task<bool> RestoreAsync(PaymentIntervalRestoreViewModel model)
        {
            var result = await this.db.PaymentIntervals.FirstOrDefaultAsync(x => x.Id == model.Id);
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

        public async Task<ICollection<PaymentIntervalDropDownViewModel>> GetAllAsDropDownAsync()
        {
            return await this.db.PaymentIntervals.Select(x => new PaymentIntervalDropDownViewModel { Id = x.Id, Type = x.Type }).ToArrayAsync();
        }
    }
}
