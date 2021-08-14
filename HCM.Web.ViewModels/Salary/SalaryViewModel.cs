using System;
using System.ComponentModel.DataAnnotations;

namespace HCM.Web.ViewModels.Salary
{
    public class SalaryViewModel : SalaryBaseViewModel
    {
        public DateTime CreatedOn { get; set; }

        public DateTime? ModifiedOn { get; set; }

        public DateTime? DeletedOn { get; set; }

        public bool IsDeleted { get; set; }

        [Required]
        public string Id { get; set; }
    }
}
