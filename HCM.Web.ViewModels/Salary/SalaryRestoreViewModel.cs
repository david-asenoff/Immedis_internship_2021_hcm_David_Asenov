namespace HCM.Web.ViewModels.Salary
{
    using System;
    using System.ComponentModel.DataAnnotations;
    public class SalaryRestoreViewModel : SalaryBaseViewModel
    {
        public DateTime? DeletedOn { get; set; }

        [Required]
        public string Id { get; set; }
    }
}