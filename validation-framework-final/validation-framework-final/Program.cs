using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace validation_framework_final
{
    static class Program
    {
        [STAThread]
        static void Main()
        {
            ValidationFramework validationFramework = new ValidationFramework();
            validationFramework.mailValidationWindow();
        }
    }

    public class MainForm : Form
    {
        // You can add UI components and controls here

        public MainForm()
        {
            // Initialize UI components and controls

            // Example of integrating the validation framework
            // InitializeValidationFramework();
        }

        //private void InitializeValidationFramework()
        //{
        //    // Example of creating and using validators
        //    IValidator stringValidator = BasicTypeValidators.CreateStringValidator();
        //    IValidator numericValidator = BasicTypeValidators.CreateNumericValidator();

        //    // Example of creating and using custom validators
        //    var customValidatorFactory = new CustomValidatorFactory();
        //    customValidatorFactory.RegisterCustomValidator("exampleKey", new ExampleCustomValidator());

        //    // Example of processing validations
        //    var validators = new List<IValidator> { stringValidator, numericValidator };
        //    var validationProcessor = new ValidationProcessor(validators);

        //    // Example of using the validation processor on an object
        //    var dataObject = new DataObject(); // Replace with your actual data object
        //    bool isValid = validationProcessor.ProcessValidation(dataObject);

        //    if (isValid)
        //    {
        //        // Handle the case when all validations pass
        //        Console.WriteLine("Validation passed. Do something...");
        //    }
        //    else
        //    {
        //        // Handle the case when validations fail
        //        Console.WriteLine("Validation failed. Handle errors...");
        //    }
        //}
    }

    // Example data object with properties marked for validation
    public class DataObject
    {
        [Validation] // Example of marking a property for validation
        public string StringField { get; set; }

        [Validation] // Example of marking another property for validation
        public int NumericField { get; set; }
    }
}
