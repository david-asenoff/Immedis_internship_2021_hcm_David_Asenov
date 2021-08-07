namespace HCM.Web.ViewModels.Training
{
    using System.ComponentModel.DataAnnotations;
    public class TrainingEditViewModel : TrainingBaseViewModel
    {
        [Required]
        public string Id { get; set; }
    }
}
