using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using System.Drawing.Drawing2D;
using Microsoft.Win32;
using System.IO;


namespace Take5
{
    public partial class formMain : Form
    {
        #region DLLImports
        [DllImport("user32.dll")]
        static extern IntPtr GetForegroundWindow();

        [DllImport("user32.dll")]
        [return: MarshalAs(UnmanagedType.Bool)]
        static extern bool GetWindowRect(IntPtr hWnd, out W32RECT lpRect);

        [DllImport("user32.dll")]
        static extern int GetSystemMetrics(int smIndex);

        [DllImport("user32.dll")]
        static extern int GetWindowText(IntPtr hWnd, StringBuilder text, int count);

        [DllImport("WinMM.dll")]
        static extern bool PlaySound(string fname, int Mod, int flag);

        [DllImport("user32")]
        static extern short GetAsyncKeyState(int vKey);
        #endregion

        [StructLayout(LayoutKind.Sequential)]
        private struct W32RECT
        {
            public int Left;
            public int Top;
            public int Right;
            public int Bottom;
        }

        private enum Fade { In, Out }

        private const int SM_CXSCREEN = 0;
        private const int SM_CYSCREEN = 1;
        private int SND_ASYNC = 0x0001;

        private formOptions formOptionsInstance;
        private Fade effect;
        private ContextMenu trayMenu;
        private DateTime prevTick;
        private string coasterColor;
        private int scrX, scrY, prevX, prevY;
        private int countMins, breakSecs, countIdleSeconds = 0;
        private int minsRemain, secsRemain, breakSecsRemain;
        private int prevMouseX, prevMouseY;
        private int clrR, clrG, clrB;
        public bool firstRun;
        private bool movedAround;
        private bool pauseWhenFullscreen, resetWhenIdle, playBeep, playTicks;


        private bool userInFullscreen()
        {
            IntPtr fgWindow = GetForegroundWindow();
            StringBuilder fgWindowTitle = new StringBuilder(255);
            GetWindowText(fgWindow, fgWindowTitle, 255);

            if (fgWindowTitle.ToString() == "Program Manager") //user is on the desktop?
                return false;

            W32RECT wRect;
            GetWindowRect(fgWindow, out wRect);
            
            if (wRect.Right - wRect.Left == scrX && wRect.Bottom - wRect.Top == scrY)
                return true;
            else
                return false;
        }

        private bool userIdle()
        {
            if (MousePosition.X == prevMouseX && MousePosition.Y == prevMouseY)
            {
                if (countIdleSeconds < 60)
                {
                    countIdleSeconds++;
                    return false;
                }
            }
            else
            {
                countIdleSeconds = 0;
                prevMouseX = MousePosition.X;
                prevMouseY = MousePosition.Y;
                return false;
            }

            for (int i = 0; i < 255; i++)
            {
                if (GetAsyncKeyState(i) != 0)
                    countIdleSeconds = 0;
            }

            if (countIdleSeconds == 60)
                return true;
            else
                return false;
        }

        public void LoadOptions()
        {
            try
            {
                System.IO.StreamReader file = new System.IO.StreamReader(Application.StartupPath + "\\config.txt");
                countMins = int.Parse(file.ReadLine());
                breakSecs = int.Parse(file.ReadLine());
                this.Left = int.Parse(file.ReadLine());
                this.Top = int.Parse(file.ReadLine());
                TakeBreak.Font = new Font(file.ReadLine(), 13, FontStyle.Bold);
                pauseWhenFullscreen = bool.Parse(file.ReadLine());
                resetWhenIdle = bool.Parse(file.ReadLine());
                playBeep = bool.Parse(file.ReadLine());
                playTicks = bool.Parse(file.ReadLine());
                
                coasterColor = file.ReadLine();
                extractRGB();

                firstRun = bool.Parse(file.ReadLine());

                file.Close();
            }
            catch
            {
                MessageBox.Show("The file might be deleted or corrupt.", "Can't load config.txt");
                Application.Exit();
            }

            if (timerCountdown.Enabled == false || minsRemain > countMins)
            {
                minsRemain = countMins;
                secsRemain = 0;
            }
        }

