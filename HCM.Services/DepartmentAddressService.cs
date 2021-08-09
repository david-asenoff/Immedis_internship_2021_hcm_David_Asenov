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
    using HCM.Web.ViewModels.DepartmentAddress;
    using Microsoft.EntityFrameworkCore;

    public class DepartmentAddressService : IDepartmentAddressService
    {
        private readonly ApplicationDbContext db;

        public DepartmentAddressService(ApplicationDbContext db)
        {
            this.db = db;
        }

        public async Task<bool> AddAsync(DepartmentAddressAddViewModel model)
        {
            var dublicate = this.db.DepartmentAddresses.Any(x => x.DepartmentId == model.DepartmentId && x.AddressId == model.AddressId);

            if (dublicate)
            {
                throw new ArgumentException(ExceptionMessages.CannotCreateDublicateObject);
            }

            var department = this.db.Departments.FirstOrDefault(x => x.Id == model.DepartmentId);
            var address = this.db.Addresses.FirstOrDefault(x => x.Id == model.AddressId);

            var result = new DepartmentAddress
            {
                Department = department,
                Address = address,
            };

            await this.db.DepartmentAddresses.AddAsync(result);

            await this.db.SaveChangesAsync();

            return true;
        }

        public async Task<bool> DeleteAsync(DepartmentAddressDeleteViewModel model)
        {
            var result = await this.db.DepartmentAddresses.FirstOrDefaultAsync(x => x.Id == model.Id);
            if (result != null)
            {
                result.IsDeleted = true;
                result.DeletedOn = DateTime.UtcNow;
                await this.db.SaveChangesAsync();
                return true;
            }

            return false;
        }

        public async Task<bool> EditAsync(DepartmentAddressEditViewModel model)
        {
            var departmentAddress = await this.db.DepartmentAddresses.FirstOrDefaultAsync(x => x.Id == model.Id);
            var department = this.db.Departments.FirstOrDefault(x => x.Id == model.DepartmentId);
            var address = this.db.Addresses.FirstOrDefault(x => x.Id == model.AddressId);

            if (departmentAddress != null && department != null && address != null)
            {
                departmentAddress.Address = address;

                departmentAddress.Department = department;

                departmentAddress.ModifiedOn = DateTime.UtcNow;

                await this.db.SaveChangesAsync();
                return true;
            }

            return false;
        }

        public async Task<ICollection<DepartmentAddressViewModel>> GetAllAsync()
        {
            var result = await this.db.DepartmentAddresses
                .Include(x => x.Department)
                .Include(x => x.Department.Company)
                .Include(x => x.Address)
                .Select(x => new DepartmentAddressViewModel
                {
                    Id = x.Id,

                    DepartmentId = x.DepartmentId,
                    DepartmentName = x.Department.Name,

                    AddressId = x.AddressId,
                    AddressLocation = x.Address.Location,

                    CompanyId = x.Department.Company.Id,
                    CompanyName = x.Department.Company.Name,

                    CreatedOn = x.CreatedOn,
                    ModifiedOn = x.ModifiedOn,
                    DeletedOn = x.DeletedOn,
                    IsDeleted = x.IsDeleted,
                }).ToListAsync();

            return result;
        }

        public async Task<DepartmentAddressEditViewModel> GetAsync(string id)
        {
            var dbModel = await this.db.DepartmentAddresses
                .Include(x => x.Department)
                .Include(x => x.Department.Company)
                .Include(x => x.Address)
                .FirstOrDefaultAsync(x => x.Id == id);
            var result = new DepartmentAddressEditViewModel
            {
                Id = dbModel.Id,

                DepartmentId = dbModel.DepartmentId,
                DepartmentName = dbModel.Department.Name,

                AddressId = dbModel.AddressId,
                AddressLocation = dbModel.Address.Location,

                CompanyId = dbModel.Department.Company.Id,
                CompanyName = dbModel.Department.Company.Name,
            };

            return result;
        }

        public async Task<bool> RestoreAsync(DepartmentAddressRestoreViewModel model)
        {
            var result = await this.db.DepartmentAddresses.FirstOrDefaultAsync(x => x.Id == model.Id);
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
