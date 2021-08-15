namespace HCM.Services.Contracts
{
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using HCM.Data.Models;
    using HCM.Web.ViewModels.Salary;
    using HCM.Web.ViewModels.Summary;

    public interface IDashboardService
    {
        Task<ICollection<EmployeeContractSummaryViewModel>> GetEmployeeAllContractsSummaryAsync(string username);

        Task<ICollection<ManagerCompanySummaryViewModel>> GetManagementSummaryAsync();
    }
}
