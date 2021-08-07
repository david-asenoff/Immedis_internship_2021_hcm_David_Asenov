namespace HCM.Data.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using HCM.Data.Common;

    /// <summary>
    ///  Address information intends to establish the current resident address for employees. It may be used to mail information such as benefits information (health, life, TSP, etc.).
    /// </summary>
    public class Address : BaseDeletableModel<string>
    {
        public Address()
        {
            this.Id = Guid.NewGuid().ToString();
            this.UserAddresses = new HashSet<UserAddress>();
            this.CompanyAddresses = new HashSet<CompanyAddress>();
            this.DepartmentAddresses = new HashSet<DepartmentAddress>();
        }

        /// <summary>
        /// Gets or sets location of the address of an employee.
        /// </summary>
        [Display(Name = GlobalConstants.LocationDisplay)]
        [Required(ErrorMessage = GlobalConstants.LocationIsRequired)]
        public string Location { get; set; }

        public virtual ICollection<UserAddress> UserAddresses { get; set; }

        public virtual ICollection<CompanyAddress> CompanyAddresses { get; set; }

        public virtual ICollection<DepartmentAddress> DepartmentAddresses { get; set; }
    }
}