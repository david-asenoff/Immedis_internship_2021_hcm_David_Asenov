namespace HCM.Data.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using HCM.Data.Common;

    public class User : IdentityUser<string>
    {
        public User()
        {
            this.Id = Guid.NewGuid().ToString();
            this.EmployeeContracts = new HashSet<EmployeeContract>();
            this.UserAddresses = new HashSet<UserAddress>();
            this.UserMaritalStatuses = new HashSet<UserMaritalStatus>();
            this.UserParentalStatuses = new HashSet<UserParentalStatus>();
            this.ProjectUsers = new HashSet<ProjectUser>();
            this.TrainingUsers = new HashSet<TrainingUser>();
            this.RequestedLeaves = new HashSet<RequestedLeave>();
            this.ApprovedLeaves = new HashSet<RequestedLeave>();
        }

        [Display(Name = GlobalConstants.FirstNameDisplay)]
        [Required(ErrorMessage = GlobalConstants.FirstNameIsRequired)]
        [StringLength(GlobalConstants.NameMaxLength, MinimumLength = GlobalConstants.NameMinLength, ErrorMessage = GlobalConstants.FirstNameIsInvalid)]
        public string FirstName { get; set; }

        [Display(Name = GlobalConstants.MiddleNameDisplay)]
        [StringLength(GlobalConstants.NameMaxLength, MinimumLength = GlobalConstants.NameMinLength, ErrorMessage = GlobalConstants.MiddleNameIsInvalid)]
        public string MiddleName { get; set; }

        [Display(Name = GlobalConstants.LastNameDisplay)]
        [Required(ErrorMessage = GlobalConstants.LastNameIsRequired)]
        [StringLength(GlobalConstants.NameMaxLength, MinimumLength = GlobalConstants.NameMinLength, ErrorMessage = GlobalConstants.LastNameIsInvalid)]
        public string LastName { get; set; }

        [Required(ErrorMessage = GlobalConstants.GenderIsRequired)]
        [ForeignKey(nameof(Gender))]
        public string GenderId { get; set; }

        public virtual Gender Gender { get; set; }

        [Display(Name = GlobalConstants.DateOfBirthDisplay)]
        [Required(ErrorMessage = GlobalConstants.DateOfBirthIsRequired)]
        [DateOfBirth]
        public DateTime DateOfBirth { get; set; }

        public string Portrait { get; set; }

        public string CV { get; set; }

        public virtual ICollection<EmployeeContract> EmployeeContracts { get; set; }

        public virtual ICollection<UserAddress> UserAddresses { get; set; }

        public virtual ICollection<UserMaritalStatus> UserMaritalStatuses { get; set; }

        public virtual ICollection<UserParentalStatus> UserParentalStatuses { get; set; }

        public virtual ICollection<ProjectUser> ProjectUsers { get; set; }

        public virtual ICollection<TrainingUser> TrainingUsers { get; set; }

        public virtual ICollection<RequestedLeave> RequestedLeaves{ get; set; }

        public virtual ICollection<RequestedLeave> ApprovedLeaves { get; set; }
    }
}
