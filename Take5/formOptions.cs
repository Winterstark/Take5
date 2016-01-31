using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using GenericForms;

namespace Take5
{
    public partial class formOptions : Form
    {
        public int posX, posY;
        public formMain formMainInstance;

        public formOptions()
        {
            InitializeComponent();
        }

        private bool badColorValue()
        {
            if (comboColor.Text == "Random from list" || comboColor.Text == "Full random")
                return false;
            try
            {
                int ind;
                for (ind = 0; ind < comboColor.Text.Length; ind++)
                    if (!char.IsLetter(comboColor.Text[ind]))
                        break;

                if (ind == comboColor.Text.Length)
                    return true;

                if (comboColor.Text.Substring(ind, 2) == " (")
                    ind += 2;
                else
                    return true;

                for (int i = 0; i < 2; i++)
                {
                    while (char.IsDigit(comboColor.Text[ind]))
                        ind++;

                    while (char.IsPunctuation(comboColor.Text[ind]) || char.IsSeparator(comboColor.Text[ind]))
                        ind++;
                }

                while (char.IsDigit(comboColor.Text[ind]))
                    ind++;

                if (comboColor.Text[ind] == ')' && ind == comboColor.Text.Length - 1)
                    return false;
                else
                    return true;
            }
            catch
            {
                return true;
            }
        }

        private void linkAbout_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            System.Diagnostics.Process.Start("https://github.com/Winterstark/Take5");
        }

        private void linkContact_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            System.Diagnostics.Process.Start("mailto:winterstark@gmail.com");
        }

        private void formOptions_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (!badColorValue())
            {
                System.IO.StreamWriter file = new System.IO.StreamWriter(Application.StartupPath + "\\config.txt");
                file.WriteLine(numWorkDuration.Value.ToString());
                file.WriteLine(numBreakDuration.Value.ToString());
                file.WriteLine(posX);
                file.WriteLine(posY);
                file.WriteLine(comboFont.Text);
                file.WriteLine(checkPauseFullscreen.Checked);
                file.WriteLine(checkPauseIdle.Checked);
                file.WriteLine(checkSoundBreak.Checked);
                file.WriteLine(checkSoundTick.Checked);
                file.WriteLine(comboColor.Text);
                file.WriteLine(formMainInstance.firstRun);
                file.Close();

                formMainInstance.LoadOptions();
            }
            else
                MessageBox.Show("Enter custom color in the following format: <color-name> (<R>, <G>, <B>)", "Invalid coaster color value");
        }

        private void comboColor_Leave(object sender, EventArgs e)
        {
            if (badColorValue())
                MessageBox.Show("Enter custom color in the following format: <color-name> (<R>, <G>, <B>)", "Invalid coaster color value");
        }

        private void formOptions_Load(object sender, EventArgs e)
        {
            //tutorial
            new Tutorial(Application.StartupPath + "\\tutorial.txt", this);
        }
    }
}
