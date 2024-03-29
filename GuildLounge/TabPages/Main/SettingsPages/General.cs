﻿using System;
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
        public bool DPSReportTokenHidden = true;

        public General()
        {
            InitializeComponent();

            textBoxDPSReportToken.UseSystemPasswordChar = DPSReportTokenHidden;
            labelBuildNumber.Text = "Build: " + Assembly.GetExecutingAssembly().GetName().Version.Build.ToString();
            
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

        private void buttonToggleHideDPSReportToken_Click(object sender, EventArgs e)
        {
            DPSReportTokenHidden = !DPSReportTokenHidden;
            textBoxDPSReportToken.UseSystemPasswordChar = DPSReportTokenHidden;
            if (DPSReportTokenHidden)
                buttonToggleHideDPSReportToken.BackgroundImage = Properties.Resources.ui_locked;
            else
                buttonToggleHideDPSReportToken.BackgroundImage = Properties.Resources.ui_unlocked;
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
                //Fetch the buildinfo from the GuildLounge API
                BuildInfo APIResponse = await _api.GetResponseWithEntryPoint<BuildInfo>("http://api.guildlounge.com/", "build");

                //temp variables for more readability
                string updaterPath = Path.Combine(_appdata, "updater.exe");
                Version updaterLocal = AssemblyName.GetAssemblyName(updaterPath).Version;
                //check if the updater.exe exists and if it is up-to-date
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

                //temp variable for readability
                Version glClient = Assembly.GetExecutingAssembly().GetName().Version;
                //check if the client is up-to-date
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
                //The API can't be reached, or some other error occured,
                //so we will just assume it is up-to-date
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
                Updater.StartInfo.Arguments = "\"" + Application.ExecutablePath + "\"";
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
    }
}