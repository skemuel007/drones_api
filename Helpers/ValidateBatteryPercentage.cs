using System.ComponentModel.DataAnnotations;

namespace drones_api.Helpers
{
    public class ValidateBatteryPercentage : ValidationAttribute
    {
        public string GetErrorMessage() =>
            $"Battery percentage cannot be greater than 100 or less than 0.";

        protected override ValidationResult IsValid(object value,
            ValidationContext validationContext)
        {
            var batteryPercentage = (int)value;

            if (batteryPercentage < 0 && batteryPercentage > 500)
            {
                return new ValidationResult(GetErrorMessage());
            }

            return ValidationResult.Success;
        }
    }
}
