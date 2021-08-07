namespace HCM.Data.Common
{
    public static class GlobalConstants
    {
        // System
        public const string SystemName = "HCM";
        public const string AdministratorRoleName = "Administrator";
        public const string EmployeeRoleName = "Employee";
        public const string ManagerRoleName = "Manager";
        public const string HRRoleName = "HR";
        public const string SystemEmail = "immedis.internship.2021.hcm@gmail.com";
        public const string AuthenticationCookieName = "HCM_AUTH";
        public const string AntiforgeryCookieName = "HCM_ANTIFORGERY";

        // Email
        public const string EmailDisplay = "E-mail";
        public const string EmailIsRequired = "E-mail address is required";
        public const string EmailIsInvalid = "E-mail is invalid";

        // User
        public const int MinAge = 18;
        public const int MaxAge = 150;

        // IdentityUser
        public const int PasswordMinLength = 5;
        public const int PasswordMaxLength = 255;
        public const string ConfirmPasswordDisplay = "Confirm Password";
        public const string ConfirmPasswordIsRequired = "Confirm Password is required";
        public const string PasswordsDontMatch = "Passwords don't match";
        public const string PasswordIsRequired = "Password is required";
        public const string PasswordIsInvalid = "Password is invalid. Password must contain between 5 and 255 characters";
        public const string RememberMeDisplay = "Remember on this computer";

        // UserName
        public const int UsernameMinLength = 5;
        public const int UsernameMaxLength = 20;
        public const string UsernameIsInvalid = "Username is invalid. Username should be between 5 and 20 characters";
        public const string UsernameIsRequired = "Username is required";

        // Name
        public const int NameMinLength = 1;
        public const int NameMaxLength = 40;

        // FirstName
        public const string FirstNameDisplay = "First name";
        public const string FirstNameIsRequired = "First name is required";
        public const string FirstNameIsInvalid = "First name is invalid. First name should be between 1 and 40 characters";

        // MiddleName
        public const string MiddleNameDisplay = "Middle name";
        public const string MiddleNameIsInvalid = "Middle name is invalid. Middle name should be between 1 and 40 characters";

        // LastName
        public const string LastNameDisplay = "Last name";
        public const string LastNameIsRequired = "Last name is required";
        public const string LastNameIsInvalid = "Last name is invalid. Last name should be between 1 and 40 characters";

        // Gender
        public const string GenderIsRequired = "Gender is required";
        public const string GenderTypeIsRequired = "Type of the gender is required";

        // MaritalStatus
        public const string MaritalStatusDisplay = "Marital status";
        public const string MaritalStatusIsRequired = "Marital status is required";
        public const string MaritalStatusTypeIsRequired = "Type of the marital status is required";

        // ParentalStatus
        public const string ParentalStatusDisplay = "Parental status";
        public const string ParentalStatusIsRequired = "Parental status is required";
        public const string ParentalStatusTypeIsRequired = "Type of the parental status is required";

        // ProjectStatusCategory
        public const string ProjectStatusCategoryDisplay = "Project status category";
        public const string ProjectStatusCategoryIsRequired = "Project status category is required";
        public const string ProjectStatusCategoryTypeIsRequired = "Type of the project status category is required";

        // DateOfBirth
        public const string DateOfBirthDisplay = "Date of birth";
        public const string DateOfBirthIsRequired = "Date of birth is required";

        // PhoneNumber
        public const string PhoneNumberDisplay = "Phone number";
        public const string PhoneNumberIsRequired = "Phone number is required";
        public const string PhoneNumberIsInvalid = "Phone number is invalid";

        // Address
        public const string AddressIsRequired = "Address is required";
        public const string LocationDisplay = "Location";
        public const string LocationIsRequired = "Location is required";

        // Portrait
        public const string PortraitIsRequired = "Portrait is required";

        // CV
        public const string CVIsRequired = "CV is required";

        // Department
        public const string DepartmentIsRequired = "Department is required";
        public const string DepartmentNameIsRequired = "Name of the department is required";
        public const string CompanyIsRequired = "Company is required";
        public const string DepartmentNameDisplay = "Department name";

        // Possition
        public const string PossitionIsRequired = "Possition is required";
        public const string PossitionNameIsRequired = "Name of the possition is required";

        // Salary
        public const string SalaryIsRequired = "Salary is required";

        // EmployeeContract
        public const string EmployeeIsRequired = "Employee is required";
        public const string StartDateDisplay = "Start date";
        public const string StartDateIsRequired = "Start date is required";
        public const string StartOfTheWorkingHoursDisplay = "Start of the working hours";
        public const string StartOfTheWorkingHoursIsInvalid = "Start working hour's time must be between 00:00 to 23:59";
        public const string EndOfTheWorkingHoursDisplay = "End of the working hours";
        public const string EndOfTheWorkingHoursIsInvalid = "End working hour's time must be between 00:00 to 23:59";
        public const string AreWorkingHoursFlexibleRequired = "Are working hours flexible is required";
        public const string AreWorkingHoursFlexibleDisplay = "Are working hours flexible";
        public const string IsContractTypeFullTimeIsRequired = "Is contract type full time is required";
        public const string IsContractTypeFullTimeDisplay = "Is contract type full time";
        public const string PaidLeavesAllowedPerYearIsRequired = "Paid leaves allowed per year is required";
        public const string PaidLeavesAllowedPerYearDisplay = "Paid leaves allowed per year";
        public const string PaidLeavesAllowedIsInvalid = "Paid leaves allowed per year shoud be between 0 and 255.";
        public const string UnpaidLeavesAllowedPerYearIsRequired = "Unpaid leaves allowed per year is required";
        public const string UnpaidLeavesAllowedPerYearDisplay = "Unpaid leaves allowed per year";
        public const string UnpaidLeavesAllowedIsInvalid = "Unpaid leaves allowed per year shoud be between 0 and 255.";

        // PaymentInterval
        public const string PaymentIntervalDisplay = "Payment interval";
        public const string PaymentIntervalTypeIsRequired = "Type of the payment interval is required";

        // PerformanceReview
        public const string DateOfPerformanceReviewIsInvalid = "The date of the performance review can not be later than today";

        // Company
        public const int CompanyNameMinLength = 1;
        public const int CompanyNameMaxLength = 70;
        public const string CompanyNameIsInvalid = "Company name is invalid. Company name should be between 1 and 70 characters";
        public const string CompanyNameIsRequired = "Company name is required";
        public const string LogoDisplay = "Logo";
        public const string LogoIsRequired = "Logo is required";
        public const string AboutUsDisplay = "About us";
        public const string AboutUsIsRequired = "About us is required";

        // QualificationCourse
        public const string EndDateDisplay = "End date";
        public const string EndDateIsRequired = "End date is required";

        // Currency
        public const string DescriptionDisplay = "Description";
        public const string DescriptionIsRequired = "Description is required";
        public const string AbbreviationDisplay = "Abbreviation";
        public const string AbbreviationIsRequired = "Abbreviation is required";

        // EvaluationScore
        public const string RateDisplay = "Rate";
        public const string RateIsRequired = "Rate is required";

        // IdentityRole
        public const string IdentityRoleTypeDisplay = "Identity role type";
        public const string IdentityRoleTypeIsRequired = "Identity role type is required";
    }
}