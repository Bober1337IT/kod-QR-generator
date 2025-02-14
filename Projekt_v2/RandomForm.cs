using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Projekt_v2
{
    public partial class RandomStringForm : Form
    {
        public RandomStringForm()
        {
            InitializeComponent();
        }

        public string GeneratedText;

        private void btnGenerate_Click(object sender, EventArgs e)
        {

            if (int.TryParse(textBox1.Text, out int length) && length > 0 && length < 1663 )
            {
                GeneratedText = GenerateRandomString(length);
            }
            else
            {
                if (length > 1662)
                {
                    MessageBox.Show("Proszę wprowadzić krótszą liczbe (max: 1662).");
                }
                else
                {
                    MessageBox.Show("Proszę wprowadzić poprawną liczbę.");
                }
            }

            Thread.Sleep(500);
            this.Close();
        }

        private string GenerateRandomString(int length)
        {
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789";
            Random random = new Random();
            string result = "";

            for (int i = 0; i < length; i++)
            {
                int index = random.Next(chars.Length);
                result += chars[index];
            }

            return result;
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Thread.Sleep(500);
            this.Close();
        }
    }
}