        public void SaveOptions()
        {
            System.IO.StreamWriter file = new System.IO.StreamWriter(Application.StartupPath + "\\config.txt");

            file.WriteLine(countMins);
            file.WriteLine(breakSecs);
            file.WriteLine(this.Left);
            file.WriteLine(this.Top);
            file.WriteLine(TakeBreak.Font.FontFamily.Name);
            file.WriteLine(pauseWhenFullscreen);
            file.WriteLine(resetWhenIdle);
            file.WriteLine(playBeep);
            file.WriteLine(playTicks);
            file.WriteLine(coasterColor);
            file.WriteLine(firstRun);

            file.Close();
        }

        private void showOptions()
        {
            if (formOptionsInstance == null || formOptionsInstance.IsDisposed)
            {
                formOptionsInstance = new formOptions();

                //list fonts
                formOptionsInstance.comboFont.Items.Clear();

                foreach (FontFamily font in FontFamily.Families)
                    formOptionsInstance.comboFont.Items.Add(font.Name);

                formOptionsInstance.posX = this.Left;
                formOptionsInstance.posY = this.Top;
                formOptionsInstance.numWorkDuration.Value = countMins;
                formOptionsInstance.numBreakDuration.Value = breakSecs;
                formOptionsInstance.comboFont.SelectedIndex = formOptionsInstance.comboFont.Items.IndexOf(TakeBreak.Font.FontFamily.Name);
                formOptionsInstance.checkPauseFullscreen.Checked = pauseWhenFullscreen;
                formOptionsInstance.checkPauseIdle.Checked = resetWhenIdle;
                formOptionsInstance.checkSoundBreak.Checked = playBeep;
                formOptionsInstance.checkSoundTick.Checked = playTicks;
                formOptionsInstance.comboColor.Text = coasterColor;

                formOptionsInstance.formMainInstance = this;
                formOptionsInstance.Show();

                formOptionsInstance.Left = GetSystemMetrics(SM_CXSCREEN) - formOptionsInstance.Width - 12;
                formOptionsInstance.Top = GetSystemMetrics(SM_CYSCREEN) - formOptionsInstance.Height - 50;
            }
        }

        private void extractRGB()
        {
            if (coasterColor == "Random from list")
            {
                Random rnd = new Random();

                switch (rnd.Next(5))
                {
                    case 0: //amber
                        clrR = 255;
                        clrG = 191;
                        clrB = 0;
                        break;
                    case 1: //cerulean
                        clrR = 0;
                        clrG = 123;
                        clrB = 167;
                        break;
                    case 2: //coral
                        clrR = 255;
                        clrG = 127;
                        clrB = 80;
                        break;
                    case 3: //lime
                        clrR = 191;
                        clrG = 255;
                        clrB = 0;
                        break;
                    case 4: //silver
                        clrR = 191;
                        clrG = 191;
                        clrB = 191;
                        break;
                    default: //amber again
                        clrR = 255;
                        clrG = 191;
                        clrB = 0;
                        break;
                }
            }
            else if (coasterColor == "Full random")
            {
                Random rnd = new Random();

                clrR = rnd.Next(256);
                clrG = rnd.Next(256);
                clrB = rnd.Next(256);
            }
            else
            {
                string tempColor = coasterColor;
                tempColor = tempColor.Remove(0, tempColor.IndexOf("(") + 1);
                clrR = int.Parse(tempColor.Substring(0, tempColor.IndexOf(",")));
                tempColor = tempColor.Remove(0, tempColor.IndexOf(",") + 2);
                clrG = int.Parse(tempColor.Substring(0, tempColor.IndexOf(",")));
                tempColor = tempColor.Remove(0, tempColor.IndexOf(",") + 2);
                clrB = int.Parse(tempColor.Substring(0, tempColor.IndexOf(")")));
            }
        }

        private string randomButtonText()
        {
            Random rnd = new Random();
            
            switch (rnd.Next(6))
            {
                case 0:
                    return "You need to take a break"; 
                case 1:
                    return "Rest a while and listen";
                case 2:
                    return "It's all fun and games\r\ntill you lose your eyes";
                case 3:
                    return "Go! Be free!";
                case 4:
                    return "Get up. Get on up.";
                case 5:
                    return "Rest for a moment.";
                default:
                    return "You need to take a break.";
            }
        }


