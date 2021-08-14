using System.ComponentModel.DataAnnotations;

namespace HCM.Web.ViewModels.EvaluationScore
{
    public abstract class EvaluationScoreViewBaseModel
    {
        [Required]
        public string Description { get; set; }

        [Required]
        public string Rate { get; set; }

        [Required]
        public int Id { get; set; }

        public string ShortDescription => this.Description.Length > 50 ?
                                          this.Description.Substring(0, 50) + "..." : this.Description;
    }
}