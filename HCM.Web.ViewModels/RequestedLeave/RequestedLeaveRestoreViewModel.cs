using System;
using System.ComponentModel.DataAnnotations;

namespace HCM.Web.ViewModels.RequestedLeave
{
    public class RequestedLeaveRestoreViewModel : RequestedLeaveViewBaseModel
    {
        public DateTime? DeletedOn { get; set; }

        [Required]
        public string Id { get; set; }
    }
}
