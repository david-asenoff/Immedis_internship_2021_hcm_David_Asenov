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

        public virtual User RequestedByUser { get; set; }

        public bool? IsApproved { get; set; }

        [ForeignKey(nameof(User))]
        public string ApproovedByUserId { get; set; }

        public virtual User ApproovedByUser { get; set; }

        [Required]
        public bool IsPaidLeave { get; set; }
    }
}
