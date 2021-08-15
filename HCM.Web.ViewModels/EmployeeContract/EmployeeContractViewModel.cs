using HCM.Web.ViewModels.Employee;

namespace HCM.Web.ViewModels.EmployeeContract
{
    public class EmployeeContractViewModel : EmployeeContractViewBaseModel
    {
        public EmployeeInformationBaseViewModel Employee { get; set; }
    }
}