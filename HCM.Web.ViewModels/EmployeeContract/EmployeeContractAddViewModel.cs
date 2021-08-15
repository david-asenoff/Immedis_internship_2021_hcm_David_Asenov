using HCM.Web.ViewModels.Employee;
using System.Collections.Generic;

namespace HCM.Web.ViewModels.EmployeeContract
{
    public class EmployeeContractAddViewModel : EmployeeContractViewBaseModel
    {
        public EmployeeContractAddViewModel()
        {
            Employees = new List<EmployeeDropDownViewModel>();
        }
        public string UserId { get; set; }

        public ICollection<EmployeeDropDownViewModel> Employees { get; set; }
    }
}