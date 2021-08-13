namespace HCM.Web.ViewModels.ApproveLeave
{
    using System;
    using System.ComponentModel.DataAnnotations;

    public class ApproveLeaveViewModel : ApproveLeaveViewBaseModel
    {
        public DateTime CreatedOn { get; set; }

        public DateTime? ModifiedOn { get; set; }

        public DateTime? DeletedOn { get; set; }

        [Required]
        public string Id { get; set; }

        /// <summary>
        /// Gets or sets whether Employee want the leave request to be a paid one or not.
        /// </summary>
        [Required]
        public bool IsPaidLeave { get; set; }
    }
}