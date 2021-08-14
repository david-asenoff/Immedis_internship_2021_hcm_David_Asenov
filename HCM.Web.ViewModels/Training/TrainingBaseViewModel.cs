using HCM.Data.Common;
using System;
using System.ComponentModel.DataAnnotations;

namespace HCM.Web.ViewModels.Training
{
    public abstract class TrainingBaseViewModel
    {
        public string Name { get; set; }

        public string Description { get; set; }

        /// <summary>
        /// Gets or sets the start date of the training which employee have started.
        /// </summary>
        [Display(Name = GlobalConstants.StartDateDisplay)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [Required(ErrorMessage = GlobalConstants.StartDateIsRequired)]
        public DateTime StartDate { get; set; }

        /// <summary>
        /// Gets or sets the end date of the training which employee have started.
        /// </summary>
        [Display(Name = GlobalConstants.EndDateDisplay)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [Required(ErrorMessage = GlobalConstants.EndDateIsRequired)]
        public DateTime EndDate { get; set; }

        public int TotalHours { get; set; }

        public string ShortDescription => this.Description?.Length > 50 ?
                             this.Description?.Substring(0, 50) + "..." :
                             this.Description;
    }
}
