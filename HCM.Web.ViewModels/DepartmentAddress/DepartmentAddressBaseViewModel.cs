namespace HCM.Web.ViewModels.DepartmentAddressAddress
{
    using HCM.Web.ViewModels.Address;
    using HCM.Web.ViewModels.Department;
    using System.Collections.Generic;

    public abstract class DepartmentAddressBaseViewModel
    {
        public string AddressLocation { get; set; }

        public string AddressId { get; set; }

        public string DepartmentId { get; set; }

        public string DepartmentName { get; set; }

        public string CompanyId { get; set; }

        public string CompanyName { get; set; }

        public IEnumerable<DepartmentDropDownViewModel> Departments { get; set; }

        public IEnumerable<AddressDropDownViewModel> Addresses { get; set; }
    }
}
