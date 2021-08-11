namespace HCM.Web.ViewModels.Manager
{
    using System;
    using System.ComponentModel.DataAnnotations;

    public class ManagerNamesViewModel
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Id { get; set; }

        public string FullName => this.FirstName + " " + this.LastName;
    }
}