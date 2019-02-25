using System;
using System.Diagnostics;
using System.IO;
using System.Reflection;
using System.Windows.Forms;

namespace GuildLounge.TabPages.SettingsPages
{
    public partial class General : UserControl
    {
        private static string _appdata = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "GuildLounge");
        private static readonly ApiHandler _api = new ApiHandler();

        public General()
        {
            InitializeComponent();

            labelBuildNumber.Text = "Build: " + Assembly.GetExecutingAssembly().GetName().Version.Build.ToString();

            LoadSettingsGeneral();
            if (checkBoxAutoUpdate.Checked)
                CheckForUpdate();
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

            checkBoxAutoUpdate.Checked = Properties.Settings.Default.CheckForUpdates;
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

        private void checkBoxAutoUpdate_CheckedChanged(object sender, EventArgs e)
        {
            Properties.Settings.Default.CheckForUpdates = checkBoxAutoUpdate.Checked;
            if (Parent != null)
                ((Settings)Parent).SettingsChanged();
        }

        private void buttonCheckForUpdates_Click(object sender, EventArgs e)
        {
            CheckForUpdate();
        }

        private async void CheckForUpdate()
        {
            try
            {
                BuildInfo APIResponse = await _api.GetResponseWithEntryPoint<BuildInfo>("http://api.guildlounge.com/", "build");

                if(APIResponse.BuildID > Assembly.GetExecutingAssembly().GetName().Version.Build ||
                    APIResponse.RevisionID > Assembly.GetExecutingAssembly().GetName().Version.Revision)
                {
                    var result = MessageBox.Show("There is a newer version available.\n" +
                        "Update now?", "Guild Lounge Updater",
                                 MessageBoxButtons.YesNo,
                                 MessageBoxIcon.Question);

                    if (result == DialogResult.Yes)
                        UpdateExecutable();
                }
            }
            catch
            {
                labelUpdaterInfo.Text = "Up to date!";
                Utility.TimeoutToDisappear(labelUpdaterInfo);
            }
        }

        private void UpdateExecutable()
        {
            try
            {
                Process Updater = new Process();
                Updater.StartInfo = new ProcessStartInfo(Path.Combine(_appdata, "updater.exe"));
                Updater.StartInfo.Arguments = Application.ExecutablePath;
                Updater.Start();
            }
            catch (Exception exc)
            {
                Console.WriteLine(exc.Message);
            }
        }
    }
}