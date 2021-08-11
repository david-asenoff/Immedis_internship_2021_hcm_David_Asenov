using System.ComponentModel.DataAnnotations;

namespace HCM.Web.ViewModels.RequestedLeave
{
    public class RequestedLeaveDeleteViewModel : RequestedLeaveViewBaseModel
    {
        [Required]
        public string Id { get; set; }
    }
}
