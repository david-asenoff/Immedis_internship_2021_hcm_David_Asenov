namespace HCM.Web.ViewModels.RequestedLeave
{
    using System;
    using System.ComponentModel.DataAnnotations;

    public class RequestedLeaveRestoreViewModel : RequestedLeaveViewBaseModel
    {
        public DateTime? DeletedOn { get; set; }

        [Required]
        public string Id { get; set; }
    }
}
