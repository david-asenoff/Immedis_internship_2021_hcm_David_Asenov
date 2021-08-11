using System.ComponentModel.DataAnnotations;

namespace HCM.Web.ViewModels.RequestedLeave
{
    public class RequestedLeaveAddViewModel : RequestedLeaveViewBaseModel
    {
        /// <summary>
        /// Gets or sets whether Employee want the leave request to be a paid one or not.
        /// </summary>
        [Required]
        public bool IsPaidLeave { get; set; }
    }
}