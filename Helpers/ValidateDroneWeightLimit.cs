using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace drones_api.Helpers
{
    public class ValidateDroneWeightLimit : ValidationAttribute
    {
        public string GetErrorMessage() =>
            $"Weight limit cannot be greater than 500gr or less than or equal 0.";

        protected override ValidationResult IsValid(object value,
            ValidationContext validationContext)
        {
            var weightLimit = (decimal)value;

            if ( weightLimit <= 0 && weightLimit > 500)
            {
                return new ValidationResult(GetErrorMessage());
            }

            return ValidationResult.Success;
        }
    }
}
