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
    public partial class MainMenu : Form
    {
        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            Application.Exit();
        }

        public MainMenu()
        {
            InitializeComponent();
        }

        private void cmdQuit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void cmdFinder_Click(object sender, EventArgs e)
        {
            KeywordFinder newform = new KeywordFinder();
            newform.Show();
            this.Hide();
        }

        private void cmdDecoder_Click(object sender, EventArgs e)
        {
            Decoder newform = new Decoder();
            newform.Show();
            this.Hide();
        }

        private void cmdAlphaRot_Click_1(object sender, EventArgs e)
        {
            AlphaRoator newform = new AlphaRoator();
            newform.Show();
            this.Hide();
        }

        private void cmdPairs_Click_1(object sender, EventArgs e)
        {
            frmPairFinder newform = new frmPairFinder();
            newform.Show();
            this.Hide();
        }

    }
}
