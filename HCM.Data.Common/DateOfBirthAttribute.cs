namespace HCM.Data.Common
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using HCM.Common;

    /// <summary>
    /// Validates DateTime object that are before 18-150 years from today. Any other date will not be valid.
    /// </summary>
    public class DateOfBirthAttribute : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            if (value is DateTime)
            {
                DateTime date = Convert.ToDateTime(value);

                // 365 days * 18 years ~ 6570 days
                var minYears = new TimeSpan((365 * GlobalConstants.MinAge), 0, 0, 0, 0);
                var maxYears = new TimeSpan((365 * GlobalConstants.MaxAge), 0, 0, 0, 0);

                if (date >= DateTime.Today - minYears)
                {
                    return new ValidationResult($"You must be {GlobalConstants.MinAge} years or older to register.");
                }
                else if (date >= DateTime.Today - maxYears)
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
