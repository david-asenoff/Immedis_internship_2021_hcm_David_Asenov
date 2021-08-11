namespace HCM.Web.ViewModels.ManageUser
{
    using HCM.Web.ViewModels.Role;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class ManageUserViewBaseModel
    {
        public string UserId { get; set; }

        public string FirstName { get; set; }

        public string MiddleName { get; set; }

        public string LastName { get; set; }

        public string FullName => this.FirstName + " " + this.MiddleName + " " + LastName;

        public string Gender { get; set; }

        public string PhoneNumber { get; set; }

        public string Email { get; set; }

        public string Username { get; set; }

        public DateTime DateOfBirth { get; set; }

        [Required]
        public bool IsBanned { get; set; }

        [Required]
        public int IdentityRoleId { get; set; }

        public string IdentityRoleType { get; set; }

        public IEnumerable<RoleDropDownViewModel> Roles { get; set; }
    }
}
