namespace ADFGXDecoder
{
    partial class frmPairFinder
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
            this.rtbInput = new System.Windows.Forms.RichTextBox();
            this.cmdFindPairs = new System.Windows.Forms.Button();
            this.cmdMainMenu = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.rtbOutput = new System.Windows.Forms.RichTextBox();
            this.Output = new System.Windows.Forms.Label();
            this.cmdSort = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // rtbInput
            // 
            this.rtbInput.Location = new System.Drawing.Point(25, 24);
            this.rtbInput.Name = "rtbInput";
            this.rtbInput.Size = new System.Drawing.Size(543, 363);
            this.rtbInput.TabIndex = 0;
            this.rtbInput.Text = "";
            // 
            // cmdFindPairs
            // 
            this.cmdFindPairs.Location = new System.Drawing.Point(574, 141);
            this.cmdFindPairs.Name = "cmdFindPairs";
            this.cmdFindPairs.Size = new System.Drawing.Size(91, 32);
            this.cmdFindPairs.TabIndex = 1;
            this.cmdFindPairs.Text = "Find Pairs";
            this.cmdFindPairs.UseVisualStyleBackColor = true;
            this.cmdFindPairs.Click += new System.EventHandler(this.cmdFindPairs_Click);
            // 
            // cmdMainMenu
            // 
            this.cmdMainMenu.Location = new System.Drawing.Point(574, 218);
            this.cmdMainMenu.Name = "cmdMainMenu";
            this.cmdMainMenu.Size = new System.Drawing.Size(91, 33);
            this.cmdMainMenu.TabIndex = 1;
            this.cmdMainMenu.Text = "Main Menu";
            this.cmdMainMenu.UseVisualStyleBackColor = true;
            this.cmdMainMenu.Click += new System.EventHandler(this.cmdMainMenu_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(22, 8);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(98, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "List All Strings Here";
            // 
            // rtbOutput
            // 
            this.rtbOutput.Location = new System.Drawing.Point(671, 24);
            this.rtbOutput.Name = "rtbOutput";
            this.rtbOutput.Size = new System.Drawing.Size(146, 363);
            this.rtbOutput.TabIndex = 3;
            this.rtbOutput.Text = "";
            // 
            // Output
            // 
            this.Output.AutoSize = true;
            this.Output.Location = new System.Drawing.Point(649, 8);
            this.Output.Name = "Output";
            this.Output.Size = new System.Drawing.Size(44, 13);
            this.Output.TabIndex = 2;
            this.Output.Text = "Outputs";
            // 
            // cmdSort
            // 
            this.cmdSort.Location = new System.Drawing.Point(574, 179);
            this.cmdSort.Name = "cmdSort";
            this.cmdSort.Size = new System.Drawing.Size(90, 33);
            this.cmdSort.TabIndex = 4;
            this.cmdSort.Text = "Sort Output";
            this.cmdSort.UseVisualStyleBackColor = true;
            this.cmdSort.Click += new System.EventHandler(this.cmdSort_Click);
            // 
            // frmPairFinder
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(829, 411);
            this.Controls.Add(this.cmdSort);
            this.Controls.Add(this.rtbOutput);
            this.Controls.Add(this.Output);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cmdMainMenu);
            this.Controls.Add(this.cmdFindPairs);
            this.Controls.Add(this.rtbInput);
            this.Name = "frmPairFinder";
            this.Text = "Pairs Finder";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.RichTextBox rtbInput;
        private System.Windows.Forms.Button cmdFindPairs;
        private System.Windows.Forms.Button cmdMainMenu;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.RichTextBox rtbOutput;
        private System.Windows.Forms.Label Output;
        private System.Windows.Forms.Button cmdSort;
    }
}