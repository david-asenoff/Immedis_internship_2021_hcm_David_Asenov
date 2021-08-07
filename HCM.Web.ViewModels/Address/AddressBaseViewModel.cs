using HCM.Data.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace HCM.Web.ViewModels.Address
{
    public abstract class AddressBaseViewModel
    {
        /// <summary>
        /// Gets or sets currency description.
        /// </summary>
        [Display(Name = GlobalConstants.LocationDisplay)]
        [Required(ErrorMessage = GlobalConstants.LocationIsRequired)]
        public string Location { get; set; }

        public string Id { get; set; }
    }
}
