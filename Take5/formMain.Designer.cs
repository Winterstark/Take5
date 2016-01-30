namespace Take5
{
    partial class formMain
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(formMain));
            this.timerCountdown = new System.Windows.Forms.Timer(this.components);
            this.trayIcon = new System.Windows.Forms.NotifyIcon(this.components);
            this.timerBreak = new System.Windows.Forms.Timer(this.components);
            this.timerFadeEffect = new System.Windows.Forms.Timer(this.components);
            this.TakeBreak = new System.Windows.Forms.Label();
            this.picSteam = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.picSteam)).BeginInit();
            this.SuspendLayout();
            // 
            // timerCountdown
            // 
            this.timerCountdown.Interval = 1000;
            this.timerCountdown.Tick += new System.EventHandler(this.timerCountdown_Tick);
            // 
            // trayIcon
            // 
            this.trayIcon.Icon = ((System.Drawing.Icon)(resources.GetObject("trayIcon.Icon")));
            this.trayIcon.Text = "Take5";
            this.trayIcon.Visible = true;
            this.trayIcon.MouseClick += new System.Windows.Forms.MouseEventHandler(this.trayIcon_MouseClick);
            // 
            // timerBreak
            // 
            this.timerBreak.Interval = 1000;
            this.timerBreak.Tick += new System.EventHandler(this.timerBreak_Tick);
            // 
            // timerFadeEffect
            // 
            this.timerFadeEffect.Interval = 50;
            this.timerFadeEffect.Tick += new System.EventHandler(this.timerFadeEffect_Tick);
            // 
            // TakeBreak
            // 
            this.TakeBreak.BackColor = System.Drawing.Color.Transparent;
            this.TakeBreak.Font = new System.Drawing.Font("Segoe Print", 13F, System.Drawing.FontStyle.Bold);
            this.TakeBreak.ForeColor = System.Drawing.Color.White;
            this.TakeBreak.Image = global::Take5.Properties.Resources.coffee;
            this.TakeBreak.Location = new System.Drawing.Point(12, 59);
            this.TakeBreak.Name = "TakeBreak";
            this.TakeBreak.Size = new System.Drawing.Size(338, 193);
            this.TakeBreak.TabIndex = 1;
            this.TakeBreak.Text = "You need to take a break.";
            this.TakeBreak.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.TakeBreak.MouseDown += new System.Windows.Forms.MouseEventHandler(this.TakeBreak_MouseDown);
            this.TakeBreak.MouseEnter += new System.EventHandler(this.TakeBreak_MouseEnter);
            this.TakeBreak.MouseLeave += new System.EventHandler(this.TakeBreak_MouseLeave);
            this.TakeBreak.MouseMove += new System.Windows.Forms.MouseEventHandler(this.TakeBreak_MouseMove);
            this.TakeBreak.MouseUp += new System.Windows.Forms.MouseEventHandler(this.TakeBreak_MouseUp);
            // 
            // picSteam
            // 
            this.picSteam.BackColor = System.Drawing.Color.Transparent;
            this.picSteam.Image = ((System.Drawing.Image)(resources.GetObject("picSteam.Image")));
            this.picSteam.Location = new System.Drawing.Point(142, 12);
            this.picSteam.Name = "picSteam";
            this.picSteam.Size = new System.Drawing.Size(70, 51);
            this.picSteam.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picSteam.TabIndex = 2;
            this.picSteam.TabStop = false;
            this.picSteam.Visible = false;
            // 
            // formMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(233)))), ((int)(((byte)(234)))), ((int)(((byte)(255)))));
            this.ClientSize = new System.Drawing.Size(368, 275);
            this.Controls.Add(this.picSteam);
            this.Controls.Add(this.TakeBreak);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.HelpButton = true;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "formMain";
            this.Opacity = 0D;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "Take5";
            this.TopMost = true;
            this.TransparencyKey = System.Drawing.Color.FromArgb(((int)(((byte)(233)))), ((int)(((byte)(234)))), ((int)(((byte)(255)))));
            this.Load += new System.EventHandler(this.formMain_Load);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.formMain_Paint);
            this.Resize += new System.EventHandler(this.formMain_Resize);
            ((System.ComponentModel.ISupportInitialize)(this.picSteam)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Timer timerCountdown;
        private System.Windows.Forms.NotifyIcon trayIcon;
        private System.Windows.Forms.Timer timerBreak;
        private System.Windows.Forms.Timer timerFadeEffect;
        private System.Windows.Forms.Label TakeBreak;
        private System.Windows.Forms.PictureBox picSteam;
    }
}

