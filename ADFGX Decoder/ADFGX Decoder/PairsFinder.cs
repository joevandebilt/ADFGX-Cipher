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
    public partial class frmPairFinder : Form
    {
        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            Application.Exit();
        }

        string[] Pairs = new string[25] { "AA", "AD", "AF", "AG", "AX", "DA", "DD", "DF", "DG", "DX", "FA", "FD", "FF", "FG", "FX", "GA", "GD", "GF", "GG", "GX", "XA", "XD", "XF", "XG", "XX" };
        int[] Tally = new int[25];

        public frmPairFinder()
        {
            InitializeComponent();
        }

        private void cmdSort_Click(object sender, EventArgs e)
        {
            int index = 0;
            int temp;
            string stringtemp;


                while (index < 24)
                {
                    if (Tally[index] < Tally[index + 1])
                    {
                        temp = Tally[index];
                        Tally[index] = Tally[index + 1];
                        Tally[index+1] = temp;

                        stringtemp = Pairs[index];
                        Pairs[index] = Pairs[index + 1];
                        Pairs[index + 1] = stringtemp;

                        index = 0;
                    }
                    else if (Tally[index] == Tally[index + 1])
                    {
                        index++;
                    }
                    else
                    {
                        index++;
                    }
                }

                rtbOutput.Clear();
                rtbOutput.AppendText("Pair\tFrequency\n");

                for (index = 0; index < 25; index++)
                {
                    rtbOutput.AppendText(string.Concat(Pairs[index], "\t", Tally[index], "\n"));
                }

        }

        private void cmdMainMenu_Click(object sender, EventArgs e)
        {
            MainMenu newform = new MainMenu();
            newform.Show();
            this.Hide();
        }

        private void cmdFindPairs_Click(object sender, EventArgs e)
        {           
            rtbOutput.Clear();

            string input = rtbInput.Text;
            string Pair = string.Empty;
            bool PairFound;
            int counter;
            int index;

            for (index = 0; index < 25; index++)
            {
                Tally[index] = 0;
            }

            //MessageBox.Show(input);

            for (counter = 0; counter < (input.Length -1); counter = counter + 2)
            {
                Pair = string.Concat(input[counter], input[counter + 1]);
                //MessageBox.Show(Pair);

                if (Pair != "--" || Pair != "\r\n")
                {
                    index = 0;
                    PairFound = false;
                    while (PairFound == false && index < 25)
                    {
                        if (Pair == Pairs[index])
                        {
                            Tally[index] = Tally[index] + 1;
                            PairFound = true;
                        }
                        index++;
                    }
                }
            }

            rtbOutput.AppendText("Pair\tFrequency\n");

            for (index = 0; index < 25; index++)
            {
                rtbOutput.AppendText(string.Concat(Pairs[index], "\t", Tally[index] , "\n"));
            }


        }

    }
}
