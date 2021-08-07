namespace HCM.Services
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using HCM.Data;
    using HCM.Data.Models;
    using HCM.Services.Contracts;
    using HCM.Web.ViewModels.Company;
    using HCM.Web.ViewModels.Department;
    using Microsoft.EntityFrameworkCore;

    public class DepartmentService : IDepartmentService
    {
        private readonly ApplicationDbContext db;

        public DepartmentService(ApplicationDbContext db)
        {
            this.db = db;
        }

        public async Task<bool> AddAsync(DepartmentAddViewModel model)
        {
            var company = this.db.Companies.FirstOrDefault(x => x.Id == model.CompanyId);

            var result = new Department
            {
                Name = model.Name,
                Company = company,
            };

            await this.db.Departments.AddAsync(result);

            await this.db.SaveChangesAsync();

            return true;
        }

        public async Task<bool> DeleteAsync(DepartmentDeleteViewModel model)
        {
            var result = await this.db.Departments.FirstOrDefaultAsync(x => x.Id == model.Id);
            if (result != null)
            {
                result.IsDeleted = true;
                result.DeletedOn = DateTime.UtcNow;
                await this.db.SaveChangesAsync();
                return true;
            }

            return false;
        }

        public async Task<bool> EditAsync(DepartmentEditViewModel model)
        {
            var department = await this.db.Departments.FirstOrDefaultAsync(x => x.Id == model.Id);
            var company = this.db.Companies.FirstOrDefault(x => x.Id == model.CompanyId);

            if (department != null)
            {
                department.Name = model.Name;

                department.Company = company;

                department.ModifiedOn = DateTime.UtcNow;

                await this.db.SaveChangesAsync();
                return true;
            }

            return false;
        }

        public async Task<ICollection<DepartmentViewModel>> GetAllAsync()
        {
            var result = await this.db.Departments
                .Include(x => x.Company)
                .Include(x => x.DepartmentManager)
                .Include(x => x.DepartmentDeputyManager)
                .Select(x => new DepartmentViewModel
                {
                    Id = x.Id,
                    Name = x.Name,
                    CompanyId = x.Company.Id,
                    CreatedOn = x.CreatedOn,
                    ModifiedOn = x.ModifiedOn,
                    DeletedOn = x.DeletedOn,
                    IsDeleted = x.IsDeleted,
                    CompanyName = x.Company.Name,
                }).ToListAsync();

            return result;
        }

        public async Task<DepartmentEditViewModel> GetAsync(string id)
        {
            var dbModel = await this.db.Departments
                .Include(x => x.Company)
                .Include(x => x.DepartmentManager)
                .Include(x => x.DepartmentDeputyManager)
                .FirstOrDefaultAsync(x => x.Id == id);
            var result = new DepartmentEditViewModel
            {
                Id = dbModel.Id,
                Name = dbModel.Name,
                CompanyId = dbModel.Company.Id,
            };

            return result;
        }

        public async Task<bool> RestoreAsync(DepartmentRestoreViewModel model)
        {
            var result = await this.db.Departments.FirstOrDefaultAsync(x => x.Id == model.Id);
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
