using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace validation_framework_final
{
    // Define the strategy interface
    public interface IValidationStrategy
    {
        bool Validate(string input);
    }

    // Concrete strategy for manual validation
    public class ManualValidationStrategy : IValidationStrategy
    {
        public bool Validate(string input)
        {
            // Implement manual validation logic
            // You can customize this method based on your specific requirements
            return !string.IsNullOrWhiteSpace(input);
        }
    }

    // Concrete strategy for attribute-based validation
    public class AttributeValidationStrategy : IValidationStrategy
    {
        public bool Validate(string input)
        {
            // Implement attribute-based validation logic
            // You can customize this method based on your specific requirements
            return !string.IsNullOrEmpty(input);
        }
    }

    // Concrete strategy for regular expression validation
    public class RegexValidationStrategy : IValidationStrategy
    {
        private readonly string regexPattern;

        public RegexValidationStrategy(string regexPattern)
        {
            this.regexPattern = regexPattern;
        }

        public bool Validate(string input)
        {
            // Implement regular expression validation logic
            // You can customize this method based on your specific requirements
            return System.Text.RegularExpressions.Regex.IsMatch(input, regexPattern);
        }
    }

    // Concrete strategy for custom validation
    public class CustomValidationStrategy : IValidationStrategy
    {
        // You can add any necessary properties or dependencies for custom validation

        public bool Validate(string input)
        {
            // Implement custom validation logic
            // You can customize this method based on your specific requirements
            // Consider using any additional properties or dependencies you added
            return true; // Placeholder, replace with actual custom validation logic
        }
    }
}
