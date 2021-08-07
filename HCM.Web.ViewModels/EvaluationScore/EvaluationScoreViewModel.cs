namespace HCM.Web.ViewModels.EvaluationScore
{
    using System;
    public class EvaluationScoreViewModel : EvaluationScoreViewBaseModel
    {
        public DateTime CreatedOn { get; set; }

        public DateTime? ModifiedOn { get; set; }

        public DateTime? DeletedOn { get; set; }

        public bool IsDeleted { get; set; }
    }
}