using System.ComponentModel.DataAnnotations;

namespace HCM.Web.ViewModels.Gender
{
    public class GenderDeleteViewModel : GenderViewBaseModel
    {
        [Required]
        public string Id { get; set; }
    }
}
