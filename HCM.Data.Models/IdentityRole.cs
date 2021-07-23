namespace HCM.Data
{
    using HCM.Data.Common;
    using System.Collections.Generic;

    public class IdentityRole : BaseDeletableModel<int>
    {
        public IdentityRole()
        {
            this.IdentityUsers = new HashSet<IdentityUser>();
        }

        /// <summary>
        /// Gets or sets the type of an identity role.
        /// </summary>
        public string Type { get; set; }

        public virtual ICollection<IdentityUser> IdentityUsers { get; set; }
    }
}