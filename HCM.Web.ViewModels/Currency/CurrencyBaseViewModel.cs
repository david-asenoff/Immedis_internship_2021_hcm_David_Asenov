namespace HCM.Web.ViewModels.Currency
{
using HCM.Data.Common;
using System.ComponentModel.DataAnnotations;

    public abstract class EmployeeTrainingsBaseViewModel
    {
        /// <summary>
        /// Gets or sets currency description.
        /// </summary>
        [Display(Name = GlobalConstants.DescriptionDisplay)]
        [Required(ErrorMessage = GlobalConstants.DescriptionIsRequired)]
        public string Description { get; set; }

        /// <summary>
        /// Gets or sets currency abbreviation.
        /// </summary>
        [Display(Name = GlobalConstants.AbbreviationDisplay)]
        [Required(ErrorMessage = GlobalConstants.AbbreviationIsRequired)]
        public string Abbreviation { get; set; }
    }
}
