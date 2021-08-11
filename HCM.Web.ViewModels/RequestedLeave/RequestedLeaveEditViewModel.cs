using System.ComponentModel.DataAnnotations;

namespace HCM.Web.ViewModels.RequestedLeave
{
    public class RequestedLeaveEditViewModel : RequestedLeaveViewBaseModel
    {
        [Required]
        public string Id { get; set; }

        /// <summary>
        /// Gets or sets whether Employee want the leave request to be a paid one or not.
        /// </summary>
        [Required]
        public bool IsPaidLeave { get; set; }
    }
}
