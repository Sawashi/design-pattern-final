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

        public MainForm()
        {
            // Initialize UI components and controls
            // InitializeValidationFramework();
        }
    }

    // Data object with properties marked for validation, delete later
    public class DataObject
    {
        [Validation] // Marking a property for validation
        public string StringField { get; set; }

        [Validation] // Marking another property for validation
        public int NumericField { get; set; }
    }
}
