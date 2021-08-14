using System;
using System.ComponentModel.DataAnnotations;

namespace HCM.Web.ViewModels.Training
{
    public class TrainingRestoreViewModel : TrainingBaseViewModel
    {
        [Required]
        public string Id { get; set; }
        public DateTime? DeletedOn { get; set; }
    }
}