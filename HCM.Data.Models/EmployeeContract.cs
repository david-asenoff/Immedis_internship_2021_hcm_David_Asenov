namespace HCM.Data.Models
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using HCM.Common;
    using HCM.Data.Common;

    /// <summary>
    /// Employee contract is an agreement that sets out an employee's employment conditions and rights.
    /// </summary>
    public class EmployeeContract : BaseDeletableModel<string>
    {
        public EmployeeContract()
        {
            this.Id = Guid.NewGuid().ToString();
        }

        /// <summary>
        /// Gets or sets the department in which employee is working.
        /// </summary>
        [Required(ErrorMessage = GlobalConstants.DepartmentIsRequired)]
        [ForeignKey(nameof(Department))]
        public string DepartmentId { get; set; }

        public virtual Department Department { get; set; }

        /// <summary>
        /// Gets or sets the possition at which employee is working.
        /// </summary>
        [Required(ErrorMessage = GlobalConstants.PossitionIsRequired)]
        [ForeignKey(nameof(Possition))]
        public string PossitionId { get; set; }

        public virtual Possition Possition { get; set; }

        /// <summary>
        /// Gets or sets the salary id for the emloyee contract.
        /// </summary>
        [Required(ErrorMessage = GlobalConstants.SalaryIsRequired)]
        [ForeignKey(nameof(Salary))]
        public string SalaryId { get; set; }

        public virtual Salary Salary { get; set; }

        /// <summary>
        /// Gets or sets the user id for the emloyee contract.
        /// </summary>
        [Required(ErrorMessage = GlobalConstants.EmployeeIsRequired)]
        [ForeignKey(nameof(User))]
        public string UserId { get; set; }

        public virtual User User { get; set; }

        /// <summary>
        /// Gets or sets the start date of the contract which employee have signed.
        /// </summary>
        [Display(Name = GlobalConstants.StartDateDisplay)]
        [Required(ErrorMessage = GlobalConstants.StartDateIsRequired)]
        public DateTime StartDate { get; set; }

        /// <summary>
        /// Gets or sets the end date of the contract which employee have signed. The end date may be null when contract is permenents for example.
        /// </summary>
        [Display(Name = GlobalConstants.EndDateDisplay)]
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
        [Display(Name = GlobalConstants.IsContractTypeFullTimeDisplay)]
        [Required(ErrorMessage = GlobalConstants.IsContractTypeFullTimeIsRequired)]
        public bool IsContractTypeFullTime { get; set; }

        /// <summary>
        /// Gets or sets the paid leave days allowed per year for the emloyee contract.
        /// </summary>
        [Display(Name = GlobalConstants.PaidLeavesAllowedPerYearDisplay)]
        [Required(ErrorMessage = GlobalConstants.PaidLeavesAllowedPerYearIsRequired)]
        [Range(0, 255, ErrorMessage = GlobalConstants.PaidLeavesAllowedIsInvalid)]
        public byte PaidLeavesAllowedPerYear { get; set; }

        /// <summary>
        /// Gets or sets the unpaid leave days allowed per year for the emloyee contract.
        /// </summary>
        [Display(Name = GlobalConstants.UnpaidLeavesAllowedPerYearDisplay)]
        [Required(ErrorMessage = GlobalConstants.UnpaidLeavesAllowedPerYearIsRequired)]
        [Range(0, 255, ErrorMessage = GlobalConstants.UnpaidLeavesAllowedIsInvalid)]
        public byte UnpaidLeavesAllowedPerYear { get; set; }
    }
}