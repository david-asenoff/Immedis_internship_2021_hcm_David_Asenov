namespace HCM.Services
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Threading.Tasks;
    using HCM.Data;
    using HCM.Data.Common;
    using HCM.Data.Models;
    using HCM.Services.Contracts;
    using HCM.Web.ViewModels.Company;
    using Microsoft.EntityFrameworkCore;

    public class CompanyService : ICompanyService
    {
        private readonly ApplicationDbContext db;

        private readonly string[] allowedExtensions = new[] { "jpg", "png", "gif", "jpeg" };

        public CompanyService(ApplicationDbContext db)
        {
            this.db = db;
        }

        public async Task<bool> AddAsync(
            CompanyAddViewModel model,
            string imagePath)
        {
            var dublicate = this.db.Companies.Any(x => x.Name == model.Name);

            if (dublicate)
            {
                throw new ArgumentException(ExceptionMessages.CannotCreateDublicateObject);
            }

            var result = new Company
            {
                AboutUs = model.AboutUs,
                Email = model.Email,
                Name = model.Name,
                PhoneNumber = model.PhoneNumber,
            };

            if (model.CompanyLogo != null)
            {
                Directory.CreateDirectory($"{imagePath}/companies/");

                var extension = Path.GetExtension(model.CompanyLogo.FileName).TrimStart('.');
                if (!this.allowedExtensions.Any(x => extension.EndsWith(x.ToLower())))
                {
                    throw new ArgumentException($"Invalid image extension {extension}");
                }

                var physicalPath = $"{imagePath}/companies/{result.Id}.{extension}";
                using Stream fileStream = new FileStream(physicalPath, FileMode.Create);
                await model.CompanyLogo.CopyToAsync(fileStream);

                result.Logo = $"/images/companies/{result.Id}.{extension}";
            }

            await this.db.Companies.AddAsync(result);
            await this.db.SaveChangesAsync();

            return true;
        }

        public async Task<bool> DeleteAsync(CompanyDeleteViewModel model)
        {
            var result = await this.db.Companies.FirstOrDefaultAsync(x => x.Id == model.Id);
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

        public async Task<bool> EditAsync(
            CompanyEditViewModel model,
            string imagePath)
        {
            var result = await this.db.Companies.FirstOrDefaultAsync(x => x.Id == model.Id);
            if (result != null)
            {
                if (result.IsDeleted)
                {
                    throw new ArgumentException(ExceptionMessages.CannotEditDeletedObject);
                }

                Directory.CreateDirectory($"{imagePath}/companies/");
                if (model.CompanyLogo != null)
                {
                    var extension = Path.GetExtension(model.CompanyLogo.FileName).TrimStart('.');
                    if (!this.allowedExtensions.Any(x => extension.EndsWith(x.ToLower())))
                    {
                        throw new ArgumentException($"Invalid image extension {extension}");
                    }

                    var physicalPath = $"{imagePath}/companies/{model.Id}.{extension}";
                    using Stream fileStream = new FileStream(physicalPath, FileMode.Create);
                    await model.CompanyLogo.CopyToAsync(fileStream);
                    result.Logo = $"/images/companies/{result.Id}.{extension}";
                }

                result.AboutUs = model.AboutUs;
                result.Email = model.Email;
                result.Name = model.Name;
                result.PhoneNumber = model.PhoneNumber;
                result.AboutUs = model.AboutUs;
                result.Email = model.Email;
                result.Name = model.Name;
                result.PhoneNumber = model.PhoneNumber;
                result.ModifiedOn = DateTime.UtcNow;
                await this.db.SaveChangesAsync();
                return true;
            }

            return false;
        }

        public async Task<ICollection<CompanyViewModel>> GetAllAsync()
        {
            var result = await this.db.Companies.Select(x => new CompanyViewModel
            {
                Id = x.Id,
                AboutUs = x.AboutUs,
                Email = x.Email,
                CompanyLogoUrl = x.Logo,
                Name = x.Name,
                PhoneNumber = x.PhoneNumber,
                CreatedOn = x.CreatedOn,
                ModifiedOn = x.ModifiedOn,
                DeletedOn = x.DeletedOn,
                IsDeleted = x.IsDeleted,
            }).ToListAsync();

            return result;
        }

        public async Task<CompanyEditViewModel> GetAsync(string id)
        {
            var dbModel = await this.db.Companies.FirstOrDefaultAsync(x => x.Id == id);
            var result = new CompanyEditViewModel
            {
                AboutUs = dbModel.AboutUs,
                Email = dbModel.Email,
                CompanyLogoUrl = dbModel.Logo,
                Name = dbModel.Name,
                PhoneNumber = dbModel.PhoneNumber,
                Id = dbModel.Id,
            };

            return result;
        }

        public async Task<bool> RestoreAsync(CompanyRestoreViewModel model)
        {
            var result = await this.db.Companies.FirstOrDefaultAsync(x => x.Id == model.Id);
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

        public async Task<ICollection<CompanyDropDownViewModel>> GetAllAsDropDownAsync()
        {
            return await this.db.Companies.Select(x => new CompanyDropDownViewModel { Id = x.Id, Name = x.Name }).ToArrayAsync();
        }
    }
}