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
            
            int L1 = 0;
            int L2 = 0;
            int L3 = 0;
            int L4 = 0;
            int L5 = 0;
            int L6 = 0;
            bool isOK = true;
            //int i = 0;

            char[] characters;

            for (int index = 0; index < strArray.Length; index++)
            {
                if (strArray[index].Length == 6)
                {
                    characters = new char[6];
                    characters = strArray[index].ToCharArray();

                    L1 = Convert.ToInt32(characters[0]);
                    L2 = Convert.ToInt32(characters[1]);
                    L3 = Convert.ToInt32(characters[2]);
                    L4 = Convert.ToInt32(characters[3]);
                    L5 = Convert.ToInt32(characters[4]);
                    L6 = Convert.ToInt32(characters[5]);

                    if ((L1 > L3 && L1 > L4 && L1 > L5 && L1 > L6) && (L2 > L3 && L2 > L4 && L2 > L5 && L2 > L6))
                    {

                        if (L1 == L2 || L1 == L3 || L1 == L4 || L1 == L5 || L1 == L6) isOK = false;
                        if (L2 == L3 || L2 == L4 || L2 == L5 || L2 == L6) isOK = false;
                        if (L3 == L4 || L3 == L5 || L3 == L6) isOK = false;
                        if (L4 == L5 || L4 == L6) isOK = false;
                        if (L5 == L6) isOK = false;

                        if (isOK == true)
                        {
                            strOutput[Counter] = strArray[index];
                            Counter++;
                        }
                    }
                }
                isOK = true;
            }

                MessageBox.Show(string.Concat("The total number of found words is ", Counter));

                txtOutput.Text = strOutput[0];

                for (int index = 1; index <= Counter; index++)
                {
                    txtOutput.Text = string.Concat(txtOutput.Text, Environment.NewLine , strOutput[index]);
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
