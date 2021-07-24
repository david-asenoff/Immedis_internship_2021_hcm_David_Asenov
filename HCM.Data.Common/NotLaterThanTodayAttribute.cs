namespace HCM.Data.Common
{
    using System;
    using System.ComponentModel.DataAnnotations;

    /// <summary>
    /// Validates DateTime object that are not later than today. Any other date will not be valid.
    /// </summary>
    public class NotLaterThanTodayAttribute : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            DateTime date = (DateTime)value;
            if (date <= DateTime.UtcNow)
            {
                return ValidationResult.Success;
            }

            return new ValidationResult(ErrorMessage ?? "Make sure the date is not later than today");
        }

    }
}
