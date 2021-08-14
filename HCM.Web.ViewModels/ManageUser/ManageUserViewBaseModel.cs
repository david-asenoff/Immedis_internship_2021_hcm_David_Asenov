using HCM.Web.ViewModels.Employee;
using HCM.Web.ViewModels.Role;
using System.Collections.Generic;

namespace HCM.Web.ViewModels.ManageUser
{
    public class ManageUserViewBaseModel : EmployeeInformationBaseViewModel
    {
        public IEnumerable<RoleDropDownViewModel> Roles { get; set; }
    }
}
