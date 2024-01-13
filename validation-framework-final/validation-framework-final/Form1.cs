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
        public Form1()
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;
            validationFramework = new ValidationFramework();
            label1.Hide();
            // Add the EmailValidationStrategy to the ValidationFramework
            validationFramework.AddValidationStrategy(new EmailValidationStrategy());
        }
        public Form1(string typePattern)
        {
            this.typePattern = typePattern;
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;
            validationFramework = new ValidationFramework();
            label1.Hide();
            // Add the EmailValidationStrategy to the ValidationFramework
            validationFramework.AddValidationStrategy(new EmailValidationStrategy());
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            string input = textBox1.Text;
            switch (typePattern)
            {
                case "strategy":
                    {
                        //Process validation using all registered strategies
                        bool validationResult = validationFramework.validateMail(input);

                        // Display the result
                        if (validationResult)
                        {

                            //MessageBox.Show("Input is a valid email address.");
                            //textBox1.BackColor = Color.Green;
                            label1.Text = "Input is a valid email address.";
                            label1.BackColor = Color.Green;
                            label1.Show();
                        }
                        else
                        {
                            //textBox1.BackColor = Color.Red;
                            label1.Text = "Input is not a valid email address.";
                            label1.BackColor = Color.Red;
                            label1.Show();
                            //MessageBox.Show("Input is not a valid email address.");
                        }
                        break;
                    }
            }
        }
        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            label1.Hide();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
