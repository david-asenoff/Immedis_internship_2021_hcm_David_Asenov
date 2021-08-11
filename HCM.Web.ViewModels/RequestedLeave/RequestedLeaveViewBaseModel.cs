namespace HCM.Web.ViewModels.RequestedLeave
{
    using HCM.Data.Common;
    using HCM.Web.ViewModels.Manager;
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public abstract class RequestedLeaveViewBaseModel
    {
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

        /// <summary>
        /// Gets or sets whether a Manager has approved the requested leave or not.
        /// True means 'yes', False means 'pending for approval' and Null means 'declined'.
        /// </summary>
        [NotMapped]
        public bool? IsApproved { get; set; }

        [NotMapped]
        public string Username { get; set; }

        public ManagerNamesViewModel Manager { get; set; }
    }
}