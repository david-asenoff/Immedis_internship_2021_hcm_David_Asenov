namespace HCM.Common
{
    public static class GlobalConstants
    {
        // System
        public const string SystemName = "HCM";
        public const string AdministratorRoleName = "Administrator";
        public const string UserRoleName = "Employee";
        public const string SystemEmail = "immedis.internship.2021.hcm@gmail.com";

        // Email
        public const string EmailDisplay = "E-mail";
        public const string EmailIsRequired = "E-mail address is required.";
        public const string EmailIsInvalid = "E-mail is invalid.";

        // User
        public const int MinAge = 18;
        public const int MaxAge = 150;
        public const int PasswordMinLength = 5;
        public const int PasswordMaxLength = 255;
        public const string PasswordIsRequired = "Password is required.";
        public const string PasswordIsInvalid = "Password is invalid. Password must contain between 5 and 255 characters.";

        // UserName
        public const int UsernameMinLength = 5;
        public const int UsernameMaxLength = 20;
        public const string UsernameIsInvalid = "Username is invalid. Username should be between 5 and 20 characters.";
        public const string UsernameIsRequired = "Username is required.";

        // Name
        public const int NameMinLength = 1;
        public const int NameMaxLength = 40;

        // FirstName
        public const string FirstNameDisplay = "First name";
        public const string FirstNameIsRequired = "First name is required.";
        public const string FirstNameIsInvalid = "First name is invalid. First name should be between 1 and 40 characters.";

        // MiddleName
        public const string MiddleNameDisplay = "Middle name";
        public const string MiddleNameIsInvalid = "Middle name is invalid. Middle name should be between 1 and 40 characters.";

        // LastName
        public const string LastNameDisplay = "Last name";
        public const string LastNameIsRequired = "Last name is required.";
        public const string LastNameIsInvalid = "Last name is invalid. Last name should be between 1 and 40 characters.";

        // Gender
        public const string GenderIsRequired = "Gender is required.";
        public const string GenderTypeIsRequired = "Type of the gender is required.";

        // MaritalStatus
        public const string MaritalStatusDisplay = "Marital status";
        public const string MaritalStatusIsRequired = "Marital status is required.";
        public const string MaritalStatusTypeIsRequired = "Type of the marital status is required.";

        // ParentalStatus
        public const string ParentalStatusDisplay = "Parental status";
        public const string ParentalStatusIsRequired = "Parental status is required.";
        public const string ParentalStatusTypeIsRequired = "Type of the parental status is required.";

        // DateOfBirth
        public const string DateOfBirthDisplay = "Date of birth";
        public const string DateOfBirthIsRequired = "Date of birth is required.";

        // PhoneNumber
        public const string PhoneNumberDisplay = "Phone number";
        public const string PhoneNumberIsRequired = "Phone number is required.";
        public const string PhoneNumberIsInvalid = "Phone number is invalid.";

        // Address
        public const string AddressIsRequired = "Address is required.";

        // Portrait
        public const string PortraitIsRequired = "Portrait is required.";

        // CV
        public const string CVIsRequired = "CV is required.";

        // Department
        public const string DepartmentIsRequired = "Department is required.";
        public const string DepartmentNameIsRequired = "Name of the department is required.";

        // Possition
        public const string PossitionIsRequired = "Possition is required.";
        public const string PossitionNameIsRequired = "Name of the possition is required.";

        // Salary
        public const string SalaryIsRequired = "Salary is required.";

        // Contract
        public const string EmployeeIsRequired = "Employee is required.";
        public const string StartDateDisplay = "Start date";
        public const string StartDateIsRequired = "Start date is required.";
        public const string StartOfTheWorkingHoursDisplay = "Start of the working hours";
        public const string StartOfTheWorkingHoursIsInvalid = "Start working hour's time must be between 00:00 to 23:59";
        public const string EndOfTheWorkingHoursDisplay = "End of the working hours";
        public const string EndOfTheWorkingHoursIsInvalid = "End working hour's time must be between 00:00 to 23:59";
        public const string AreWorkingHoursFlexibleRequired = "Are working hours flexible is required";
        public const string AreWorkingHoursFlexibleDisplay = "Are working hours flexible";
        public const string IsContractTypeFullTimeRequired = "Is contract type full time is required";
        public const string IsContractTypeFullTimeDisplay = "Is contract type full time";

        // PaymentInterval
        public const string PaymentIntervalDisplay = "Payment interval";
        public const string PaymentIntervalTypeIsRequired = "Type of the payment interval is required.";
    }
}