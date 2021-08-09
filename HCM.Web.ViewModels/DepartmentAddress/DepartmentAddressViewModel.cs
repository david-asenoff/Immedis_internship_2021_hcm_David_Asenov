namespace HCM.Web.ViewModels.DepartmentAddress
{
    using HCM.Web.ViewModels.DepartmentAddressAddress;
    using System;
    public class DepartmentAddressViewModel : DepartmentAddressBaseViewModel
    {
        public DateTime CreatedOn { get; set; }

        public DateTime? ModifiedOn { get; set; }

        public DateTime? DeletedOn { get; set; }

        public bool IsDeleted { get; set; }

        public string Id { get; set; }
    }
}
