﻿namespace HCM.Services.Contracts
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using HCM.Data;
    using HCM.Data.Common;
    using HCM.Data.Models;
    using HCM.Web.ViewModels.Gender;
    using HCM.Web.ViewModels.Summary;
    using Microsoft.EntityFrameworkCore;

    public class DashboardService : IDashboardService
    {
        private readonly ApplicationDbContext db;

        public DashboardService(ApplicationDbContext db)
        {
            this.db = db;
        }

        public async Task<ICollection<EmployeeContractSummaryViewModel>> GetEmployeeAllContractsSummaryAsync(string username)
        {
            var result = await this.db.EmployeeContracts
                 .Include(x => x.Department)
                 .Include(c => c.Department.Company)
                 .Include(x => x.Possition)
                 .Include(x => x.Salary)
                 .Include(x => x.Salary.Currency)
                 .Include(x => x.User)
                 .Where(x => x.User.Username == username && x.EndDate == null)
                 .OrderByDescending(x => x.CreatedOn)
                 .Select(x => new EmployeeContractSummaryViewModel
                 {
                     UserId = x.UserId,
                     CompanyName = x.Department.Company.Name,
                     PaidLeavesUsed = x.User.RequestedLeaves
                                        .Where(x => x.IsPaidLeave == true)
                                        .Select(x => (x.EndDate - x.StartDate).Days),
                     UnpaidLeavesUsed = x.User.RequestedLeaves
                                        .Where(x => x.IsPaidLeave == false)
                                        .Select(x => (x.EndDate - x.StartDate).Days),
                     PaidLeavesAllowed = x.PaidLeavesAllowedPerYear,
                     UnPaidLeavesAllowed = x.UnpaidLeavesAllowedPerYear,
                     GrossSalary = x.Salary.GrossSalary,
                     NetSalary = x.Salary.NetSalary,
                     SalaryAbbreviation = x.Salary.Currency.Abbreviation,
                 }).ToListAsync();
            return result;
        }

        public async Task<ICollection<ManagerCompanySummaryViewModel>> GetManagementSummaryAsync()
        {
            var result = await this.db.Companies
                .Include(x => x.Departments)
                .ThenInclude(x => x.EmployeeContracts)
                .ThenInclude(x => x.Salary)
                .Include(x => x.OrderedProjects)
                .ThenInclude(x => x.ProjectStatuses)
                .ThenInclude(x => x.ProjectStatusCategory)
                 .Select(x => new ManagerCompanySummaryViewModel
                 {
                     CompanyName = x.Name,
                     EffectiveContractsCount = x.Departments.Select(x => x.EmployeeContracts.Where(x => x.EndDate == null)).Count(),
                     ConcludedContractsCount = x.Departments.Select(x => x.EmployeeContracts.Where(x => x.EndDate != null)).Count(),
                     ProjectsCount = x.OrderedProjects.Count(),
                     ProjectsWithCompletedStatus = x.OrderedProjects.Select(x => x.ProjectStatuses.Select(x => x.ProjectStatusCategory.Type == "completed")).Count(),

                     // To do: Salary abbreviation
                     // To do: use Group by Department, in order to take average salary for every department separately
                     //AverageSalary = x.Departments
                     //.Select(ec => ec.EmployeeContracts.Select(x => x.Salary.GrossSalary).Average()).Average(),
                     TopProjectName = x.OrderedProjects.OrderByDescending(x => x.FinalBudget).Select(x => x.Name).FirstOrDefault(),
                     TopProjectFinalBudget = x.OrderedProjects.OrderByDescending(x => x.FinalBudget).Select(x => x.FinalBudget).FirstOrDefault(),
                     TopProjectEmlpoyeesCount = x.OrderedProjects.OrderByDescending(x => x.FinalBudget).Select(x => x.ProjectUsers).FirstOrDefault().Count(),
                 }).ToListAsync();

            return result;
        }
    }
}