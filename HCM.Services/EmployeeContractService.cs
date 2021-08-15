namespace HCM.Services.Contracts
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using HCM.Data;
    using HCM.Data.Common;
    using HCM.Data.Models;
    using HCM.Web.ViewModels.Employee;
    using HCM.Web.ViewModels.EmployeeContract;
    using HCM.Web.ViewModels.Salary;
    using Microsoft.EntityFrameworkCore;

    public class EmployeeContractService : IEmployeeContractService
    {
        private readonly ApplicationDbContext db;
        private readonly IUsersService usersService;
        private readonly ISalaryService salaryService;

        public EmployeeContractService(ApplicationDbContext db, IUsersService usersService, ISalaryService salaryService)
        {
            this.db = db;
            this.usersService = usersService;
            this.salaryService = salaryService;
        }

        public async Task<bool> EditAsync(EmployeeContractViewModel model)
        {
            var result = await this.db.EmployeeContracts.FirstOrDefaultAsync(x => x.UserId == model.Employee.UserId && x.Id == model.EmployeeContractId);
            if (result != null)
            {
                result.DepartmentId = model.DepartmentId;
                result.UserId = model.Employee.UserId;
                result.PossitionId = model.PositionId;
                result.StartDate = model.StartDate;
                result.EndDate = model.EndDate;
                result.StartOfTheWorkingHours = model.StartOfTheWorkingHours;
                result.EndOfTheWorkingHours = model.EndOfTheWorkingHours;
                result.AreWorkingHoursFlexible = model.AreWorkingHoursFlexible;
                result.IsContractTypeFullTime = model.IsContractTypeFullTime;
                result.PaidLeavesAllowedPerYear = model.PaidLeavesAllowedPerYear;
                result.UnpaidLeavesAllowedPerYear = model.UnpaidLeavesAllowedPerYear;

                var salary = await this.salaryService.EditAsync(new SalaryEditViewModel
                {
                    Id = result.SalaryId,
                    PaymentIntervalId = model.Salary.PaymentIntervalId,
                    PaymentIntervalType = model.Salary.PaymentIntervalType,
                    CurrencyId = model.Salary.CurrencyId,
                    CurrencyDescription = model.Salary.CurrencyDescription,
                    GrossSalary = model.Salary.GrossSalary,
                    NetSalary = model.Salary.NetSalary,
                });

                await this.db.SaveChangesAsync();
                return true;
            }

            return false;
        }

        public async Task<ICollection<EmployeeContractViewModel>> GetAllAsync()
        {
            var result = await this.db.EmployeeContracts
                .Include(x => x.Department)
                .Include(x => x.Department.Company)
                .Include(x => x.Salary)
                .Include(x => x.Salary.PaymentInterval)
                .Include(x => x.Possition)
                .Include(x => x.User)
                .Include(x => x.User.Gender)
                .OrderByDescending(x => x.CreatedOn)
                .Select(x => new EmployeeContractViewModel
                {
                    EmployeeContractId = x.Id,
                    DepartmentId = x.DepartmentId,
                    DepartmentName = x.Department.Name,
                    DepartmentCompanyName = x.Department.Company.Name,
                    Employee = new EmployeeInformationBaseViewModel
                    {
                        FirstName = x.User.FirstName,
                        LastName = x.User.LastName,
                        UserId = x.User.Id,
                        Gender = x.User.Gender.Type,
                        PhoneNumber = x.User.PhoneNumber,
                        Email = x.User.Email,
                        Username = x.User.Username,
                        AvatarUrl = x.User.Portrait,
                        IsBanned = x.User.IsBanned,
                        IdentityRoleType = x.User.Role.Type,
                    },
                    PositionName = x.Possition.Name,
                    PositionId = x.PossitionId,
                    Salary = new SalaryAddViewModel
                    {
                        GrossSalary = x.Salary.GrossSalary,
                        NetSalary = x.Salary.NetSalary,
                        PaymentIntervalType = x.Salary.PaymentInterval.Type,
                        PaymentIntervalId = x.Salary.PaymentInterval.Id,
                        CurrencyDescription = x.Salary.Currency.Description,
                        CurrencyId = x.Salary.Currency.Id,
                    },
                    StartDate = x.StartDate,
                    EndDate = x.EndDate,
                    StartOfTheWorkingHours = x.StartOfTheWorkingHours,
                    EndOfTheWorkingHours = x.EndOfTheWorkingHours,
                    AreWorkingHoursFlexible = x.AreWorkingHoursFlexible,
                    IsContractTypeFullTime = x.IsContractTypeFullTime,
                    PaidLeavesAllowedPerYear = x.PaidLeavesAllowedPerYear,
                    UnpaidLeavesAllowedPerYear = x.UnpaidLeavesAllowedPerYear,
                }).ToListAsync();

            return result;
        }

        public async Task<EmployeeContractViewModel> GetAsync(string id)
        {
            var dbModel = await this.db.EmployeeContracts
                .Include(x => x.Department)
                .Include(x => x.Department.Company)
                .Include(x => x.Salary)
                .Include(x => x.Salary.Currency)
                .Include(x => x.Salary.PaymentInterval)
                .Include(x => x.Possition)
                .Include(x => x.User)
                .Include(x => x.User.Role)
                .Include(x => x.User.Gender)
                .OrderByDescending(x => x.CreatedOn)
                .FirstOrDefaultAsync(x => x.Id == id);

            var result = new EmployeeContractViewModel
            {
                EmployeeContractId = dbModel.Id,
                DepartmentId = dbModel.DepartmentId,
                DepartmentName = dbModel.Department.Name,
                DepartmentCompanyName = dbModel.Department.Company.Name,
                Employee = new EmployeeInformationBaseViewModel
                {
                    FirstName = dbModel.User.FirstName,
                    LastName = dbModel.User.LastName,
                    UserId = dbModel.User.Id,
                    Gender = dbModel.User.Gender.Type,
                    PhoneNumber = dbModel.User.PhoneNumber,
                    Email = dbModel.User.Email,
                    Username = dbModel.User.Username,
                    AvatarUrl = dbModel.User.Portrait,
                    IsBanned = dbModel.User.IsBanned,
                    IdentityRoleType = dbModel.User.Role.Type,
                },
                Salary = new SalaryAddViewModel
                {
                    GrossSalary = dbModel.Salary.GrossSalary,
                    NetSalary = dbModel.Salary.NetSalary,
                    PaymentIntervalType = dbModel.Salary.PaymentInterval.Type,
                    PaymentIntervalId = dbModel.Salary.PaymentInterval.Id,
                    CurrencyDescription = dbModel.Salary.Currency.Description,
                    CurrencyId = dbModel.Salary.Currency.Id,
                },
                PositionName = dbModel.Possition.Name,
                PositionId = dbModel.PossitionId,
                StartDate = dbModel.StartDate,
                EndDate = dbModel.EndDate,
                StartOfTheWorkingHours = dbModel.StartOfTheWorkingHours,
                EndOfTheWorkingHours = dbModel.EndOfTheWorkingHours,
                AreWorkingHoursFlexible = dbModel.AreWorkingHoursFlexible,
                IsContractTypeFullTime = dbModel.IsContractTypeFullTime,
                PaidLeavesAllowedPerYear = dbModel.PaidLeavesAllowedPerYear,
                UnpaidLeavesAllowedPerYear = dbModel.UnpaidLeavesAllowedPerYear,
            };

            return result;
        }

        public async Task<bool> EndTheContractAsync(string contractId)
        {
            var result = await this.db.EmployeeContracts
                .Where(x => x.Id == contractId).FirstOrDefaultAsync();

            if (result == null)
            {
                if (result.IsDeleted)
                {
                    throw new ArgumentException("Cannot end a contract which already has an EndDate");
                }
            }

            result.EndDate = DateTime.UtcNow;
            await this.db.SaveChangesAsync();
            return true;
        }

        public async Task<ICollection<EmployeeContractViewModel>> GetAllByEmployeeIdAsync(string employeeId)
        {
            var result = await this.db.EmployeeContracts
                 .Include(x => x.Department)
                 .Include(x => x.Possition)
                 .Include(x => x.User)
                 .Where(x => x.UserId == employeeId)
                 .OrderByDescending(x => x.CreatedOn)
                 .Select(x => new EmployeeContractViewModel
                 {
                     DepartmentId = x.DepartmentId,
                     DepartmentName = x.Department.Name,
                     DepartmentCompanyName = x.Department.Company.Name,
                     Employee = new EmployeeInformationBaseViewModel
                     {
                         FirstName = x.User.FirstName,
                         LastName = x.User.LastName,
                         UserId = x.User.Id,
                         Gender = x.User.Gender.Type,
                         PhoneNumber = x.User.PhoneNumber,
                         Email = x.User.Email,
                         Username = x.User.Username,
                         AvatarUrl = x.User.Portrait,
                         IsBanned = x.User.IsBanned,
                         IdentityRoleType = x.User.Role.Type,
                     },
                     PositionId = x.PossitionId,
                     StartDate = x.StartDate,
                     EndDate = x.EndDate,
                     StartOfTheWorkingHours = x.StartOfTheWorkingHours,
                     EndOfTheWorkingHours = x.EndOfTheWorkingHours,
                     AreWorkingHoursFlexible = x.AreWorkingHoursFlexible,
                     IsContractTypeFullTime = x.IsContractTypeFullTime,
                     PaidLeavesAllowedPerYear = x.PaidLeavesAllowedPerYear,
                     UnpaidLeavesAllowedPerYear = x.UnpaidLeavesAllowedPerYear,
                 }).ToListAsync();

            return result;
        }

        public async Task<bool> CreateAsync(EmployeeContractAddViewModel model)
        {
            var employee = await this.usersService.GetUserByUserId(model.UserId);

            if (employee == null)
            {
                throw new ArgumentException("Cannot create emlpoyee contract. Invalid employee id.");
            }

            var salary = await this.salaryService.AddAsync(new SalaryAddViewModel
            {
                PaymentIntervalId = model.Salary.PaymentIntervalId,
                PaymentIntervalType = model.Salary.PaymentIntervalType,
                CurrencyId = model.Salary.CurrencyId,
                CurrencyDescription = model.Salary.CurrencyDescription,
                GrossSalary = model.Salary.GrossSalary,
                NetSalary = model.Salary.NetSalary,
            });
            var contract = new EmployeeContract
            {
                DepartmentId = model.DepartmentId,
                PossitionId = model.PositionId,
                StartDate = model.StartDate,
                EndDate = model.EndDate,
                StartOfTheWorkingHours = model.StartOfTheWorkingHours,
                EndOfTheWorkingHours = model.EndOfTheWorkingHours,
                AreWorkingHoursFlexible = model.AreWorkingHoursFlexible,
                IsContractTypeFullTime = model.IsContractTypeFullTime,
                PaidLeavesAllowedPerYear = model.PaidLeavesAllowedPerYear,
                UnpaidLeavesAllowedPerYear = model.UnpaidLeavesAllowedPerYear,
                Salary = salary,
                User = employee,
            };
            await db.EmployeeContracts.AddAsync(contract);
            await db.SaveChangesAsync();
            return true;
        }
    }
}