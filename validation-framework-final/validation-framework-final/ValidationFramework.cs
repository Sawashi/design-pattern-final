using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace validation_framework_final
{
    // Class representing the ValidationFramework
    public class ValidationFramework
    {
        private readonly List<IValidationStrategy> strategies;

        public ValidationFramework()
        {
            strategies = new List<IValidationStrategy>();
        }

        public void AddValidationStrategy(IValidationStrategy strategy)
        {
            strategies.Add(strategy);
        }

        public bool ProcessValidation(string value)
        {
            // Process validation using all registered strategies
            foreach (var strategy in strategies)
            {
                if (!strategy.Validate(value))
                {
                    // Validation failed
                    Console.WriteLine("Validation failed using strategy: " + strategy.GetType().Name);
                    return false;
                }
            }

            // All validations passed
            Console.WriteLine("Validation passed using all strategies.");
            return true;
        }
    }
}
