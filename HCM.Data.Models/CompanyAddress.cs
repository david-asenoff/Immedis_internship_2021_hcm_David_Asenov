namespace HCM.Data.Models
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using HCM.Data.Common;

    /// <summary>
    ///  Address information intends to establish the current resident address for employees. It may be used to mail information such as benefits information (health, life, TSP, etc.).
    /// </summary>
    public class CompanyAddress : BaseDeletableModel<string>
    {
        public CompanyAddress()
        {
            this.Id = Guid.NewGuid().ToString();
        }

        [Required(ErrorMessage = GlobalConstants.AddressIsRequired)]
        [ForeignKey(nameof(Address))]
        public string AddressId { get; set; }

        public virtual Address Address { get; set; }

        [Required(ErrorMessage = GlobalConstants.AddressIsRequired)]
        [ForeignKey(nameof(Company))]
        public string CompanyId { get; set; }

        public virtual Company Company { get; set; }
    }
}