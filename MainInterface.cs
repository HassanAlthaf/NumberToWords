/***
 *   Copyright © 2015, Hassan Althaf.
 **/
using System;
using System.Windows.Forms;

namespace NumberToWords
{
    public partial class MainInterface : Form
    {
        public MainInterface()
        {
            InitializeComponent();
        }

        private void MainInterface_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            string input = textBox1.Text;
            int numberToConvert;

            if (int.TryParse(input, out numberToConvert))
            {
                if (numberToConvert < -1000000 || numberToConvert > 1000000)
                {
                    label3.Text = "Invalid range, please enter a number between 0 and 1 million inclusively";
                } else
                {
                    label3.Text = NumberToWordsConverter.ConvertToString(numberToConvert);
                }
            }
            else
            {
                label3.Text = "Please enter a valid number";
            }
            
        }
    }
}
