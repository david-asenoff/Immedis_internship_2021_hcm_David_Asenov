namespace HCM.Data.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using HCM.Common;
    using HCM.Data.Common;

    public class User : BaseDeletableModel<string>
    {
        public User()
        {
            this.Id = Guid.NewGuid().ToString();
            this.EmployeeContracts = new HashSet<EmployeeContract>();
            this.UserAddresses = new HashSet<UserAddress>();
            this.UserMaritalStatuses = new HashSet<UserMaritalStatus>();
            this.UserParentalStatuses = new HashSet<UserParentalStatus>();
            this.ProjectUsers = new HashSet<ProjectUser>();
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
        public Gender Gender { get; set; }

        [Display(Name = GlobalConstants.DateOfBirthDisplay)]
        [Required(ErrorMessage = GlobalConstants.DateOfBirthIsRequired)]
        [DateOfBirth]
        public DateTime DateOfBirth { get; set; }

        [Required(ErrorMessage = GlobalConstants.PortraitIsRequired)]
        public string Portrait { get; set; }

        [Required(ErrorMessage = GlobalConstants.CVIsRequired)]
        public string CV { get; set; }

        [ForeignKey(nameof(IdentityUser))]
        public string IdentityUserId { get; set; }

        public virtual IdentityUser IdentityUser { get; set; }

        public virtual ICollection<EmployeeContract> EmployeeContracts { get; set; }

        public virtual ICollection<UserAddress> UserAddresses { get; set; }

        public virtual ICollection<UserMaritalStatus> UserMaritalStatuses { get; set; }

        public virtual ICollection<UserParentalStatus> UserParentalStatuses { get; set; }

        public virtual ICollection<ProjectUser> ProjectUsers { get; set; }
    }
}
