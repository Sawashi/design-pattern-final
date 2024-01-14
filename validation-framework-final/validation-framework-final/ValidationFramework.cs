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
        private readonly List<IValidationStrategy> strategies;
        private readonly List<IValidationObserver> observers;
        public void MailValidationWindow()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            // Create an instance of Form1 and pass the ValidationFramework to it
            Form1 mainForm = new Form1("strategy", this);

            // Run the application
            Application.Run(mainForm);
        }
        public ValidationFramework()
        {
            strategies = new List<IValidationStrategy>();
            observers = new List<IValidationObserver>();
        }

        public void AddValidationStrategy(IValidationStrategy strategy)
        {
            strategies.Add(strategy);
        }

        public void SubscribeObserver(IValidationObserver observer)
        {
            observers.Add(observer);
        }

        public void UnsubscribeObserver(IValidationObserver observer)
        {
            observers.Remove(observer);
        }

        public bool Validate(string value)
        {
            // Process validation using all registered strategies
            foreach (var strategy in strategies)
            {
                if (!strategy.Validate(value))
                {
                    // Validation failed
                    NotifyObservers(false, new List<string> { $"Validation failed using strategy: {strategy.GetType().Name}" });
                    return false;
                }
            }

            // All validations passed
            NotifyObservers(true, new List<string> { "Validation passed using all strategies." });
            return true;
        }

        private void NotifyObservers(bool isValid, List<string> errorMessages)
        {
            foreach (var observer in observers)
            {
                observer.UpdateValidationStatus(isValid, errorMessages);
            }
        }
    }
}
