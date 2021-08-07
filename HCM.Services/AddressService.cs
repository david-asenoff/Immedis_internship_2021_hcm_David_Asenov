using System;
using System.Collections.Generic;
using System.Text;

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
    using HCM.Web.ViewModels.Address;
    using Microsoft.EntityFrameworkCore;

    public class AddressService : IAddressService
    {
        private readonly ApplicationDbContext db;

        public AddressService(ApplicationDbContext db)
        {
            this.db = db;
        }

        public async Task<bool> AddAsync(AddressAddViewModel model)
        {
            var dublicate = this.db.Addresses.Any(x => x.Location == model.Location);

            if (dublicate)
            {
                throw new ArgumentException(ExceptionMessages.CannotCreateDublicateObject);
            }

            var result = new Address
            {
                Location = model.Location,
            };

            await this.db.Addresses.AddAsync(result);
            await this.db.SaveChangesAsync();

            return true;
        }

        public async Task<bool> DeleteAsync(AddressDeleteViewModel model)
        {
            var result = await this.db.Addresses.FirstOrDefaultAsync(x => x.Id == model.Id);
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

        public async Task<bool> EditAsync(AddressEditViewModel model)
        {
            var result = await this.db.Addresses.FirstOrDefaultAsync(x => x.Id == model.Id);
            if (result != null)
            {
                if (result.IsDeleted)
                {
                    throw new ArgumentException(ExceptionMessages.CannotEditDeletedObject);
                }

                result.Location = model.Location;
                result.ModifiedOn = DateTime.UtcNow;
                await this.db.SaveChangesAsync();
                return true;
            }

            return false;
        }

        public async Task<ICollection<AddressViewModel>> GetAllAsync()
        {
            var result = await this.db.Addresses.Select(x => new AddressViewModel
            {
                Location = x.Location,
                Id = x.Id,
                CreatedOn = x.CreatedOn,
                ModifiedOn = x.ModifiedOn,
                DeletedOn = x.DeletedOn,
                IsDeleted = x.IsDeleted,
            }).ToListAsync();

            return result;
        }

        public async Task<AddressEditViewModel> GetAsync(string id)
        {
            var dbModel = await this.db.Addresses.FirstOrDefaultAsync(x => x.Id == id);
            var result = new AddressEditViewModel
            {
                Location = dbModel.Location,
                Id = dbModel.Id,
            };

            return result;
        }

        public async Task<bool> RestoreAsync(AddressRestoreViewModel model)
        {
            var result = await this.db.Addresses.FirstOrDefaultAsync(x => x.Id == model.Id);
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