        public formMain()
        {
            InitializeComponent();
        }

        private void formMain_Load(object sender, EventArgs e)
        {
            LoadOptions();

            trayMenu = new ContextMenu();

            trayMenu.MenuItems.Add(0, new MenuItem("Options", new System.EventHandler(Tray_Options_Click)));
            trayMenu.MenuItems.Add(1, new MenuItem("Take break now", new System.EventHandler(Tray_TakeBreakNow_Click)));
            trayMenu.MenuItems.Add(2, new MenuItem("Reset timer", new System.EventHandler(Tray_Reset_Click)));
            trayMenu.MenuItems.Add(3, new MenuItem("Run at startup", new System.EventHandler(Tray_RunAtStartup_Click)));
            trayMenu.MenuItems.Add(4, new MenuItem("-"));
            trayMenu.MenuItems.Add(5, new MenuItem("Quit", new System.EventHandler(Tray_Exit_Click)));

            trayIcon.ContextMenu = trayMenu;

            prevTick = DateTime.Now;
            timerCountdown.Enabled = true;

            RegistryKey rkApp = Registry.CurrentUser.OpenSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Run", true);
            if (rkApp.GetValue("Take5") != null)
                trayMenu.MenuItems[3].Checked = true;

            //first run?
            if (firstRun)
            {
                if (trayMenu.MenuItems[3].Checked == false) // if toggle not already set for "Run at startup"
                {
                    var res = MessageBox.Show("Always run Take5 on startup of this computer?", "Take5", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (res == DialogResult.Yes)
                    {
                        RunAtStartup(); // Calling this "toggle" function should work
                    }
                }

                trayIcon.ShowBalloonTip(10000, "Take5", "First time running Take5? Double click this icon to view options.", ToolTipIcon.Info);
            }

            firstRun = false; // set this now and save so that the users does not potentially get above msgbox on mutiple runs
            SaveOptions();
        }

        private void formMain_Resize(object sender, EventArgs e)
        {
            if (this.WindowState == FormWindowState.Minimized)
                this.Hide();
        }

        private void formMain_Paint(object sender, PaintEventArgs e)
        {
            Graphics canvas = e.Graphics;
            Brush b;
            try
            {
                b = new SolidBrush(Color.FromArgb(clrR, clrG, clrB));
            }
            catch
            {
                MessageBox.Show("One or more of the color components are larger than 255. The color has been reset.", "Invalid coaster color");
                clrR = 191;
                clrG = 255;
                clrB = 0;
                coasterColor = "Random from list";
                SaveOptions();
                b = new SolidBrush(Color.FromArgb(clrR, clrG, clrB));
            }
            
            canvas.FillEllipse(b, 12, 162, 338, 95);
        }

        private void TakeBreak_MouseDown(object sender, MouseEventArgs e)
        {
            movedAround = false;

            prevX = e.X;
            prevY = e.Y;
        }

        private void TakeBreak_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left && (e.X != prevX || e.Y != prevY))
            {
                movedAround = true;

                this.Left += e.X - prevX;
                this.Top += e.Y - prevY;
            }
        }

        private void TakeBreak_MouseUp(object sender, MouseEventArgs e)
        {
            if (movedAround)
            {
                SaveOptions();

                if (formOptionsInstance != null && !formOptionsInstance.IsDisposed)
                {
                    formOptionsInstance.posX = this.Left;
                    formOptionsInstance.posY = this.Top;
                }
            }
            else if (e.Button == MouseButtons.Left)
            {
                breakSecsRemain = breakSecs;
                timerBreak.Enabled = true;
                TakeBreak.Enabled = false;
            }
        }

        private void TakeBreak_MouseEnter(object sender, EventArgs e)
        {
            picSteam.Visible = true;
        }

        private void TakeBreak_MouseLeave(object sender, EventArgs e)
        {
            picSteam.Visible = false;
        }

