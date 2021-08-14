using System.ComponentModel.DataAnnotations;

namespace HCM.Web.ViewModels.Salary
{
    public class SalaryEditViewModel : SalaryBaseViewModel
    {
        [Required]
        public string Id { get; set; }
    }
}
