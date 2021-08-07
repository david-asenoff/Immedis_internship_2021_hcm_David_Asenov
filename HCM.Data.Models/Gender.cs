namespace HCM.Data.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using HCM.Data.Common;

    /// <summary>
    /// Gender differences involve both physical and emotional factors. They are essentially the characteristics that influence male and female behavior in the workplace. These influences may stem from psychological factors, such as upbringing, or physical factors, such as an employee's capability to perform job duties.
    /// </summary>
    public class Gender : BaseDeletableModel<string>
    {
        public Gender()
        {
            this.Id = Guid.NewGuid().ToString();
            this.Users = new HashSet<User>();
        }

        /// <summary>
        /// Gets or sets type of gender. Values may be Man, Woman or Other.
        /// </summary>
        [Required(ErrorMessage = GlobalConstants.GenderTypeIsRequired)]
        public string Type { get; set; }

        public virtual ICollection<User> Users { get; set; }
    }
}