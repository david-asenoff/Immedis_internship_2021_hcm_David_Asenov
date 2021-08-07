namespace HCM.Data.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using HCM.Data.Common;

    /// <summary>
    /// Score used to ensure quality of an employee performance.
    /// </summary>
    public class EvaluationScore : BaseDeletableModel<int>
    {
        public EvaluationScore()
        {
            this.PerformanceReviews = new HashSet<PerformanceReview>();
        }

        /// <summary>
        /// Gets or sets the description of the evaluation score of an employee.
        /// </summary>
        [Display(Name = GlobalConstants.DescriptionDisplay)]
        [Required(ErrorMessage = GlobalConstants.DescriptionIsRequired)]
        public string Description { get; set; }

        /// <summary>
        /// Gets or sets the rate of the evaluation score of an employee.
        /// </summary>
        [Display(Name = GlobalConstants.RateDisplay)]
        [Required(ErrorMessage = GlobalConstants.RateIsRequired)]
        public string Rate { get; set; }

        public virtual ICollection<PerformanceReview> PerformanceReviews { get; set; }
    }
}