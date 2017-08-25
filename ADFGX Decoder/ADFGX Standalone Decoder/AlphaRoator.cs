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
    public partial class AlphaRoator : Form
    {
        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            Application.Exit();
        }

        public AlphaRoator()
        {
            InitializeComponent();
            rbtNumValue.Checked = true;
        }

        private void cmdDecode_Click(object sender, EventArgs e)
        {
            rtbOutput.Clear();

            int NumOfLoops = 0;

            if (rbtNumValue.Checked == true) NumOfLoops = 1;
            else if (rbtAutoShift.Checked == true) NumOfLoops = 26;
            
            int ROT = 0;

            for (int i = 0; i < NumOfLoops; i++)
            {

                if (rbtNumValue.Checked == true) ROT = Convert.ToInt32(numShift.Value);
                else if (rbtAutoShift.Checked == true) ROT++;

                rtbOutput.AppendText(Environment.NewLine + Environment.NewLine + ROT + Environment.NewLine + Environment.NewLine);

                //label1.Text = string.Concat(ROT);

                char[] CharArray = rtbInput.Text.ToUpper().ToCharArray();

                for (int index = 0; index < CharArray.Length; index++)
                {
                    char newCharacter = CharArray[index];
                    int value = Convert.ToInt16(CharArray[index]);

                    if (value > 65 && value < 90)
                    {
                        //MessageBox.Show(string.Concat("Value is: ", value));

                        if ((value + ROT) > 90) value = (value + ROT) - 26;
                        else value = value + ROT;
                        newCharacter = Convert.ToChar(value);
                    }
                    if (rtbOutput.Text == "") rtbOutput.Text = string.Concat(newCharacter);
                    else rtbOutput.AppendText(string.Concat(newCharacter));

                }
                
            }
            
        }

        private void rbtNumValue_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            MainMenu newform = new MainMenu();
            newform.Show();
            this.Hide();
        }
    }
}
