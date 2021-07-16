namespace HCM.Data.Models
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using HCM.Common;
    using HCM.Data.Common;

    /// <summary>
    /// Contract is an agreement that sets out an employee's employment conditions and rights.
    /// </summary>
    public class Contract : BaseDeletableModel<string>
    {
        public Contract()
        {
            this.Id = Guid.NewGuid().ToString();
        }

        /// <summary>
        /// Gets or sets the department in which employee is working.
        /// </summary>
        [Required(ErrorMessage = GlobalConstants.DepartmentIsRequired)]
        public Department Department { get; set; }

        /// <summary>
        /// Gets or sets the possition at which employee is working.
        /// </summary>
        [Required(ErrorMessage = GlobalConstants.PossitionIsRequired)]
        public Possition Possition { get; set; }

        [Required(ErrorMessage = GlobalConstants.SalaryIsRequired)]
        public Salary Salary { get; set; }

        [Required(ErrorMessage = GlobalConstants.EmployeeIsRequired)]
        public User Employee { get; set; }

        /// <summary>
        /// Gets or sets the start date of the contract which employee have signed.
        /// </summary>
        [Display(Name = GlobalConstants.StartDateDisplay)]
        [Required(ErrorMessage = GlobalConstants.StartDateIsRequired)]
        public DateTime StartDate { get; set; }

        /// <summary>
        /// Gets or sets the end date of the contract which employee have signed. The end date may be null when contract is permenents for example.
        /// </summary>
        public DateTime? EndDate { get; set; }

        /// <summary>
        /// Gets or sets the start hour of the working day of the contract which employee have signed. The start hour may be null when contract is with flexible working hours for example.
        /// </summary>
        [Display(Name = GlobalConstants.StartOfTheWorkingHoursDisplay)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:hh\\:mm}")]
        [RegularExpression(@"((([0-1][0-9])|(2[0-3]))(:[0-5][0-9])(:[0-5][0-9])?)", ErrorMessage = GlobalConstants.StartOfTheWorkingHoursIsInvalid)]
        public TimeSpan StartOfTheWorkingHours { get; set; }

        /// <summary>
        /// Gets or sets the end hour of the working day of the contract which employee have signed. The end hour may be null when contract is with flexible working hours for example.
        /// </summary>
        [Display(Name = GlobalConstants.EndOfTheWorkingHoursDisplay)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:hh\\:mm}")]
        [RegularExpression(@"((([0-1][0-9])|(2[0-3]))(:[0-5][0-9])(:[0-5][0-9])?)", ErrorMessage = GlobalConstants.EndOfTheWorkingHoursIsInvalid)]
        public TimeSpan EndOfTheWorkingHours { get; set; }

        /// <summary>
        /// Gets or sets whether the working hours are flexible or not.
        /// </summary>
        [Display(Name = GlobalConstants.AreWorkingHoursFlexibleDisplay)]
        [Required(ErrorMessage = GlobalConstants.AreWorkingHoursFlexibleRequired)]
        public bool AreWorkingHoursFlexible { get; set; }

        /// <summary>
        /// Gets or sets whether the contract type is full time or not.
        /// </summary>
        [Display(Name = GlobalConstants.EndOfTheWorkingHoursDisplay)]
        [Required(ErrorMessage = GlobalConstants.StartOfTheWorkingHoursDisplay)]
        public bool IsContractTypeFullTime { get; set; }
    }
}