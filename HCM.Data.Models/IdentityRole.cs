namespace HCM.Data
{
    using System.ComponentModel.DataAnnotations;
    using HCM.Common;
    using HCM.Data.Common;

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