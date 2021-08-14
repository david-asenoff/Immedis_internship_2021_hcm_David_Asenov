namespace HCM.Web.ViewModels.ManageUser
{
using HCM.Web.ViewModels.Employee;
using HCM.Web.ViewModels.Role;
using System.Collections.Generic;

    public class ManageUserViewBaseModel : EmployeeInformationBaseViewModel
    {
        public IEnumerable<RoleDropDownViewModel> Roles { get; set; }
    }
}
