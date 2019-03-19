using System;
using System.Diagnostics;
using System.IO;
using System.Net;
using System.Reflection;
using System.Windows.Forms;


namespace GuildLounge.TabPages.SettingsPages
{
    public partial class General : UserControl
    {
        private static string _appdata = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "GuildLounge");
        private static readonly ApiHandler _api = new ApiHandler();
        private static readonly WebClient _client = new WebClient();

        public General()
        {
            InitializeComponent();

            labelBuildNumber.Text = "Build: " + Assembly.GetExecutingAssembly().GetName().Version.Build.ToString();

            InitializeLanguages();
            InitializeGeneralSettings();
            if (checkBoxAutoUpdate.Checked)
                CheckForUpdate();
        }

        #region misc
        public void InitializeGeneralSettings()
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
            textBoxDPSReportToken.Text = Properties.Settings.Default.DPSReportToken;
        }

        public void InitializeLanguages()
        {
            comboBoxLanguage.Items.AddRange(new string[] {
                "English",
                "Deutsch",
                "Français",
                "Polski",
                "Español",
                "Русский",
                "עברית"
            });
            comboBoxLanguage.SelectedItem = comboBoxLanguage.Items[0];
        }
        #endregion

        #region navigation
        private void buttonBrowseGameDirectory_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog fbd = new FolderBrowserDialog();
            fbd.RootFolder = Environment.SpecialFolder.MyComputer;
            if (fbd.ShowDialog() == DialogResult.OK)
                textBoxGameDirectory.Text = fbd.SelectedPath;
        }

        private void buttonCheckForUpdates_Click(object sender, EventArgs e)
        {
            CheckForUpdate();
        }
        #endregion

        #region events
        private void textBoxGameDirectory_TextChanged(object sender, EventArgs e)
        {
            Properties.Settings.Default.GameDir = textBoxGameDirectory.Text;
            if (Parent != null)
                ((Settings)Parent).SettingsChanged(false);
        }

        private void textBoxStartParams_TextChanged(object sender, EventArgs e)
        {
            Properties.Settings.Default.StartParams = textBoxStartParams.Text;
            if (Parent != null)
                ((Settings)Parent).SettingsChanged(false);
        }

        private void radioButtonLaunchStayOpen_CheckedChanged(object sender, EventArgs e)
        {
            Properties.Settings.Default.LaunchBehavior = "STAY_OPEN";
            if (Parent != null)
                ((Settings)Parent).SettingsChanged(false);
        }

        private void radioButtonLaunchMinimize_CheckedChanged(object sender, EventArgs e)
        {
            Properties.Settings.Default.LaunchBehavior = "MINIMIZE";
            if (Parent != null)
                ((Settings)Parent).SettingsChanged(false);
        }

        private void radioButtonLaunchClose_CheckedChanged(object sender, EventArgs e)
        {
            Properties.Settings.Default.LaunchBehavior = "CLOSE";
            if (Parent != null)
                ((Settings)Parent).SettingsChanged(false);
        }

        private void checkBoxAutoUpdate_CheckedChanged(object sender, EventArgs e)
        {
            Properties.Settings.Default.CheckForUpdates = checkBoxAutoUpdate.Checked;
            if (Parent != null)
                ((Settings)Parent).SettingsChanged(false);
        }

        private void linkLabelDPSReportTokenHelp_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Popups.UserTokenHelp help = new Popups.UserTokenHelp();
            help.StartPosition = FormStartPosition.CenterParent;
            help.ShowDialog();
        }

        private void textBoxDPSReportToken_TextChanged(object sender, EventArgs e)
        {
            Properties.Settings.Default.DPSReportToken = textBoxDPSReportToken.Text;
            if (Parent != null)
                ((Settings)Parent).SettingsChanged(false);
        }
        #endregion

        #region updating
        private async void CheckForUpdate()
        {
            try
            {
                BuildInfo APIResponse = await _api.GetResponseWithEntryPoint<BuildInfo>("http://api.guildlounge.com/", "build");

                string updaterPath = Path.Combine(_appdata, "updater.exe");
                Version updaterLocal = AssemblyName.GetAssemblyName(updaterPath).Version;
                if (File.Exists(updaterPath))
                {
                    if (APIResponse.UpdaterBuildID > updaterLocal.Build || 
                        (APIResponse.UpdaterBuildID == updaterLocal.Build &&
                        APIResponse.UpdaterRevisionID > updaterLocal.Revision))
                    {
                        labelUpdaterInfo.Text = "Updating updater!";
                        Utility.TimeoutToDisappear(labelUpdaterInfo);
                        _client.DownloadFile("http://dev.guildlounge.com/updater.exe", Path.Combine(_appdata, "updater.exe"));
                    }
                }
                else
                {
                    labelUpdaterInfo.Text = "Downloading updater!";
                    Utility.TimeoutToDisappear(labelUpdaterInfo);
                    _client.DownloadFile("http://dev.guildlounge.com/updater.exe", Path.Combine(_appdata, "updater.exe"));
                }

                Version glClient = Assembly.GetExecutingAssembly().GetName().Version;
                if (APIResponse.BuildID > glClient.Build || 
                    (APIResponse.BuildID == glClient.Build &&
                    APIResponse.RevisionID > glClient.Revision))
                {
                    TabPages.Popups.UpdateNotification un = new TabPages.Popups.UpdateNotification(APIResponse.Note);
                    un.StartPosition = FormStartPosition.CenterParent;

                    if (un.ShowDialog() == DialogResult.Yes)
                        UpdateExecutable();
                }
                else
                {
                    labelUpdaterInfo.Text = "Up to date!";
                    Utility.TimeoutToDisappear(labelUpdaterInfo);
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
                //Run the updater
                Process Updater = new Process();
                Updater.StartInfo = new ProcessStartInfo(Path.Combine(_appdata, "updater.exe"));
                Updater.StartInfo.Arguments = Application.ExecutablePath;
                Updater.Start();

                //Close GuildLounge
                Application.Exit();
            }
            catch (Exception exc)
            {
                Console.WriteLine(exc.Message);
            }
        }
        #endregion
        
        //SORT THIS
        //ADD FUNCTIONALITY
        //ADD REQUIRE RESTART TO THEMES
        private void comboBoxLanguage_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (Parent != null)
                ((Settings)Parent).SettingsChanged(true);
        }
    }
}