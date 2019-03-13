using System;
using System.Drawing;
using System.Windows.Forms;

namespace GuildLounge.TabPages
{
    public partial class Settings : UserControl
    {
        private UserControl ActiveTab;

        private UserControl GeneralTab;
        private UserControl AccountsTab;
        private UserControl ModulesTab;
        private UserControl ExtensionsTab;
        private UserControl AboutTab;

        private bool RequiresRestart { get; set; }

        public Settings()
        {
            InitializeComponent();
            
            //Initializing tabPages
            InitializeTabPages();

            //Set General as the current tabPage
            SetActiveTab(GeneralTab);

            //Fixing save button on loadup
            buttonSave.Enabled = false;
        }

        #region misc
        //Called from the Main form to get the accounts
        public Account[] GetAccounts()
        {
            return ((SettingsPages.Accounts)AccountsTab).StoredAccounts;
        }
        #endregion

        #region navigation
        private void InitializeTabPages()
        {
            //Initializing the pages
            GeneralTab = new SettingsPages.General();
            AccountsTab = new SettingsPages.Accounts();
            ModulesTab = new SettingsPages.Modules();
            ExtensionsTab = new SettingsPages.Extensions();
            AboutTab = new SettingsPages.About();

            //Fixing visibility
            GeneralTab.Visible
                = AccountsTab.Visible
                = ModulesTab.Visible
                = ExtensionsTab.Visible
                = AboutTab.Visible
                = false;

            //Fixing locations
            GeneralTab.Location
                = AccountsTab.Location
                = ModulesTab.Location
                = ExtensionsTab.Location
                = AboutTab.Location
                = new Point(170, 0);

            //Adding them as controls
            Controls.AddRange(new UserControl[]
            {
                GeneralTab,
                AccountsTab,
                ModulesTab,
                ExtensionsTab,
                AboutTab
            });
        }

        protected void SetActiveTab(UserControl tab)
        {
            if (ActiveTab != null)
            {
                ActiveTab.Visible = false;
                ActiveTab = tab;
                ActiveTab.Visible = true;
            }
            else
            {
                ActiveTab = tab;
                ActiveTab.Visible = true;
            }
        }
        
        private void buttonSettingsGeneral_Click(object sender, EventArgs e)
        {
            SetActiveTab(GeneralTab);
        }

        private void buttonSettingsAccounts_Click(object sender, EventArgs e)
        {
            SetActiveTab(AccountsTab);
        }

        private void buttonSettingsModules_Click(object sender, EventArgs e)
        {
            SetActiveTab(ModulesTab);
        }

        private void buttonSettingsExtensions_Click(object sender, EventArgs e)
        {
            SetActiveTab(ExtensionsTab);
        }

        private void buttonAbout_Click(object sender, EventArgs e)
        {
            SetActiveTab(AboutTab);
        }
        
        private void buttonRestore_Click(object sender, EventArgs e)
        {
            //Resets all settings to the defaults
            Properties.Settings.Default.Reset();
            ((SettingsPages.General)GeneralTab).InitializeGeneralSettings();
            ((SettingsPages.Modules)ModulesTab).InitializeModuleSettings();
            ((SettingsPages.Extensions)ExtensionsTab).InitializeExtensionSettings();
            buttonSave.Enabled = true;
        }
        
        private void buttonSave_Click(object sender, EventArgs e)
        {
            //Save the settings and reload the modules in the mainform
            Properties.Settings.Default.Save();
            buttonSave.Enabled = false;
            ((Main)Parent).InitializeModules();
            if(RequiresRestart)
            {
                var result = MessageBox.Show("Some settings will only be applied when the application is restarted.\n\n" +
                    "Restart now?", "Guild Lounge",
                                 MessageBoxButtons.YesNo,
                                 MessageBoxIcon.Question);

                if (result == DialogResult.Yes)
                    Application.Restart();
            }
        }
        #endregion
        
        #region events
        //Calls the Main form to get the accounts
        public void AccountsChanged()
        {
            ((Main)Parent).GetAccounts();
        }

        //Called from child tabs when a setting was changed to enable the save button
        public void SettingsChanged(bool needRestart)
        {
            buttonSave.Enabled = true;
            RequiresRestart = needRestart;
        }
        #endregion
    }
}