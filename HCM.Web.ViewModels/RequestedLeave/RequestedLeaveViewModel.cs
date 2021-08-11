namespace HCM.Web.ViewModels.RequestedLeave
{
    using System;
    using System.ComponentModel.DataAnnotations;

    public class RequestedLeaveViewModel : RequestedLeaveViewBaseModel
    {
        public DateTime CreatedOn { get; set; }

        public DateTime? ModifiedOn { get; set; }

        public DateTime? DeletedOn { get; set; }

        public bool IsDeleted { get; set; }

        [Required]
        public string Id { get; set; }
    }
}