namespace HCM.Web.ViewModels.Training
{
    using System.ComponentModel.DataAnnotations;
    public class TrainingDeleteViewModel : TrainingBaseViewModel
    {
        [Required]
        public string Id { get; set; }
    }
}