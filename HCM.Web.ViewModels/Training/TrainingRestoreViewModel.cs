namespace HCM.Web.ViewModels.Training
{
    using System;
    using System.ComponentModel.DataAnnotations;

    public class TrainingRestoreViewModel : TrainingBaseViewModel
    {
        [Required]
        public string Id { get; set; }
        public DateTime? DeletedOn { get; set; }
    }
}