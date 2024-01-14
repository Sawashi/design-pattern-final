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
            // Execute all validators in the list
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
}
