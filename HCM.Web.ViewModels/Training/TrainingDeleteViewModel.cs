using System.ComponentModel.DataAnnotations;

namespace HCM.Web.ViewModels.Training
{
    public class TrainingDeleteViewModel : TrainingBaseViewModel
    {
        [Required]
        public string Id { get; set; }
    }
}