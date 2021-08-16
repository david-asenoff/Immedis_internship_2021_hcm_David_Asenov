using System.Collections.Generic;

namespace HCM.Web.ViewModels.Summary
{
    public class EmployeeContractSummaryViewModel
    {
        public string UserId { get; set; }

        public string CompanyName { get; set; }

        public IEnumerable<int> PaidLeavesUsed { get; set; }

        public int PaidLeavesAllowed { get; set; }

        public IEnumerable<int> UnpaidLeavesUsed { get; set; }

        public int UnPaidLeavesAllowed { get; set; }

        public decimal GrossSalary { get; set; }

        public decimal NetSalary { get; set; }

        public string SalaryAbbreviation { get; set; }
    }
}
