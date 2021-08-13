namespace HCM.Web.ViewModels.ManageUser
{
    using HCM.Web.ViewModels.Employee;
    using HCM.Web.ViewModels.Role;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class ManageUserViewBaseModel : EmployeeInformationBaseViewModel
    {
        public IEnumerable<RoleDropDownViewModel> Roles { get; set; }
    }
}
