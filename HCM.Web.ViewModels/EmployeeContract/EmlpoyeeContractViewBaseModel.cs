namespace HCM.Web.ViewModels.EmployeeContract
{
    using HCM.Data.Common;
    using HCM.Web.ViewModels.Department;
    using HCM.Web.ViewModels.Employee;
    using HCM.Web.ViewModels.Position;
    using HCM.Web.ViewModels.Salary;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    public abstract class EmployeeContractViewBaseModel
    {
        public EmployeeContractViewBaseModel()
        {
            Departments = new List<DepartmentDropDownViewModel>();
            Positions = new List<PositionDropDownViewModel>();
            Salary = new SalaryAddViewModel();
        }

        public string EmployeeContractId { get; set; }

        public string DepartmentId { get; set; }

        public string DepartmentName { get; set; }

        public string DepartmentCompanyName { get; set; }

        public ICollection<DepartmentDropDownViewModel> Departments { get; set; }

        public string PositionName { get; set; }

        public string PositionId { get; set; }

        public ICollection<PositionDropDownViewModel> Positions { get; set; }

        public SalaryAddViewModel Salary { get; set; }

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