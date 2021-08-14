using System.ComponentModel.DataAnnotations;

namespace HCM.Web.ViewModels.Training
{
    public class TrainingEditViewModel : TrainingBaseViewModel
    {
        [Required]
        public string Id { get; set; }
    }
}
