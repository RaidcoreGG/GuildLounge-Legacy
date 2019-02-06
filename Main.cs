using System;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace GuildLounge
{
    public partial class Main : Form
    {
        #region dragging
        public const int WM_NCLBUTTONDOWN = 0xA1;
        public const int HT_CAPTION = 0x2;

        [DllImportAttribute("user32.dll")]
        public static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);
        [DllImportAttribute("user32.dll")]
        public static extern bool ReleaseCapture();
        #endregion

        #region variables
        //APPDATA FOLDER PATH
        private static string _appdata = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "GuildLounge");

        //TAB CONTROL
        private UserControl ActiveTab;
        private Control_NavigationButton ActiveTabButton;

        private UserControl DashboardTab;
        private UserControl LFGTab;
        private UserControl RaidsTab;
        private UserControl GuidesTab;
        private UserControl APIKeysTab;
        private UserControl SettingsTab;

        //API STUFF
        private static readonly ApiHandler _api = new ApiHandler();
        public ApiEntry[] APIEntries { get; set; }
        private ApiEntry ActiveAPIEntry { get; set; }
        #endregion


        public Main()
        {
            InitializeComponent();

            //DISABLE HORIZONTAL SCROLL FOR MODULES PANEL
            panelOverview.HorizontalScroll.Maximum = 0;
            panelOverview.VerticalScroll.Visible = false;
            panelOverview.AutoScroll = true;

            //INITIALIZING TABS
            DashboardTab = new TabPage_Dashboard();
            LFGTab = new TabPage_LFG();
            RaidsTab = new TabPage_Raids();
            GuidesTab = new TabPage_Guides();
            APIKeysTab = new TabPage_APIKeys();
            SettingsTab = new TabPage_Settings();

            //HIDING TABS
            DashboardTab.Visible
                = LFGTab.Visible
                = RaidsTab.Visible
                = GuidesTab.Visible
                = APIKeysTab.Visible
                = SettingsTab.Visible
                = false;

            //FIXING TAB LOCATION
            DashboardTab.Location
                = LFGTab.Location
                = RaidsTab.Location
                = GuidesTab.Location
                = APIKeysTab.Location
                = SettingsTab.Location
                = new Point(0, 104);

            //ADDING TABS TO CONTROLS OF MAIN FORM
            Controls.AddRange(new UserControl[]
            {
                DashboardTab,
                LFGTab,
                RaidsTab,
                GuidesTab,
                APIKeysTab,
                SettingsTab
            });

            //SETTING DASHBOARD AS STARTUP TAB
            SetActiveTab(DashboardTab, buttonDashboard);

            //CHECK IF REQUIRED FILES EXIST
            //CREATE IF NOT EXISTING
            if (!Directory.Exists(_appdata))
                Directory.CreateDirectory(_appdata);
            if (!File.Exists(Path.Combine(_appdata, "api_keys.json")))
                File.Create(Path.Combine(_appdata, "api_keys.json"));
            if (!File.Exists(Path.Combine(_appdata, "addons.json")))
                File.Create(Path.Combine(_appdata, "addons.json"));

            //API STUFF
            try
            {
                //GET KEYS FROM API KEYS TAB
                RefreshKeys();

                //REQUEST&PROCESS DATA FROM API
                UpdateAccountOverview();
            }
            catch (Exception exc)
            {
                Console.WriteLine(exc.Message);
            }
        }

        #region navigation
        private void SetActiveTab(UserControl tab, object button)
        {
            if(ActiveTab != null)
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

            if(ActiveTabButton != null)
            {
                if (button is Control_NavigationButton)
                {
                    ActiveTabButton.Active = false;
                    ActiveTabButton = (Control_NavigationButton)button;
                    ActiveTabButton.Active = true;
                }
                else
                    ActiveTabButton.Active = false;
            }
            else
            {
                ActiveTabButton = (Control_NavigationButton)button;
                ActiveTabButton.Active = true;
            }
        }

        private void buttonDashboard_Click(object sender, EventArgs e)
        {
            SetActiveTab(DashboardTab, sender);
        }

        private void buttonLFG_Click(object sender, EventArgs e)
        {
            SetActiveTab(LFGTab, sender);
        }

        private void buttonRaids_Click(object sender, EventArgs e)
        {
            SetActiveTab(RaidsTab, sender);
        }

        private void buttonGuides_Click(object sender, EventArgs e)
        {
            SetActiveTab(GuidesTab, sender);
        }

        private void linkLabelAPIKeys_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            SetActiveTab(APIKeysTab, sender);
        }

        private void linkLabelSettings_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            SetActiveTab(SettingsTab, sender);
        }
        #endregion

        public void RefreshKeys()
        {
            //GET KEYS FROM KEYSTAB
            var obj = (TabPage_APIKeys)APIKeysTab;
            APIEntries = obj.APIEntries;
            
            if (APIEntries != null)
            {
                ActiveAPIEntry = APIEntries[0];

                //UPDATE COMBOBOX ITEMS
                comboBoxAccount.Items.Clear();
                comboBoxAccount.Items.AddRange(APIEntries);

                //CORRECT DISPLAY
                comboBoxAccount.DisplayMember = "Name";
                comboBoxAccount.SelectedIndex = 0;

                comboBoxAccount.Enabled = true;
                buttonRefresh.Enabled = true;
            }
            else
            {
                ActiveAPIEntry = null;
                comboBoxAccount.Enabled = false;
                buttonRefresh.Enabled = false;
            }

            //SET NEW KEY FOR RAIDS TAB
            var obj2 = (TabPage_Raids)RaidsTab;
            obj2.ActiveAPIEntry = ActiveAPIEntry;
        }

        private async void UpdateAccountOverview()
        {
            comboBoxAccount.Enabled = false;
            buttonRefresh.Enabled = false;

            try
            {
                ModuleData APIResponse = await _api.FetchAccountOverview(ActiveAPIEntry.Key);

                var w = APIResponse.wallet;
                var tp = APIResponse.tradingpost;

                //RAIDS
                moduleRaids.LegendaryInsights = APIResponse.sumLI;
                moduleRaids.LegendaryDivinations = APIResponse.sumLD;
                moduleRaids.MagnetiteShards = w.magnetite;
                moduleRaids.GaetingCrystals = w.gaeting;

                SetToolTipTexts(APIResponse);

                //FRACTALS
                moduleFractals.FractalRelics = w.fractalrelic;
                moduleFractals.PristineFractalRelics = w.pristinefractalrelic;

                //WVW
                moduleWvW.BadgesOfHonor = w.badgeofhonor;
                moduleWvW.SkirmishTickets = w.wvwskirmishticket;

                //PVP
                modulePvP.AscendedShardsOfGlory = w.ascendedshardsofglory;
                modulePvP.LeagueTicket = w.pvpleagueticket;

                //COINS
                moduleBaseCurrencies.Coins = w.coins;
                moduleBaseCurrencies.Karma = w.karma;
                moduleBaseCurrencies.Laurels = w.laurels;
                moduleBaseCurrencies.Gems = w.gems;

                //TP PICKUP
                moduleTPPickup.Coins = tp.coins;
                moduleTPPickup.Items = tp.items.Length;
                
            }
            catch (Exception exc)
            {
                if (exc.Message.Contains("400 (Bad Request)"))
                    labelAPIError.Text = "Invalid API-Key.";
                else if (exc.Message.Contains("403 (Forbidden)"))
                    labelAPIError.Text = "Try again later.";
                else if (exc is NullReferenceException)
                    labelAPIError.Text = "Please add an API-Key.";
                else
                    labelAPIError.Text = exc.Message;
                Utility.TimeoutToDisappear(labelAPIError);
            }
            finally
            {
                if (ActiveAPIEntry != null)
                {
                    comboBoxAccount.Enabled = true;
                    buttonRefresh.Enabled = true;
                }
            }
        }
        
        private void SetToolTipTexts(ModuleData APIResponse)
        {
            string detailedInfo = "";
            if (APIResponse.materialLI > 0)
                detailedInfo += "On hand: " + APIResponse.materialLI + "\n";
            if (APIResponse.legendary_armor > 0)
                detailedInfo += "In Legendary Armor: " + APIResponse.legendary_armor + "\n";
            if (APIResponse.refined_armor > 0)
                detailedInfo += "In Refined Armor: " + APIResponse.refined_armor + "\n";
            if (APIResponse.gift_of_prowess > 0)
                detailedInfo += "In Gifts of Prowess: " + APIResponse.gift_of_prowess + "\n";
            if (APIResponse.envoy_insignia > 0)
                detailedInfo += "In Envoy Insignias: " + APIResponse.envoy_insignia + "\n";
            moduleRaids.LIDetail = detailedInfo;

            detailedInfo = "";
            if (APIResponse.materialLD > 0)
                detailedInfo += "On hand: " + APIResponse.materialLD + "\n";
            moduleRaids.LDDetail = detailedInfo;
        }

        #region menustrip
        private void toolStripMenuItemClose_Click(object sender, EventArgs e)
        {
            Environment.Exit(0);
        }

        private void toolStripMenuItemMinimize_Click(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Minimized;
        }

        private void menuStrip_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                ReleaseCapture();
                SendMessage(Handle, WM_NCLBUTTONDOWN, HT_CAPTION, 0);
            }
        }
        #endregion

        private void comboBoxAccount_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ActiveAPIEntry != null)
            {
                if (ActiveAPIEntry != APIEntries[comboBoxAccount.SelectedIndex])
                {
                    //SET MAINTAB ACTIVE ENTRY, REQUESTHANDLER ACTIVE ENTRY & RAIDSTAB ACTIVE ENTRY TO SELECTED ENTRY FROM COMBOBOX
                    var obj = (TabPage_Raids)RaidsTab;
                    ActiveAPIEntry =
                        obj.ActiveAPIEntry =
                        APIEntries[comboBoxAccount.SelectedIndex];

                    //REFRESH DATA DUE TO NEWLY SELECTED KEY
                    UpdateAccountOverview();
                }
            }
        }

        private void buttonRefresh_Click(object sender, EventArgs e)
        {
            if (ActiveAPIEntry != null)
            {
                //REFRESH RAID ENCOUNTER PROGRESS BY SETTING THE KEY
                var obj = (TabPage_Raids)RaidsTab;
                obj.ActiveAPIEntry = ActiveAPIEntry;

                //REFRESH OVERVIEW
                UpdateAccountOverview();
            }
        }
        
        private void buttonLaunch_Click(object sender, EventArgs e)
        {
            Process GW2 = new Process();
            GW2.StartInfo = new ProcessStartInfo(Path.Combine(Properties.Settings.Default.GameDir, "Gw2-64.exe"));
            GW2.StartInfo.Arguments = Properties.Settings.Default.StartParams;
            try
            {
                //RUN PROCESS
                GW2.Start();
                if (Properties.Settings.Default.LaunchBehavior == "MINIMIZE")
                {
                    //HIDE GUILD LOUNGE UNTIL GW2 IS CLOSED
                    Hide();
                    GW2.WaitForExit();
                    Show();

                    //REFRESH DATA AS SOON AS THE GAME IS CLOSED
                    UpdateAccountOverview();
                }
                else if (Properties.Settings.Default.LaunchBehavior == "CLOSE")
                    Environment.Exit(0);
            }
            catch (Exception exc)
            {
                if (exc is DirectoryNotFoundException || exc is FileNotFoundException || exc is System.ComponentModel.Win32Exception)
                    labelLaunchError.Text = "Invalid Game Directory.";
                else
                    labelLaunchError.Text = exc.Message;
                Utility.TimeoutToDisappear(labelLaunchError);
            }
        }
    }
}