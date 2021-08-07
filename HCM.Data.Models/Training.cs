namespace HCM.Data.Models
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using HCM.Data.Common;

    public class Training : BaseDeletableModel<string>
    {
        public Training()
        {
            this.Id = Guid.NewGuid().ToString();
        }

        public string Name { get; set; }

        public string Description { get; set; }

        /// <summary>
        /// Gets or sets the start date of the training which employee have started.
        /// </summary>
        [Display(Name = GlobalConstants.StartDateDisplay)]
        [Required(ErrorMessage = GlobalConstants.StartDateIsRequired)]
        public DateTime StartDate { get; set; }

        /// <summary>
        /// Gets or sets the end date of the training which employee have started.
        /// </summary>
        [Display(Name = GlobalConstants.EndDateDisplay)]
        [Required(ErrorMessage = GlobalConstants.EndDateIsRequired)]
        public DateTime EndDate { get; set; }

        public int TotalHours { get; set; }
    }
}