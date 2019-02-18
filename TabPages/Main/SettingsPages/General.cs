using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GuildLounge.TabPages.SettingsPages
{
    public partial class General : UserControl
    {
        public General()
        {
            InitializeComponent();

            LoadSettingsGeneral();
        }

        public void LoadSettingsGeneral()
        {
            textBoxGameDirectory.Text = Properties.Settings.Default.GameDir;
            textBoxStartParams.Text = Properties.Settings.Default.StartParams;

            switch (Properties.Settings.Default.LaunchBehavior)
            {
                case "STAY_OPEN":
                    radioButtonLaunchStayOpen.Checked = true;
                    break;
                case "MINIMIZE":
                    radioButtonLaunchMinimize.Checked = true;
                    break;
                case "CLOSE":
                    radioButtonLaunchClose.Checked = true;
                    break;
            }
        }

        private void buttonBrowseGameDirectory_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog fbd = new FolderBrowserDialog();
            fbd.RootFolder = Environment.SpecialFolder.MyComputer;
            if (fbd.ShowDialog() == DialogResult.OK)
                textBoxGameDirectory.Text = fbd.SelectedPath;
        }

        private void textBoxGameDirectory_TextChanged(object sender, EventArgs e)
        {
            Properties.Settings.Default.GameDir = textBoxGameDirectory.Text;
            if(Parent != null)
                ((Settings)Parent).SettingsChanged();
        }

        private void textBoxStartParams_TextChanged(object sender, EventArgs e)
        {
            Properties.Settings.Default.StartParams = textBoxStartParams.Text;
            if (Parent != null)
                ((Settings)Parent).SettingsChanged();
        }

        private void radioButtonLaunchStayOpen_CheckedChanged(object sender, EventArgs e)
        {
            Properties.Settings.Default.LaunchBehavior = "STAY_OPEN";
            if (Parent != null)
                ((Settings)Parent).SettingsChanged();
        }

        private void radioButtonLaunchMinimize_CheckedChanged(object sender, EventArgs e)
        {
            Properties.Settings.Default.LaunchBehavior = "MINIMIZE";
            if (Parent != null)
                ((Settings)Parent).SettingsChanged();
        }

        private void radioButtonLaunchClose_CheckedChanged(object sender, EventArgs e)
        {
            Properties.Settings.Default.LaunchBehavior = "CLOSE";
            if (Parent != null)
                ((Settings)Parent).SettingsChanged();
        }
    }
}
