namespace HCM.Web.ViewModels.Summary
{
    public class ManagerCompanySummaryViewModel
    {
        public string CompanyName { get; set; }

        public int LeavesApproved { get; set; }

        public int LeavesRequested { get; set; }

        public int EffectiveContractsCount { get; set; }

        public int ConcludedContractsCount { get; set; }

        public int ProjectsCount { get; set; }

        public int ProjectsWithFinishedStatus { get; set; }

        public int AverageSalary { get; set; }

        public int LowestSalary { get; set; }

        public int HighestSalary { get; set; }

        public int TopProjectName { get; set; }

        public int TopProjectEstimatedBudget { get; set; }

        public int TopProjectFinalBudget { get; set; }

        public int TopProjectEmlpoyeesCount { get; set; }
    }
}
