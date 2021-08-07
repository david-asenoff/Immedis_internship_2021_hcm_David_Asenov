using HCM.Data.Common;
using System.ComponentModel.DataAnnotations;

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
