using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace validation_framework_final
{
    // Interface for custom validation
    public interface ICustomValidator
    {
        bool Validate(string input);
    }

    // Factory for creating custom validators
    public class CustomValidatorFactory
    {
        private readonly Dictionary<string, ICustomValidator> customValidators = new Dictionary<string, ICustomValidator>();

        public void RegisterCustomValidator(string validationKey, ICustomValidator customValidator)
        {
            if (customValidator == null)
            {
                throw new ArgumentNullException(nameof(customValidator));
            }

            customValidators[validationKey] = customValidator;
        }

        public bool ValidateWithCustomValidator(string validationKey, string input)
        {
            if (customValidators.TryGetValue(validationKey, out var customValidator))
            {
                return customValidator.Validate(input);
            }

            // No custom validator found for the given key
            throw new InvalidOperationException($"No custom validator found for key: {validationKey}");
        }
    }

    // Example of a custom validator
    public class ExampleCustomValidator : ICustomValidator
    {
        public bool Validate(string input)
        {
            // Implement custom validation logic
            // You can customize this method based on your specific requirements
            return !string.IsNullOrWhiteSpace(input);
        }
    }
}
