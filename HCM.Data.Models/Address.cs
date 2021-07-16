namespace HCM.Data.Models
{
    using HCM.Data.Common;
    using System;

    /// <summary>
    ///  Address information intends to establish the current resident address for employees. It may be used to mail information such as benefits information (health, life, TSP, etc.).
    /// </summary>
    public class Address : BaseDeletableModel<string>
    {
        public Address()
        {
            this.Id = Guid.NewGuid().ToString();
        }

        /// <summary>
        /// Gets or sets location of the address of an employee.
        /// </summary>
        public string Location { get; set; }
    }
}