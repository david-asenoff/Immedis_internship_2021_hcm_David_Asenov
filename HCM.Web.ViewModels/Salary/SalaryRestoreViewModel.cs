using System;
using System.ComponentModel.DataAnnotations;

namespace HCM.Web.ViewModels.Salary
{
    public class SalaryRestoreViewModel : SalaryBaseViewModel
    {
        public DateTime? DeletedOn { get; set; }

        [Required]
        public string Id { get; set; }
    }
}