namespace HCM.Services.Contracts
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using HCM.Data;
    using HCM.Data.Common;
    using HCM.Data.Models;
    using HCM.Web.ViewModels.RequestedLeave;
    using HCM.Web.ViewModels.Manager;
    using Microsoft.EntityFrameworkCore;

    public class RequestedLeavesService : IRequestedLeavesService
    {
        private readonly ApplicationDbContext db;
        private readonly IUsersService usersService;

        public RequestedLeavesService(ApplicationDbContext db, IUsersService usersService)
        {
            this.db = db;
            this.usersService = usersService;
        }

        public async Task<bool> AddAsync(RequestedLeaveAddViewModel model, string userName)
        {
            var dublicate = this.db.RequestedLeaves.Any(x => x.StartDate == model.StartDate && x.EndDate == model.EndDate);

            if (dublicate)
            {
                throw new ArgumentException(ExceptionMessages.CannotCreateDublicateObject);
            }

            var user = await this.usersService.GetUserByUserName(userName);

            var result = new RequestedLeave
            {
                StartDate = model.StartDate,
                EndDate = model.EndDate,
                IsPaidLeave = model.IsPaidLeave,
                RequestedByUser = user,
            };

            await this.db.RequestedLeaves.AddAsync(result);
            await this.db.SaveChangesAsync();

            return true;
        }

        public async Task<bool> DeleteAsync(RequestedLeaveDeleteViewModel model, string userName)
        {
            var result = await this.db.RequestedLeaves.FirstOrDefaultAsync(x => x.Id == model.Id);
            if (result != null)
            {
                if (result.IsDeleted)
                {
                    throw new ArgumentException(ExceptionMessages.CannotDeletedAnAlreadyDeletedObject);
                }

                // If not pending for approval, and was revised by manager cannot be deleted
                if (result.IsDeleted != null)
                {
                    throw new ArgumentException("Cannot delete Leave Request. It was already revised by a Manager.");
                }

                var user = await this.usersService.GetUserByUserName(userName);

                IsValidRequest(result, user);

                result.IsDeleted = true;
                result.DeletedOn = DateTime.UtcNow;
                await this.db.SaveChangesAsync();
                return true;
            }

            return false;
        }

        public async Task<bool> EditAsync(RequestedLeaveEditViewModel model, string userName)
        {
            var result = await this.db.RequestedLeaves.FirstOrDefaultAsync(x => x.Id == model.Id);
            if (result != null)
            {
                if (result.IsDeleted)
                {
                    throw new ArgumentException(ExceptionMessages.CannotEditDeletedObject);
                }

                // If not pending for approval, and was revised by manager cannot be edited
                if (result.IsDeleted != null)
                {
                    throw new ArgumentException("Cannot edit Leave Request. It was already revised by a Manager.");
                }

                var user = await this.usersService.GetUserByUserName(userName);

                IsValidRequest(result, user);

                result.StartDate = model.StartDate;
                result.EndDate = model.EndDate;
                result.IsPaidLeave = model.IsPaidLeave;
                result.ModifiedOn = DateTime.UtcNow;
                await this.db.SaveChangesAsync();
                return true;
            }

            return false;
        }

        /// <summary>
        /// Gets all requested leaves made from a user.
        /// </summary>
        /// <param name="userName">The username of a user which serves to identify him.</param>
        /// <returns>Collection of all requested leaves made by a user.</returns>
        public async Task<ICollection<RequestedLeaveViewModel>> GetAllAsync(string userName)
        {
            var user = await this.usersService.GetUserByUserName(userName);

            var result = await this.db.RequestedLeaves
                .Include(x => x.RevisedByManager)
                .Where(x => x.RequestedByUserId == user.Id)
                .OrderByDescending(x => x.CreatedOn)
                .Select(x => new RequestedLeaveViewModel
                {
                    Id = x.Id,
                    StartDate = x.StartDate,
                    EndDate = x.EndDate,
                    IsApproved = x.IsApproved,
                    IsPaidLeave = x.IsPaidLeave,
                    CreatedOn = x.CreatedOn,
                    ModifiedOn = x.ModifiedOn,
                    IsDeleted = x.IsDeleted,
                    DeletedOn = x.DeletedOn,
                    Manager = new ManagerNamesViewModel
                    {
                        FirstName = x.RevisedByManager.FirstName,
                        LastName = x.RevisedByManager.LastName,
                        Id = x.RevisedByManager.Id,
                    },
                }).ToListAsync();

            return result;
        }

        public async Task<RequestedLeaveEditViewModel> GetAsync(string id, string userName)
        {
            var dbModel = await this.db.RequestedLeaves.FirstOrDefaultAsync(x => x.Id == id);

            var user = await this.usersService.GetUserByUserName(userName);

            if (user.Id != dbModel.RequestedByUserId)
            {
                throw new ArgumentException("Cannot get a Requested leave of another user");
            }

            var result = new RequestedLeaveEditViewModel
            {
                Id = dbModel.Id,
                StartDate = dbModel.StartDate,
                EndDate = dbModel.EndDate,
                IsApproved = dbModel.IsApproved,
                IsPaidLeave = dbModel.IsPaidLeave,
            };

            return result;
        }

        public async Task<bool> RestoreAsync(RequestedLeaveRestoreViewModel model, string userName)
        {
            var result = await this.db.RequestedLeaves.FirstOrDefaultAsync(x => x.Id == model.Id);
            var user = await this.usersService.GetUserByUserName(userName);

            IsValidRequest(result, user);

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

        private static void IsValidRequest(RequestedLeave dbModel, User user)
        {
            if (user.Id != dbModel.RequestedByUserId)
            {
                throw new ArgumentException("Cannot delete a Requested leave of another user");
            }

            if (dbModel.IsApproved != false)
            {
                throw new ArgumentException("Cannot update revised Requested leave by Manager");
            }
        }
    }
}