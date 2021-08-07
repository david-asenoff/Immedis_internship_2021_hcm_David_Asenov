namespace HCM.Data.Common
{
    using System;
    using System.ComponentModel.DataAnnotations;

    /// <summary>
    /// Validates DateTime object that are before 18-150 years from today. Any other date will not be valid.
    /// </summary>
    public class DateOfBirthAttribute : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            if (value is DateTime)
            {
                // Value as birthdate
                DateTime birthdate = Convert.ToDateTime(value);

                // Save today's date.
                var today = DateTime.Today;

                // Calculate the age.
                var age = today.Year - birthdate.Year;

                if (age < GlobalConstants.MinAge)
                {
                    return new ValidationResult($"You must be {GlobalConstants.MinAge} years or older to register.");
                }
                else if (age > GlobalConstants.MaxAge)
                {
                    return new ValidationResult($"You must be below {GlobalConstants.MaxAge} years old to register.");
                }
                else
                {
                    return ValidationResult.Success;
                }
            }
            else
            {
                return new ValidationResult("Date of birth may contain only a valid date.");
            }

        }
    }
}
