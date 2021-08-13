using System;

namespace HCM.Web.ViewModels.Employee
{
    public class EmployeeInformationBaseViewModel
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string MiddleName { get; set; }

        public string FullName => this.FirstName + " " + MiddleName+ " " + this.LastName;

        public string UserId { get; set; }

        public string Gender { get; set; }

        public string PhoneNumber { get; set; }

        public string Email { get; set; }

        public string Username { get; set; }

        public DateTime DateOfBirth { get; set; }

        public string AvatarUrl { get; set; }

        public int IdentityRoleId { get; set; }

        public string IdentityRoleType { get; set; }

        public bool IsBanned { get; set; }
    }
}