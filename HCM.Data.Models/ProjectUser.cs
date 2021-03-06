namespace HCM.Data.Models
{
    using System;
    using System.ComponentModel.DataAnnotations.Schema;
    using HCM.Data.Common;

    public class ProjectUser : BaseDeletableModel<string>
    {
        public ProjectUser()
        {
            this.Id = Guid.NewGuid().ToString();
        }

        [ForeignKey(nameof(User))]
        public string UserId { get; set; }

        public virtual User User { get; set; }

        [ForeignKey(nameof(Project))]
        public string ProjectId { get; set; }

        public virtual Project Project { get; set; }
    }
}
