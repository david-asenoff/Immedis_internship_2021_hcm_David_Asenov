using System.ComponentModel.DataAnnotations;

namespace HCM.Web.ViewModels.MaritalStatus
{
    public class MaritalStatusEditViewModel:MaritalStatusViewBaseModel
    {
        [Required]
        public int Id { get; set; }
    }
}
