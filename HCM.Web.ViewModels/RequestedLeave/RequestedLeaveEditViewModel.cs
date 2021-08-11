using System.ComponentModel.DataAnnotations;

namespace HCM.Web.ViewModels.RequestedLeave
{
    public class RequestedLeaveEditViewModel : RequestedLeaveViewBaseModel
    {
        [Required]
        public string Id { get; set; }
    }
}
