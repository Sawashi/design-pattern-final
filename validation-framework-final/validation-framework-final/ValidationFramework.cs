using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace validation_framework_final
{
    // Class representing the ValidationFramework
    public class ValidationFramework
    {
        public void mailValidationWindow()
        {
            // Instantiate your main form
            Form1 mainForm = new Form1("strategy");

            // Run the application
            Application.Run(mainForm);
        }
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
            return false;
        }
        public bool validateMail(string value)
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
