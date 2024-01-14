using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace validation_framework_final
{
    public partial class Form1 : Form, IValidationObserver
    {
        private string typePattern;
        private ValidationFramework validationFramework;
        private IErrorMessageDecorator errorDecorator;
        private CustomValidatorFactory validatorFactory;

        public Form1(string typePattern, ValidationFramework validationFramework)
        {
            InitializeComponent();
            label1.Hide();
            this.StartPosition = FormStartPosition.CenterScreen;
            this.validationFramework = validationFramework;
            this.validatorFactory = new CustomValidatorFactory();

            // Add the EmailValidationStrategy to the ValidationFramework
            validationFramework.AddValidationStrategy(new EmailValidationStrategy());

            // Decorate error messages with SeverityDecorator and FormatDecorator
            errorDecorator = new SeverityDecorator(new FormatDecorator(null));

            // Subscribe this form as an observer to the validation framework
            validationFramework.SubscribeObserver(this);
        }

        public void UpdateValidationStatus(bool isValid, List<string> errorMessages)
        {
            Console.WriteLine($"{Name} Validation Status: {isValid}");

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
            
                label1.Text = isValid ? "Validation Passed" : "Validation Failed";
                label1.BackColor = isValid ? System.Drawing.Color.Green : System.Drawing.Color.Red;
                label1.Show();
            
            // Add more conditions as needed for other UI components
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string input = textBox1.Text;
            // Use the factory to create a custom validator based on some criteria
            ICustomValidator customValidator = validatorFactory.CreateValidator("String");

            // Create composite validator and add the custom validator to the list
            // If there are more than 1 validator they should all be added to the list
            // The composite validator will go through every children in the list, call the validate method and let the children handle the real work
            CompositeValidator compositeValidator = new CompositeValidator();
            compositeValidator.AddValidator(customValidator);

            // Process validation using the selected strategy and custom validator
            bool validationResult = validationFramework.Validate(input) && compositeValidator.Validate(input);

            // Decorate error messages
            List<string> errorMessages = new List<string> { validationResult ? "Input is valid." : "Input is not valid." };
            string decoratedMessages = errorDecorator.Decorate(errorMessages);

            // Display the result
            label1.Text = decoratedMessages;
            label1.BackColor = validationResult ? Color.Green : Color.Red;
            label1.Show();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            label1.Hide();
        }
        // Handle the Form1 Load event
        private void Form1_Load(object sender, EventArgs e)
        {
            // Implement any necessary logic here, or leave it empty if not needed
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }
    }
}
