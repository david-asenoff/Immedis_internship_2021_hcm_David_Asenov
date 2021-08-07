using System;

namespace HCM.Web.ViewModels.Company
{
    public class CompanyViewModel : CompanyBaseViewModel
    {
        public DateTime CreatedOn { get; set; }

        public DateTime? ModifiedOn { get; set; }

        public DateTime? DeletedOn { get; set; }

        public bool IsDeleted { get; set; }
    }
}
