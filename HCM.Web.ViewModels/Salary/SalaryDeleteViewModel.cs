using System.ComponentModel.DataAnnotations;

namespace HCM.Web.ViewModels.Salary
{
    public class SalaryDeleteViewModel : SalaryBaseViewModel
    {
        [Required]
        public string Id { get; set; }
    }
}