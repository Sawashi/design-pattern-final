using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace validation_framework_final
{
    public partial class Form1 : Form
    {
        private ValidationFramework validationFramework;
        public Form1()
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;
            validationFramework = new ValidationFramework();

            // Add the EmailValidationStrategy to the ValidationFramework
            validationFramework.AddValidationStrategy(new EmailValidationStrategy());
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            string input = textBox1.Text;
            // Process validation using all registered strategies
            bool validationResult = validationFramework.ProcessValidation(input);

            // Display the result
            if (validationResult)
            {
                MessageBox.Show("Input is a valid email address.");
            }
            else
            {
                MessageBox.Show("Input is not a valid email address.");
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
