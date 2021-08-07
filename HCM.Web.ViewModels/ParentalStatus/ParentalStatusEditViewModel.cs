using System.ComponentModel.DataAnnotations;

namespace HCM.Web.ViewModels.ParentalStatus
{
    public class ParentalStatusEditViewModel : ParentalStatusViewBaseModel
    {
        [Required]
        public int Id { get; set; }
    }
}
