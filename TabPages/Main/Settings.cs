﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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

        public Settings()
        {
            InitializeComponent();

            GeneralTab = new SettingsPages.General();
            AccountsTab = new SettingsPages.Accounts();
            ModulesTab = new SettingsPages.Modules();
            ExtensionsTab = new SettingsPages.Extensions();
            AboutTab = new SettingsPages.About();

            GeneralTab.Visible
                = AccountsTab.Visible
                = ModulesTab.Visible
                = ExtensionsTab.Visible
                = AboutTab.Visible
                = false;

            GeneralTab.Location
                = AccountsTab.Location
                = ModulesTab.Location
                = ExtensionsTab.Location
                = AboutTab.Location
                = new Point(170, 0);

            Controls.AddRange(new UserControl[]
            {
                GeneralTab,
                AccountsTab,
                ModulesTab,
                ExtensionsTab,
                AboutTab
            });

            SetActiveTab(GeneralTab);

            buttonSave.Enabled = false;
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

        #region navigation

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
        #endregion

        private void buttonRestore_Click(object sender, EventArgs e)
        {
            Properties.Settings.Default.Reset();
            ((SettingsPages.General)GeneralTab).LoadSettingsGeneral();
            ((SettingsPages.Modules)ModulesTab).LoadSettingsModules();
            ((SettingsPages.Extensions)ExtensionsTab).LoadSettingsExtensions();
            buttonSave.Enabled = true;
        }

        private void buttonSave_Click(object sender, EventArgs e)
        {
            Properties.Settings.Default.Save();
            buttonSave.Enabled = false;
            var obj = (Main)Parent;
            obj.LoadModules();
        }

        public Account[] GetAccounts()
        {
            return ((SettingsPages.Accounts)AccountsTab).StoredAccounts;
        }

        public void RefetchAccounts()
        {
            var obj = (Main)Parent;
            obj.GetAccounts();
        }

        public void SettingsChanged()
        {
            buttonSave.Enabled = true;
        }
    }
}
