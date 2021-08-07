using System.ComponentModel.DataAnnotations;

namespace HCM.Web.ViewModels.Gender
{
    public class GenderEditViewModel : GenderViewBaseModel
    {
        [Required]
        public string Id { get; set; }
    }
}
