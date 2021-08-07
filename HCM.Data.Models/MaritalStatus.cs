namespace HCM.Data.Models
{
    using System.ComponentModel.DataAnnotations;
    using HCM.Data.Common;

    /// <summary>
    /// Marital status is the legally defined marital state.
    /// </summary>
    public class MaritalStatus : BaseDeletableModel<int>
    {
        /// <summary>
        /// Gets or sets "Marital status" type. There are several types of marital status: single, married, widowed, divorced, separated and, in certain cases, registered partnership. Never married persons are persons who never got married in concordance with valid regulations.
        /// </summary>
        [Required(ErrorMessage = GlobalConstants.MaritalStatusTypeIsRequired)]
        public string Type { get; set; }
    }
}