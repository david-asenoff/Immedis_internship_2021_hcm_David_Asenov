namespace HCM.Web.ViewModels.Salary
{
    using System.ComponentModel.DataAnnotations;
    public class SalaryEditViewModel : SalaryBaseViewModel
    {
        [Required]
        public string Id { get; set; }
    }
}
