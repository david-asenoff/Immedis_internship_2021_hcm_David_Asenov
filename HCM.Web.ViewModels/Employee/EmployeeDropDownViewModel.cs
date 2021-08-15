using HCM.Data.Common;
using System;
using System.ComponentModel.DataAnnotations;

namespace HCM.Web.ViewModels.Employee
{
    public class EmployeeDropDownViewModel
    {
        public string UserId { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string MiddleName { get; set; }

        public string Gender { get; set; }

        public string PhoneNumber { get; set; }

        public string Email { get; set; }

        public DateTime DateOfBirth { get; set; }

        public string ShortInfo => $@"names: {FirstName} {MiddleName} {LastName}, 
                                   gender: {Gender}, birthday: {DateOfBirth}, email: {Email}, phone: {PhoneNumber}";   
    }
}
