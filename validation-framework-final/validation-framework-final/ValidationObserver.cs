using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace validation_framework_final
{
    // Define the observer interface
    public interface IValidationObserver
    {
        void UpdateValidationStatus(bool isValid, List<string> errorMessages);
    }

    // Concrete implementation of the observer
    public class ValidationObserver : IValidationObserver
    {
        private readonly string componentName; // Name of the UI component being observed

        public ValidationObserver(string componentName)
        {
            this.componentName = componentName;
        }

        public void UpdateValidationStatus(bool isValid, List<string> errorMessages)
        {
            // Update the UI component based on validation status
            Console.WriteLine($"{componentName} Validation Status: {isValid}");

            // Display error messages if any
            if (!isValid)
            {
                Console.WriteLine("Error Messages:");
                foreach (var errorMessage in errorMessages)
                {
                    Console.WriteLine($"- {errorMessage}");
                }
            }

            // Additional logic to update UI components as needed
        }
    }
}