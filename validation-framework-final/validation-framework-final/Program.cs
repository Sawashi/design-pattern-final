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
            validationFramework.MailValidationWindow();
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
