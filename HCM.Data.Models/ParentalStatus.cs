namespace HCM.Data.Models
{
    using System.ComponentModel.DataAnnotations;
    using HCM.Common;
    using HCM.Data.Common;

    /// <summary>
    /// Parental status means whether or not a person is a parent. It includes the status of not having children.
    /// </summary>
    public class ParentalStatus : BaseDeletableModel<int>
    {

        /// <summary>
        /// Gets or sets the type of parental status. For example: parent, step-parent, adoptive parent, foster parent, guardian and not having children.
        /// </summary>
        [Required(ErrorMessage = GlobalConstants.ParentalStatusTypeIsRequired)]
        public string Type { get; set; }
    }
}