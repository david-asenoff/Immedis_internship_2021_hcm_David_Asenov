namespace HCM.Data.Models
{
    using System;
    using System.ComponentModel.DataAnnotations.Schema;
    using HCM.Data.Common;

    public class PerformanceReview : BaseDeletableModel<string>
    {
        public PerformanceReview()
        {
            this.Id = Guid.NewGuid().ToString();
        }

        public EvaluationScore EvaluationScore { get; set; }

        public string Notes { get; set; }

        [NotLaterThanToday]
        public DateTime ReviewDate { get; set; }

        [ForeignKey(nameof(User))]
        public string FromUserId { get; set; }

        public virtual User FromUser { get; set; }

        [ForeignKey(nameof(User))]
        public string ToUserId { get; set; }

        public virtual User ToUser { get; set; }

        public bool IsApproved { get; set; }
    }
}
