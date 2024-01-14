using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
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
        private readonly Control uiComponent; // UI component being observed

        public ValidationObserver(ValidationFramework validationFramework, Control uiComponent)
        {
            this.uiComponent = uiComponent;
            validationFramework.SubscribeObserver(this);
        }

        public void UpdateValidationStatus(bool isValid, List<string> errorMessages)
        {
            // Update the UI component based on validation status
            Console.WriteLine($"{uiComponent.Name} Validation Status: {isValid}");

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
            UpdateUI(isValid, errorMessages);
        }

        private void UpdateUI(bool isValid, List<string> errorMessages)
        {
            // Update UI components based on validation status
            if (uiComponent is Label label)
            {
                label.Text = isValid ? "Validation Passed" : "Validation Failed";
                label.BackColor = isValid ? Color.Green : Color.Red;
                label.Show();
            }
        }
    }
}