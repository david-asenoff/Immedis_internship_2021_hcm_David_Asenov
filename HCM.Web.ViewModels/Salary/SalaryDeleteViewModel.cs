namespace HCM.Web.ViewModels.Salary
{
    using System.ComponentModel.DataAnnotations;

    public class SalaryDeleteViewModel : SalaryBaseViewModel
    {
        [Required]
        public string Id { get; set; }
    }
}