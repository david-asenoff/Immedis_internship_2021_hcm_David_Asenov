namespace HCM.Data.Models
{
    using System;
    using System.ComponentModel.DataAnnotations.Schema;
    using HCM.Data.Common;

    public class TrainingUser : BaseDeletableModel<string>
    {
        public TrainingUser()
        {
            this.Id = Guid.NewGuid().ToString();
        }

        [ForeignKey(nameof(User))]
        public string UserId { get; set; }

        public virtual User User { get; set; }

        [ForeignKey(nameof(Training))]
        public string TrainingId { get; set; }

        public virtual Training Training { get; set; }
    }
}