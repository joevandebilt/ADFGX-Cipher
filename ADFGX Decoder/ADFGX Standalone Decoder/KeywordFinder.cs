using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace ADFGXDecoder
{
    public partial class KeywordFinder : Form
    {
        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            Application.Exit();
        }

        public KeywordFinder()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string Input;
            string[] strArray;
            string[] strOutput;
            int Counter = 0;

            Input = txtWords.Text;
            strArray = Input.Split(' ');
            strOutput = new string[strArray.Length];

            bool isOK = true;
            //int i = 0;

            char[] characters;

            for (int index = 0; index < strArray.Length; index++)
            {
                int WordLength = strArray[index].Length;

                characters = new char[WordLength];
                characters = strArray[index].ToCharArray();
                int[] Letters = new int[WordLength];

                for (int i = 0; i < WordLength; i++)
                {
                    Letters[i] = Convert.ToInt32(characters[i]);
                }
                isOK = true;


                MessageBox.Show(string.Concat("The total number of found words is ", Counter));

                txtOutput.Text = strOutput[0];
            }
            for (int index = 1; index <= Counter; index++)
            {
                txtOutput.Text = string.Concat(txtOutput.Text, Environment.NewLine, strOutput[index]);
            }
            
        }

        private void cmdClear_Click(object sender, EventArgs e)
        {
            txtOutput.Text = "";
            txtWords.Text = "";
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
        }

        private void button2_Click(object sender, EventArgs e)
        {
            MainMenu newform = new MainMenu();
            newform.Show();
            this.Hide();
        }




    }
}
