namespace HCM.Web.ViewModels.Training
{
    using System;
    using System.ComponentModel.DataAnnotations;
    public class TrainingViewModel : TrainingBaseViewModel
    {
        [Required]
        public string Id { get; set; }

        public DateTime CreatedOn { get; set; }

        public DateTime? ModifiedOn { get; set; }

        public DateTime? DeletedOn { get; set; }

        public bool IsDeleted { get; set; }
    }
}
