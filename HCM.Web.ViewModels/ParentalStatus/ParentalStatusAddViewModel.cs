using System.ComponentModel.DataAnnotations;

namespace HCM.Web.ViewModels.ParentalStatus
{
    public class ParentalStatusAddViewModel : ParentalStatusViewBaseModel
    {
        [Required]
        public int Id { get; set; }
    }
}
