using HCM.Web.ViewModels.DepartmentAddressAddress;
using System;

namespace HCM.Web.ViewModels.DepartmentAddress
{
    public class DepartmentAddressRestoreViewModel : DepartmentAddressBaseViewModel
    {
        public DateTime? DeletedOn { get; set; }

        public string Id { get; set; }
    }
}