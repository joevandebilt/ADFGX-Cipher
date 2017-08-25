namespace ADFGXDecoder
{
    partial class AlphaRoator
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
            this.numShift = new System.Windows.Forms.NumericUpDown();
            this.label1 = new System.Windows.Forms.Label();
            this.rtbOutput = new System.Windows.Forms.RichTextBox();
            this.rbtNumValue = new System.Windows.Forms.RadioButton();
            this.rbtAutoShift = new System.Windows.Forms.RadioButton();
            this.cmdDecode = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.numShift)).BeginInit();
            this.SuspendLayout();
            // 
            // rtbInput
            // 
            this.rtbInput.Location = new System.Drawing.Point(11, 5);
            this.rtbInput.Name = "rtbInput";
            this.rtbInput.Size = new System.Drawing.Size(446, 85);
            this.rtbInput.TabIndex = 0;
            this.rtbInput.Text = "";
            // 
            // numShift
            // 
            this.numShift.Location = new System.Drawing.Point(463, 28);
            this.numShift.Name = "numShift";
            this.numShift.Size = new System.Drawing.Size(35, 20);
            this.numShift.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(460, 6);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(73, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Alphabet Shift";
            // 
            // rtbOutput
            // 
            this.rtbOutput.Location = new System.Drawing.Point(11, 104);
            this.rtbOutput.Name = "rtbOutput";
            this.rtbOutput.Size = new System.Drawing.Size(713, 376);
            this.rtbOutput.TabIndex = 4;
            this.rtbOutput.Text = "";
            // 
            // rbtNumValue
            // 
            this.rbtNumValue.AutoSize = true;
            this.rbtNumValue.Location = new System.Drawing.Point(504, 28);
            this.rbtNumValue.Name = "rbtNumValue";
            this.rbtNumValue.Size = new System.Drawing.Size(108, 17);
            this.rbtNumValue.TabIndex = 5;
            this.rbtNumValue.TabStop = true;
            this.rbtNumValue.Text = "Use Defined Shift";
            this.rbtNumValue.UseVisualStyleBackColor = true;
            this.rbtNumValue.CheckedChanged += new System.EventHandler(this.rbtNumValue_CheckedChanged);
            // 
            // rbtAutoShift
            // 
            this.rbtAutoShift.AutoSize = true;
            this.rbtAutoShift.Location = new System.Drawing.Point(618, 28);
            this.rbtAutoShift.Name = "rbtAutoShift";
            this.rbtAutoShift.Size = new System.Drawing.Size(118, 17);
            this.rbtAutoShift.TabIndex = 6;
            this.rbtAutoShift.TabStop = true;
            this.rbtAutoShift.Text = "Use Automatic Shift";
            this.rbtAutoShift.UseVisualStyleBackColor = true;
            // 
            // cmdDecode
            // 
            this.cmdDecode.Location = new System.Drawing.Point(460, 54);
            this.cmdDecode.Name = "cmdDecode";
            this.cmdDecode.Size = new System.Drawing.Size(129, 36);
            this.cmdDecode.TabIndex = 1;
            this.cmdDecode.Text = "Do Stuff";
            this.cmdDecode.UseVisualStyleBackColor = true;
            this.cmdDecode.Click += new System.EventHandler(this.cmdDecode_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(595, 54);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(129, 36);
            this.button1.TabIndex = 7;
            this.button1.Text = "Main Menu";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // AlphaRoator
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(752, 510);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.rbtAutoShift);
            this.Controls.Add(this.rbtNumValue);
            this.Controls.Add(this.rtbOutput);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.numShift);
            this.Controls.Add(this.cmdDecode);
            this.Controls.Add(this.rtbInput);
            this.Name = "AlphaRoator";
            this.Text = "Alphabet Roatator";
            ((System.ComponentModel.ISupportInitialize)(this.numShift)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.RichTextBox rtbInput;
        private System.Windows.Forms.NumericUpDown numShift;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.RichTextBox rtbOutput;
        private System.Windows.Forms.RadioButton rbtNumValue;
        private System.Windows.Forms.RadioButton rbtAutoShift;
        private System.Windows.Forms.Button cmdDecode;
        private System.Windows.Forms.Button button1;
    }
}