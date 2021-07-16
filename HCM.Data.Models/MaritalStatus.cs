namespace HCM.Data.Models
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using HCM.Common;
    using HCM.Data.Common;

    /// <summary>
    /// Marital status is the legally defined marital state.
    /// </summary>
    public class MaritalStatus : BaseDeletableModel<string>
    {
        public MaritalStatus()
        {
            this.Id = Guid.NewGuid().ToString();
        }

        /// <summary>
        /// Gets or sets "Marital status" type. There are several types of marital status: single, married, widowed, divorced, separated and, in certain cases, registered partnership. Never married persons are persons who never got married in concordance with valid regulations.
        /// </summary>
        [Required(ErrorMessage = GlobalConstants.MaritalStatusTypeIsRequired)]
        public string Type { get; set; }
    }
}