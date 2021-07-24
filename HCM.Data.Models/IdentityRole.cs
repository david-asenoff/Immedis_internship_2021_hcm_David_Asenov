namespace HCM.Data
{
    using HCM.Common;
    using HCM.Data.Common;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class IdentityRole : BaseDeletableModel<int>
    {
        /// <summary>
        /// Gets or sets the type of an identity role.
        /// </summary>
        [Display(Name = GlobalConstants.IdentityRoleTypeDisplay)]
        [Required(ErrorMessage = GlobalConstants.IdentityRoleTypeIsRequired)]
        public string Type { get; set; }
    }
}