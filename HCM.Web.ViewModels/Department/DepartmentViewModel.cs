namespace HCM.Web.ViewModels.Department
{
    using System;
    public class DepartmentViewModel : DepartmentBaseViewModel
    {
        public DateTime CreatedOn { get; set; }

        public DateTime? ModifiedOn { get; set; }

        public DateTime? DeletedOn { get; set; }

        public bool IsDeleted { get; set; }
    }
}
