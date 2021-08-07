using System;
using System.Collections.Generic;
using System.Text;

namespace HCM.Web.ViewModels.Address
{
    public class AddressViewModel : AddressBaseViewModel
    {
        public DateTime CreatedOn { get; set; }

        public DateTime? ModifiedOn { get; set; }

        public DateTime? DeletedOn { get; set; }

        public bool IsDeleted { get; set; }
    }
}
