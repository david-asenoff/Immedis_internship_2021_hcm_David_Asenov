using System.ComponentModel.DataAnnotations;

namespace HCM.Web.ViewModels.MaritalStatus
{
    public class MaritalStatusAddViewModel : MaritalStatusViewBaseModel
    {
        [Required]
        public int Id { get; set; }
    }
}
