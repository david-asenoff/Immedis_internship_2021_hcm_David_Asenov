using HCM.Data;
using HCM.Data.Common;
using HCM.Data.Models;
using HCM.Services.Contracts;
using HCM.Web.ViewModels.Employee;
using HCM.Web.ViewModels.EmployeeTrainings;
using HCM.Web.ViewModels.EvaluationScore;
using HCM.Web.ViewModels.Training;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HCM.Services
{
    public class EmployeeTrainingService : IEmployeeTrainingService
    {
        private readonly ApplicationDbContext db;
        private readonly IUsersService usersService;
        private readonly ITrainingService trainingService;

        public EmployeeTrainingService(ApplicationDbContext db, IUsersService usersService, ITrainingService trainingService)
        {
            this.db = db;
            this.usersService = usersService;
            this.trainingService = trainingService;
        }

        public async Task<bool> AddAsync(string trainingId, string employeeId)
        {
            var dublicate = this.db.TrainingUsers.Any(x => x.TrainingId == trainingId && x.UserId == employeeId);

            if (dublicate)
            {
                throw new ArgumentException(ExceptionMessages.CannotCreateDublicateObject);
            }

            await db.TrainingUsers.AddAsync(new TrainingUser
            {
                TrainingId = trainingId,
                UserId = employeeId,
            });
            await db.SaveChangesAsync();
            return true;
        }

        public async Task<bool> DeleteAsync(string trainingId, string employeeId)
        {
            var doesExist = this.db.TrainingUsers.Any(x => x.TrainingId == trainingId && x.UserId == employeeId);

            if (!doesExist)
            {
                throw new ArgumentException("Emlpoyee is not added to this training, therefore cannot be deleted");
            }

            var trainingUser = this.db.TrainingUsers.FirstOrDefault(x => x.TrainingId == trainingId && x.UserId == employeeId);
            this.db.TrainingUsers.Remove(trainingUser);
            await db.SaveChangesAsync();
            return true;
        }

        public async Task<EmployeeTrainingsViewModel> GetAsync(string trainingId)
        {
            var training = await db.Trainings
                             .Select(t => new TrainingEditViewModel
                             {
                                 Id = t.Id,
                                 Description = t.Description,
                                 Name = t.Name,
                                 StartDate = t.StartDate,
                                 EndDate = t.EndDate,
                                 TotalHours = t.TotalHours,
                             }).FirstOrDefaultAsync(x => x.Id == trainingId);

            var allParticipants = await db.TrainingUsers
                .Where(tu => tu.TrainingId == trainingId)
                .Select(x=> new TrainingUserViewModel
                {
                    UserId = x.UserId,
                    TrainingId = x.TrainingId,
                })
                .ToListAsync();

            var employees = await db.Users
                .Select(x => new EmployeeInformationBaseViewModel
                {
                    FirstName = x.FirstName,
                    MiddleName = x.MiddleName,
                    LastName = x.LastName,
                    Gender = x.GenderId,
                    PhoneNumber = x.PhoneNumber,
                    Email = x.Email,
                    Username = x.Username,
                    UserId = x.Id,
                    DateOfBirth = x.DateOfBirth,
                    AvatarUrl = x.Portrait,
                    IdentityRoleId = x.IdentityRoleId,
                    IdentityRoleType = x.Role.Type,
                    IsBanned = x.IsBanned,
                }).ToListAsync();

            var result = new EmployeeTrainingsViewModel
            {
                Training = training,
                Employees = employees,
                AllParticipants = allParticipants,
            };

            return result;
        }
    }
}