        private void trayIcon_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            showOptions();
        }

        private void Tray_Options_Click(object sender, EventArgs e)
        {
            showOptions();
        }

        private void Tray_TakeBreakNow_Click(object sender, EventArgs e)
        {
            minsRemain = 0;
            secsRemain = 0;
        }

        private void Tray_Reset_Click(object sender, EventArgs e)
        {
            minsRemain = countMins;
            secsRemain = 0;

            if (this.Opacity > 0)
            {
                breakSecsRemain = 0;
                timerBreak.Enabled = true;
            }
        }

        private void Tray_RunAtStartup_Click(object sender, EventArgs e)
        {
            RunAtStartup();
        }

        private void RunAtStartup()
        {
            RegistryKey rkApp = Registry.CurrentUser.OpenSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Run", true);

            if (trayMenu.MenuItems[3].Checked == false)
            {
                rkApp.SetValue("Take5", Application.ExecutablePath.ToString());
                trayMenu.MenuItems[3].Checked = true;
            }
            else
            {
                rkApp.DeleteValue("Take5", true);
                trayMenu.MenuItems[3].Checked = false;
            }
        }

        private void Tray_Exit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void timerCountdown_Tick(object sender, EventArgs e)
        {
            string countdown = secsRemain.ToString();

            if (countdown.Length == 1)
                countdown = "0" + countdown;

            trayIcon.Text = minsRemain.ToString() + ":" + countdown;

            if (pauseWhenFullscreen && userInFullscreen())
            {
                prevTick = DateTime.Now;
                return;
            }

            if (resetWhenIdle)
            {
                if (userIdle() || DateTime.Now.Subtract(prevTick).TotalSeconds > breakSecs) //resets the timer when the user is idle and when the computer wakes from a sleep state
                {
                    minsRemain = countMins;
                    secsRemain = 0;
                    prevTick = DateTime.Now;
                    return;
                }
            }

            if (secsRemain > 0)
                secsRemain--;
            else
            {
                secsRemain = 59;

                if (minsRemain > 0)
                    minsRemain--;
                else
                {
                    scrX = GetSystemMetrics(SM_CXSCREEN);
                    scrY = GetSystemMetrics(SM_CYSCREEN);

                    this.Opacity = 0;
                    this.Show();

                    //check if coffee cup outside screen bounds
                    if (this.Left < 0)
                        this.Left = 0;
                    if (this.Left + this.Width > scrX)
                        this.Left = scrX - this.Width;
                    if (this.Top < 0)
                        this.Top = 0;
                    if (this.Top + this.Height > scrY)
                        this.Top = scrY - this.Height - 24;

                    //TakeBreak.Text = randomButtonText();
                    TakeBreak.Text = "You need to take a break";

                    if (playBeep)
                        PlaySound(Application.StartupPath + "\\beep.wav", 0, SND_ASYNC);

                    effect = Fade.In;
                    timerFadeEffect.Enabled = true;
                    timerCountdown.Enabled = false;
                }

                //save countdown as percentage in text file
                try
                {
                    StreamWriter file = new StreamWriter(Application.StartupPath + "\\break_countdown.txt");
                    file.WriteLine((int)((float)(minsRemain + 1) / countMins * 100));
                    file.Close();
                }
                catch
                {
                    //file in use; save countdown later
                }
            }

            prevTick = DateTime.Now;
        }
        
        private void timerFadeEffect_Tick(object sender, EventArgs e)
        {
            if (effect == Fade.In)
            {
                if (this.Opacity < 1)
                    this.Opacity += 0.05;
                else
                    timerFadeEffect.Enabled = false;
            }
            else
            {
                if (this.Opacity > 0)
                    this.Opacity -= 0.05;
                else
                {
                    minsRemain = countMins;
                    prevTick = DateTime.Now;

                    timerCountdown.Enabled = true;
                    timerFadeEffect.Enabled = false;

                    this.Hide();
                }
            }
        }

        private void timerBreak_Tick(object sender, EventArgs e)
        {
            TakeBreak.Text = breakSecsRemain.ToString() + " seconds left";
            if (playTicks)
                PlaySound(Application.StartupPath + "\\tick.wav", 0, SND_ASYNC);

            if (breakSecsRemain > 0)
                breakSecsRemain--;
            else
            {
                if (playBeep)
                    PlaySound(Application.StartupPath + "\\beep2.wav", 0, SND_ASYNC);

                effect = Fade.Out;
                timerFadeEffect.Enabled = true;
                timerBreak.Enabled = false;

                TakeBreak.Enabled = true;
            }
        }
    }
}