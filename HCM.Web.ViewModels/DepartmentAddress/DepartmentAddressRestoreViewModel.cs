namespace HCM.Web.ViewModels.DepartmentAddress
{
    using HCM.Web.ViewModels.DepartmentAddressAddress;
    using System;
    public class DepartmentAddressRestoreViewModel : DepartmentAddressBaseViewModel
    {
        public DateTime? DeletedOn { get; set; }

        public string Id { get; set; }
    }
}