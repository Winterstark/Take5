namespace Take5
{
    partial class formOptions
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(formOptions));
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.checkPauseFullscreen = new System.Windows.Forms.CheckBox();
            this.checkPauseIdle = new System.Windows.Forms.CheckBox();
            this.checkSoundBreak = new System.Windows.Forms.CheckBox();
            this.checkSoundTick = new System.Windows.Forms.CheckBox();
            this.label5 = new System.Windows.Forms.Label();
            this.linkAbout = new System.Windows.Forms.LinkLabel();
            this.linkContact = new System.Windows.Forms.LinkLabel();
            this.label6 = new System.Windows.Forms.Label();
            this.comboColor = new System.Windows.Forms.ComboBox();
            this.picCoffee = new System.Windows.Forms.PictureBox();
            this.numWorkDuration = new System.Windows.Forms.NumericUpDown();
            this.numBreakDuration = new System.Windows.Forms.NumericUpDown();
            this.comboFont = new System.Windows.Forms.ComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.picCoffee)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numWorkDuration)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numBreakDuration)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(67, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Break every ";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(149, 15);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(43, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "minutes";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(141, 41);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(47, 13);
            this.label3.TabIndex = 6;
            this.label3.Text = "seconds";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 41);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(59, 13);
            this.label4.TabIndex = 4;
            this.label4.Text = "Break lasts";
            // 
            // checkPauseFullscreen
            // 
            this.checkPauseFullscreen.AutoSize = true;
            this.checkPauseFullscreen.Location = new System.Drawing.Point(12, 136);
            this.checkPauseFullscreen.Name = "checkPauseFullscreen";
            this.checkPauseFullscreen.Size = new System.Drawing.Size(230, 17);
            this.checkPauseFullscreen.TabIndex = 5;
            this.checkPauseFullscreen.Text = "Pause countdown in fullscreen applications";
            this.checkPauseFullscreen.UseVisualStyleBackColor = true;
            // 
            // checkPauseIdle
            // 
            this.checkPauseIdle.AutoSize = true;
            this.checkPauseIdle.Location = new System.Drawing.Point(12, 159);
            this.checkPauseIdle.Name = "checkPauseIdle";
            this.checkPauseIdle.Size = new System.Drawing.Size(181, 17);
            this.checkPauseIdle.TabIndex = 6;
            this.checkPauseIdle.Text = "Reset countdown when user idle";
            this.checkPauseIdle.UseVisualStyleBackColor = true;
            // 
            // checkSoundBreak
            // 
            this.checkSoundBreak.AutoSize = true;
            this.checkSoundBreak.Location = new System.Drawing.Point(12, 193);
            this.checkSoundBreak.Name = "checkSoundBreak";
            this.checkSoundBreak.Size = new System.Drawing.Size(123, 17);
            this.checkSoundBreak.TabIndex = 7;
            this.checkSoundBreak.Text = "Play sound on break";
            this.checkSoundBreak.UseVisualStyleBackColor = true;
            // 
            // checkSoundTick
            // 
            this.checkSoundTick.AutoSize = true;
            this.checkSoundTick.Location = new System.Drawing.Point(12, 216);
            this.checkSoundTick.Name = "checkSoundTick";
            this.checkSoundTick.Size = new System.Drawing.Size(160, 17);
            this.checkSoundTick.TabIndex = 8;
            this.checkSoundTick.Text = "Ticking sounds during break";
            this.checkSoundTick.UseVisualStyleBackColor = true;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(9, 76);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(31, 13);
            this.label5.TabIndex = 11;
            this.label5.Text = "Font:";
            // 
            // linkAbout
            // 
            this.linkAbout.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.linkAbout.LinkArea = new System.Windows.Forms.LinkArea(84, 11);
            this.linkAbout.LinkBehavior = System.Windows.Forms.LinkBehavior.HoverUnderline;
            this.linkAbout.Location = new System.Drawing.Point(281, 9);
            this.linkAbout.Name = "linkAbout";
            this.linkAbout.Size = new System.Drawing.Size(196, 66);
            this.linkAbout.TabIndex = 9;
            this.linkAbout.TabStop = true;
            this.linkAbout.Text = "This small piece of eye-saving, caffeine-inspired software is freeware.\r\nWritten " +
    "by Winterstark";
            this.linkAbout.UseCompatibleTextRendering = true;
            this.linkAbout.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkAbout_LinkClicked);
            // 
            // linkContact
            // 
            this.linkContact.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.linkContact.LinkArea = new System.Windows.Forms.LinkArea(47, 21);
            this.linkContact.LinkBehavior = System.Windows.Forms.LinkBehavior.HoverUnderline;
            this.linkContact.Location = new System.Drawing.Point(281, 76);
            this.linkContact.Name = "linkContact";
            this.linkContact.Size = new System.Drawing.Size(196, 50);
            this.linkContact.TabIndex = 10;
            this.linkContact.TabStop = true;
            this.linkContact.Text = "Send any comments, requests, or bug reports to winterstark@gmail.com. Thanks!";
            this.linkContact.UseCompatibleTextRendering = true;
            this.linkContact.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkContact_LinkClicked);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(9, 104);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(72, 13);
            this.label6.TabIndex = 15;
            this.label6.Text = "Coaster color:";
            // 
            // comboColor
            // 
            this.comboColor.FormattingEnabled = true;
            this.comboColor.Items.AddRange(new object[] {
            "Amber (255, 191, 0)",
            "Cerulean (0, 123, 167)",
            "Coral (255, 127, 80)",
            "Lime (191, 255, 0)",
            "Silver (191, 191, 191)",
            "Random from list",
            "Full random"});
            this.comboColor.Location = new System.Drawing.Point(87, 101);
            this.comboColor.Name = "comboColor";
            this.comboColor.Size = new System.Drawing.Size(155, 21);
            this.comboColor.TabIndex = 4;
            this.comboColor.Leave += new System.EventHandler(this.comboColor_Leave);
            // 
            // picCoffee
            // 
            this.picCoffee.Image = global::Take5.Properties.Resources.coffee;
            this.picCoffee.Location = new System.Drawing.Point(281, 129);
            this.picCoffee.Name = "picCoffee";
            this.picCoffee.Size = new System.Drawing.Size(196, 109);
            this.picCoffee.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picCoffee.TabIndex = 17;
            this.picCoffee.TabStop = false;
            // 
            // numWorkDuration
            // 
            this.numWorkDuration.Location = new System.Drawing.Point(85, 13);
            this.numWorkDuration.Maximum = new decimal(new int[] {
            1440,
            0,
            0,
            0});
            this.numWorkDuration.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numWorkDuration.Name = "numWorkDuration";
            this.numWorkDuration.Size = new System.Drawing.Size(58, 20);
            this.numWorkDuration.TabIndex = 1;
            this.numWorkDuration.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // numBreakDuration
            // 
            this.numBreakDuration.Location = new System.Drawing.Point(77, 39);
            this.numBreakDuration.Maximum = new decimal(new int[] {
            10800,
            0,
            0,
            0});
            this.numBreakDuration.Minimum = new decimal(new int[] {
            5,
            0,
            0,
            0});
            this.numBreakDuration.Name = "numBreakDuration";
            this.numBreakDuration.Size = new System.Drawing.Size(58, 20);
            this.numBreakDuration.TabIndex = 2;
            this.numBreakDuration.Value = new decimal(new int[] {
            5,
            0,
            0,
            0});
            // 
            // comboFont
            // 
            this.comboFont.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboFont.FormattingEnabled = true;
            this.comboFont.Location = new System.Drawing.Point(46, 72);
            this.comboFont.Name = "comboFont";
            this.comboFont.Size = new System.Drawing.Size(196, 21);
            this.comboFont.TabIndex = 3;
            // 
            // formOptions
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(489, 250);
            this.Controls.Add(this.comboFont);
            this.Controls.Add(this.numBreakDuration);
            this.Controls.Add(this.numWorkDuration);
            this.Controls.Add(this.picCoffee);
            this.Controls.Add(this.comboColor);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.linkContact);
            this.Controls.Add(this.linkAbout);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.checkSoundTick);
            this.Controls.Add(this.checkSoundBreak);
            this.Controls.Add(this.checkPauseIdle);
            this.Controls.Add(this.checkPauseFullscreen);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "formOptions";
            this.Text = "Take5 Options";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.formOptions_FormClosed);
            this.Load += new System.EventHandler(this.formOptions_Load);
            ((System.ComponentModel.ISupportInitialize)(this.picCoffee)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numWorkDuration)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numBreakDuration)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        public System.Windows.Forms.CheckBox checkPauseFullscreen;
        public System.Windows.Forms.CheckBox checkPauseIdle;
        public System.Windows.Forms.CheckBox checkSoundBreak;
        public System.Windows.Forms.CheckBox checkSoundTick;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.LinkLabel linkAbout;
        private System.Windows.Forms.LinkLabel linkContact;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.PictureBox picCoffee;
        public System.Windows.Forms.ComboBox comboColor;
        public System.Windows.Forms.NumericUpDown numWorkDuration;
        public System.Windows.Forms.NumericUpDown numBreakDuration;
        public System.Windows.Forms.ComboBox comboFont;
    }
}