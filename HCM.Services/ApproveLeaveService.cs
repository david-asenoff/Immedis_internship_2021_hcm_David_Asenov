namespace HCM.Services.Contracts
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using HCM.Data;
    using HCM.Data.Common;
    using HCM.Web.ViewModels.ApproveLeave;
    using HCM.Web.ViewModels.Employee;
    using HCM.Web.ViewModels.Manager;
    using Microsoft.EntityFrameworkCore;

    public class ApproveLeaveService : IApproveLeaveService
    {
        private readonly ApplicationDbContext db;
        private readonly IUsersService usersService;

        public ApproveLeaveService(ApplicationDbContext db, IUsersService usersService)
        {
            this.db = db;
            this.usersService = usersService;
        }

        public async Task<bool> EditAsync(ApproveLeaveEditViewModel model, string managerUsername)
        {
            var result = await this.db.RequestedLeaves.FirstOrDefaultAsync(x => x.Id == model.Id);
            if (result != null)
            {
                if (result.IsDeleted)
                {
                    throw new ArgumentException(ExceptionMessages.CannotEditDeletedObject);
                }

                // To do: only manager from the same department that employee currently works may approve leave request.
                var manager = await this.usersService.GetUserByUserName(managerUsername);
                result.IsApproved = model.IsApproved;
                result.RevisedByManager = manager;
                await this.db.SaveChangesAsync();
                return true;
            }

            return false;
        }

        public async Task<ICollection<ApproveLeaveViewModel>> GetAllAsync()
        {
            var result = await this.db.RequestedLeaves
                .Where(x => x.IsDeleted == false)
                .Include(x => x.RequestedByUser)
                .OrderBy(x => x.IsApproved == false)
                .ThenByDescending(x => x.CreatedOn)
                .Select(x => new ApproveLeaveViewModel
                {
                    Id = x.Id,
                    StartDate = x.StartDate,
                    EndDate = x.EndDate,
                    IsApproved = x.IsApproved,
                    IsPaidLeave = x.IsPaidLeave,
                    CreatedOn = x.CreatedOn,
                    ModifiedOn = x.ModifiedOn,
                    DeletedOn = x.DeletedOn,
                    Manager = new ManagerNamesViewModel
                    {
                        FirstName = x.RevisedByManager.FirstName,
                        LastName = x.RevisedByManager.LastName,
                        Id = x.RevisedByManager.Id,
                    },
                    Employee = new EmployeeInformationBaseViewModel
                    {
                        FirstName = x.RequestedByUser.FirstName,
                        LastName = x.RequestedByUser.LastName,
                        UserId = x.RequestedByUser.Id,
                    },
                }).ToListAsync();

            return result;
        }

        public async Task<ApproveLeaveEditViewModel> GetAsync(string id)
        {
            var dbModel = await this.db.RequestedLeaves
                .Include(x => x.RequestedByUser)
                .Include(x => x.RequestedByUser.Gender)
                .Include(x => x.RequestedByUser.Role)
                .FirstOrDefaultAsync(x => x.Id == id);

            if (dbModel.IsDeleted)
            {
                throw new ArgumentException(ExceptionMessages.CannotEditDeletedObject);
            }

            var result = new ApproveLeaveEditViewModel
            {
                Id = dbModel.Id,
                StartDate = dbModel.StartDate,
                EndDate = dbModel.EndDate,
                IsApproved = dbModel.IsApproved,
                IsPaidLeave = dbModel.IsPaidLeave,
                Employee = new EmployeeInformationBaseViewModel
                {
                    FirstName = dbModel.RequestedByUser.FirstName,
                    LastName = dbModel.RequestedByUser.LastName,
                    UserId = dbModel.RequestedByUser.Id,
                    Gender = dbModel.RequestedByUser.Gender.Type,
                    PhoneNumber = dbModel.RequestedByUser.PhoneNumber,
                    Email = dbModel.RequestedByUser.Email,
                    Username = dbModel.RequestedByUser.Username,
                    DateOfBirth = dbModel.RequestedByUser.DateOfBirth,
                    AvatarUrl = dbModel.RequestedByUser.Portrait,
                    IsBanned = dbModel.RequestedByUser.IsBanned,
                    IdentityRoleType = dbModel.RequestedByUser.Role.Type,
                },
            };

            return result;
        }
    }
}