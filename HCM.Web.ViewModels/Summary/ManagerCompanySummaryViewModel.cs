using System.Collections.Generic;

namespace HCM.Web.ViewModels.Summary
{
    public class ManagerCompanySummaryViewModel
    {
        public string CompanyName { get; set; }

       public int ContractsCount { get; set; }

        public int ProjectsCount { get; set; }

        public int ProjectsWithCompletedStatus { get; set; }

        public string TopProjectName { get; set; }

        public decimal TopProjectFinalBudget { get; set; }
    }
}
