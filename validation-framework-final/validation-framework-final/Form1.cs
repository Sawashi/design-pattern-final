using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace validation_framework_final
{
    public partial class Form1 : Form
    {
        private string typePattern;
        private ValidationFramework validationFramework;
        private ValidationObserver validationObserver;
        private IErrorMessageDecorator errorDecorator;

        public Form1()
        {
            InitializeComponent();
            label1.Hide();
            this.StartPosition = FormStartPosition.CenterScreen;
            validationFramework = new ValidationFramework();
            errorDecorator = new SeverityDecorator(new FormatDecorator(null));

            // Add the EmailValidationStrategy to the ValidationFramework
            validationFramework.AddValidationStrategy(new EmailValidationStrategy());

            // Subscribe the observer to the validation framework
            validationObserver = new ValidationObserver(validationFramework, label1);
        }
        public Form1(string typePattern, ValidationFramework validationFramework)
        {
            InitializeComponent();
            label1.Hide();
            this.StartPosition = FormStartPosition.CenterScreen;
            this.validationFramework = validationFramework;
            errorDecorator = new SeverityDecorator(new FormatDecorator(null));

            // Add the EmailValidationStrategy to the ValidationFramework
            validationFramework.AddValidationStrategy(new EmailValidationStrategy());

            // Subscribe the observer to the validation framework
            validationObserver = new ValidationObserver(validationFramework, label1);
        }

        public Form1(string typePattern) : this()
        {
            this.typePattern = typePattern;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string input = textBox1.Text;

            // Process validation using the selected strategy
            bool validationResult = validationFramework.Validate(input);

            // Decorate error messages
            List<string> errorMessages = new List<string> { validationResult ? "Input is a valid email address." : "Input is not a valid email address." };
            List<string> decoratedMessages = errorDecorator.Decorate(errorMessages);

            // Display the result
            label1.Text = string.Join(Environment.NewLine, decoratedMessages);
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
