namespace HCM.Data.Models
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using HCM.Data.Common;

    public class RequestedLeave : BaseDeletableModel<string>
    {
        public RequestedLeave()
        {
            this.Id = Guid.NewGuid().ToString();
            this.IsApproved = null;
        }

        /// <summary>
        /// Gets or sets the start date of the project status.
        /// </summary>
        [Display(Name = GlobalConstants.StartDateDisplay)]
        [Required(ErrorMessage = GlobalConstants.StartDateIsRequired)]
        public DateTime StartDate { get; set; }

        /// <summary>
        ///  Gets or sets the end date of the used vacation.
        /// </summary>
        [Required]
        public DateTime EndDate { get; set; }

        [ForeignKey(nameof(User))]
        public string RequestedByUserId { get; set; }

        [InverseProperty("RequestedLeaves")]
        public virtual User RequestedByUser { get; set; }

        /// <summary>
        /// Gets or sets whether a Manager has approved the requested leave or not.
        /// True means 'yes', False means 'declined' and Null means 'pending for approval'.
        /// The value will be set to null by the constructor.
        /// </summary>
        public bool? IsApproved { get; set; }

        /// <summary>
        /// Gets or sets the Id of the Manager who has approved the request.
        /// </summary>
        [ForeignKey(nameof(User))]
        public string RevisedByManagerId { get; set; }

        [InverseProperty("ApprovedLeaves")]
        public virtual User RevisedByManager { get; set; }

        /// <summary>
        /// Gets or sets whether Employee want the leave request to be a paid one or not.
        /// </summary>
        [Required]
        public bool IsPaidLeave { get; set; }
    }
}
