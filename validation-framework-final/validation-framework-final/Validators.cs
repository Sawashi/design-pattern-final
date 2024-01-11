using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace validation_framework_final
{
    public interface IValidator
    {
        bool Validate(string input);
    }

    // Composite validator implementing the composite pattern
    public class CompositeValidator : IValidator
    {
        private readonly List<IValidator> validators = new List<IValidator>();

        public void AddValidator(IValidator validator)
        {
            validators.Add(validator);
        }

        public bool Validate(string input)
        {
            // Execute all validators in the composite
            foreach (var validator in validators)
            {
                if (!validator.Validate(input))
                {
                    // Validation failed for at least one validator
                    return false;
                }
            }

            // All validators passed
            return true;
        }
    }

    // Regular expression validator implementing the strategy pattern
    public class RegularExpressionValidator : IValidator
    {
        private readonly string regexPattern;

        public RegularExpressionValidator(string regexPattern)
        {
            this.regexPattern = regexPattern;
        }

        public bool Validate(string input)
        {
            // Implement regular expression validation logic
            return System.Text.RegularExpressions.Regex.IsMatch(input, regexPattern);
        }
    }

    // Custom validator implementing the strategy pattern
    public class CustomValidator : IValidator
    {
        // You can add any necessary properties or dependencies for custom validation

        public bool Validate(string input)
        {
            // Implement custom validation logic
            // Consider using any additional properties or dependencies you added
            return true; // Placeholder, replace with actual custom validation logic
        }
    }

    // Factory class for basic type validators
    public static class BasicTypeValidators
    {
        public static IValidator CreateStringValidator()
        {
            var compositeValidator = new CompositeValidator();
            // Add string validation checks (e.g., not empty, length constraints, etc.)
            compositeValidator.AddValidator(new RegularExpressionValidator("your_string_regex_pattern"));
            compositeValidator.AddValidator(new CustomValidator()); // You can add more validators as needed
            return compositeValidator;
        }

        public static IValidator CreateNumericValidator()
        {
            var compositeValidator = new CompositeValidator();
            // Add numeric validation checks (e.g., range constraints, etc.)
            compositeValidator.AddValidator(new CustomValidator()); // You can add more validators as needed
            return compositeValidator;
        }

        // Add more methods for other basic types if necessary
    }
}
