using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace validation_framework_final
{
    public interface ICustomValidator : IValidator
    {
        bool Validate(string input);
    }
    public class CustomValidatorFactory
    {
        public ICustomValidator CreateValidator(string validatorType)
        {
            switch (validatorType)
            {
                case "String":
                    return new StringValidator();
                case "Numeric":
                    return new NumericValidator();
                // Add more cases for different validator types as needed
                default:
                    throw new ArgumentException("Invalid validator type");
            }
        }
    }
    public class StringValidator : ICustomValidator
    {
        public bool Validate(string input)
        {
            // Implement validation logic for strings
            return !string.IsNullOrEmpty(input);
        }
    }
    public class NumericValidator : ICustomValidator
    {
        public bool Validate(string input)
        {
            // Implement validation logic for numeric values
            return int.TryParse(input, out _);
        }
    }
}
