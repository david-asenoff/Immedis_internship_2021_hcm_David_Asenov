namespace HCM.Services.Contracts
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
                 .Include(x => x.Department.Company)
                 .Include(x => x.Possition)
                 .Include(x => x.Salary)
                 .Include(x => x.Salary.Currency)
                 .Include(x => x.User)
                 .Where(x => x.User.Username == username)
                 .OrderByDescending(x => x.CreatedOn)
                 .Select(x => new EmployeeContractSummaryViewModel
                 {
                     CompanyName = x.Department.Company.Name,
                 }).ToListAsync();
            return result;
        }

        public Task<ICollection<ManagerCompanySummaryViewModel>> GetManagementSummaryAsync()
        {
            throw new NotImplementedException();
        }
    }
}