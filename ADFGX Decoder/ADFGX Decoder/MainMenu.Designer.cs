namespace ADFGXDecoder
{
    partial class MainMenu
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.cmdFinder = new System.Windows.Forms.Button();
            this.cmdDecoder = new System.Windows.Forms.Button();
            this.cmdQuit = new System.Windows.Forms.Button();
            this.cmdAlphaRot = new System.Windows.Forms.Button();
            this.cmdPairs = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // cmdFinder
            // 
            this.cmdFinder.Location = new System.Drawing.Point(76, 25);
            this.cmdFinder.Name = "cmdFinder";
            this.cmdFinder.Size = new System.Drawing.Size(133, 37);
            this.cmdFinder.TabIndex = 0;
            this.cmdFinder.Text = "Keyword Finder";
            this.cmdFinder.UseVisualStyleBackColor = true;
            this.cmdFinder.Click += new System.EventHandler(this.cmdFinder_Click);
            // 
            // cmdDecoder
            // 
            this.cmdDecoder.Location = new System.Drawing.Point(76, 68);
            this.cmdDecoder.Name = "cmdDecoder";
            this.cmdDecoder.Size = new System.Drawing.Size(133, 37);
            this.cmdDecoder.TabIndex = 1;
            this.cmdDecoder.Text = "Decoder";
            this.cmdDecoder.UseVisualStyleBackColor = true;
            this.cmdDecoder.Click += new System.EventHandler(this.cmdDecoder_Click);
            // 
            // cmdQuit
            // 
            this.cmdQuit.Location = new System.Drawing.Point(76, 196);
            this.cmdQuit.Name = "cmdQuit";
            this.cmdQuit.Size = new System.Drawing.Size(133, 37);
            this.cmdQuit.TabIndex = 2;
            this.cmdQuit.Text = "Quit";
            this.cmdQuit.UseVisualStyleBackColor = true;
            this.cmdQuit.Click += new System.EventHandler(this.cmdQuit_Click);
            // 
            // cmdAlphaRot
            // 
            this.cmdAlphaRot.Location = new System.Drawing.Point(76, 110);
            this.cmdAlphaRot.Name = "cmdAlphaRot";
            this.cmdAlphaRot.Size = new System.Drawing.Size(133, 37);
            this.cmdAlphaRot.TabIndex = 3;
            this.cmdAlphaRot.Text = "Alphabet Rotator";
            this.cmdAlphaRot.UseVisualStyleBackColor = true;
            this.cmdAlphaRot.Click += new System.EventHandler(this.cmdAlphaRot_Click_1);
            // 
            // cmdPairs
            // 
            this.cmdPairs.Location = new System.Drawing.Point(76, 153);
            this.cmdPairs.Name = "cmdPairs";
            this.cmdPairs.Size = new System.Drawing.Size(133, 37);
            this.cmdPairs.TabIndex = 3;
            this.cmdPairs.Text = "Pairs Finder";
            this.cmdPairs.UseVisualStyleBackColor = true;
            this.cmdPairs.Click += new System.EventHandler(this.cmdPairs_Click_1);
            // 
            // MainMenu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 262);
            this.Controls.Add(this.cmdPairs);
            this.Controls.Add(this.cmdAlphaRot);
            this.Controls.Add(this.cmdQuit);
            this.Controls.Add(this.cmdDecoder);
            this.Controls.Add(this.cmdFinder);
            this.Name = "MainMenu";
            this.Text = "Main Menu";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button cmdFinder;
        private System.Windows.Forms.Button cmdDecoder;
        private System.Windows.Forms.Button cmdQuit;
        private System.Windows.Forms.Button cmdAlphaRot;
        private System.Windows.Forms.Button cmdPairs;
    }
}