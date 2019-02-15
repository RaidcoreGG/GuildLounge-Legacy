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
        private Controls.NavigationButton ActiveTabButton;

        //MAIN PAGES
        private UserControl DashboardTab;
        private UserControl LFGTab;
        private UserControl RaidsTab;
        private UserControl GuidesTab;
        private UserControl APIKeysTab;
        private UserControl SettingsTab;

        //TOOL PAGES
        public UserControl DailiesTab;

        //API STUFF
        private static readonly ApiHandler _api = new ApiHandler();
        public Account[] APIEntries { get; set; }
        private Account ActiveAPIEntry { get; set; }

        //MISC
        private PictureBox LoadingIcon { get; set; }
        #endregion

        protected void OnMouseWheelModules(object sender, MouseEventArgs e)
        {
            scrollbarModules.OnMouseWheel(sender, e);
            panelModulesInner.AutoScrollPosition = new Point(0, scrollbarModules.Value);
            //panelOverview.Invalidate();
        }

        public Main()
        {
            InitializeComponent();

            //INITIALIZE LOADING ICON
            LoadingIcon = new PictureBox()
            {
                Location = buttonRefresh.Location,
                Size = buttonRefresh.Size,
                Image = Properties.Resources.ui_refresh_ani,
                Visible = false
            };

            panelAccount.Controls.Add(LoadingIcon);

            //DISABLE HORIZONTAL SCROLL FOR MODULES PANEL
            panelModulesOuter.HorizontalScroll.Maximum = panelModulesInner.HorizontalScroll.Maximum = 0;
            panelModulesOuter.HorizontalScroll.Visible = panelModulesInner.HorizontalScroll.Visible = false;
            panelModulesOuter.VerticalScroll.Maximum = panelModulesInner.VerticalScroll.Maximum = 0;
            panelModulesOuter.VerticalScroll.Visible = panelModulesInner.VerticalScroll.Visible = false;
            panelModulesOuter.AutoScroll = panelModulesInner.AutoScroll = true;

            scrollbarModules.Recalculate(342, 582);
            panelModulesOuter.MouseWheel += new MouseEventHandler(OnMouseWheelModules);
            panelModulesInner.MouseWheel += new MouseEventHandler(OnMouseWheelModules);

            //INITIALIZING MAIN PAGES
            DashboardTab = new TabPages.Dashboard();
            LFGTab = new TabPages.LFG();
            RaidsTab = new TabPages.Raids();
            GuidesTab = new TabPages.Guides();
            APIKeysTab = new TabPages.APIKeys();
            SettingsTab = new TabPages.Settings_old();

            //INITIALIZING TOOL PAGES
            DailiesTab = new TabPages.Tools.Dailies();

            //HIDING MAIN PAGES
            DashboardTab.Visible
                = LFGTab.Visible
                = RaidsTab.Visible
                = GuidesTab.Visible
                = APIKeysTab.Visible
                = SettingsTab.Visible
                = false;

            //HIDING TOOL PAGES
            DailiesTab.Visible = false;

            //FIXING MAIN PAGES LOCATION
            DashboardTab.Location
                = LFGTab.Location
                = RaidsTab.Location
                = GuidesTab.Location
                = APIKeysTab.Location
                = SettingsTab.Location
                = new Point(0, 104);

            //FIXING TOOL PAGES LOCATION
            DailiesTab.Location = new Point(0, 104);

            //ADDING MAIN TABS TO CONTROLS OF MAIN FORM
            Controls.AddRange(new UserControl[]
            {
                DashboardTab,
                LFGTab,
                RaidsTab,
                GuidesTab,
                APIKeysTab,
                SettingsTab
            });

            //ADDING TOOL TABS TO CONTROLS OF MAIN FORM
            Controls.AddRange(new UserControl[]
            {
                DailiesTab
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
        public void SetActiveTab(UserControl tab, object button)
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
                if (button is Controls.NavigationButton)
                {
                    ActiveTabButton.Active = false;
                    ActiveTabButton = (Controls.NavigationButton)button;
                    ActiveTabButton.Active = true;
                }
                else
                    ActiveTabButton.Active = false;
            }
            else
            {
                ActiveTabButton = (Controls.NavigationButton)button;
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

        private void buttonSettings_Click(object sender, EventArgs e)
        {
            SetActiveTab(SettingsTab, sender);
        }
        #endregion

        public void RefreshKeys()
        {
            //GET KEYS FROM KEYSTAB
            var obj = (TabPages.APIKeys)APIKeysTab;
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
            var obj2 = (TabPages.Raids)RaidsTab;
            obj2.ActiveAPIEntry = ActiveAPIEntry;
        }

        private async void UpdateAccountOverview()
        {
            comboBoxAccount.Enabled = false;
            buttonRefresh.Enabled = false;
            buttonRefresh.Visible = false;
            LoadingIcon.Visible = true;

            try
            {
                ModuleData APIResponse = await _api.FetchModuleData(ActiveAPIEntry.Key);

                var w = APIResponse.Wallet;
                var tp = APIResponse.TradingPost;

                //RAIDS
                moduleRaids.LegendaryInsights = APIResponse.TotalLegendaryInsights;
                moduleRaids.LegendaryDivinations = APIResponse.TotalLegendaryDivinations;
                moduleRaids.MagnetiteShards = w.MagnetiteShards;
                moduleRaids.GaetingCrystals = w.GaetingCrystals;

                SetToolTipTexts(APIResponse);

                //FRACTALS
                moduleFractals.FractalRelics = w.FractalRelics;
                moduleFractals.PristineFractalRelics = w.PristineFractalRelics;

                //WVW
                moduleWvW.BadgesOfHonor = w.BadgeOfHonor;
                moduleWvW.SkirmishTickets = w.SkirmishTicket;

                //PVP
                modulePvP.AscendedShardsOfGlory = w.AscendedShardsOfGlory;
                modulePvP.LeagueTicket = w.LeagueTicket;

                //COINS
                moduleBaseCurrencies.Coins = w.Coins;
                moduleBaseCurrencies.Karma = w.Karma;
                moduleBaseCurrencies.Laurels = w.Laurels;
                moduleBaseCurrencies.Gems = w.Gems;

                //TP PICKUP
                moduleTPPickup.Coins = tp.Coins;
                moduleTPPickup.Items = tp.Items.Length;
                
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
                    buttonRefresh.Visible = true;
                    LoadingIcon.Visible = false;
                }
            }
        }
        
        private void SetToolTipTexts(ModuleData APIResponse)
        {
            string detailedInfo = "";
            if (APIResponse.OnHandLI > 0)
                detailedInfo += "On hand: " + APIResponse.OnHandLI + "\n";
            if (APIResponse.LegendaryArmor > 0)
                detailedInfo += "In Legendary Armor: " + APIResponse.LegendaryArmor + "\n";
            if (APIResponse.RefinedArmor > 0)
                detailedInfo += "In Refined Armor: " + APIResponse.RefinedArmor + "\n";
            if (APIResponse.GiftOfProwess > 0)
                detailedInfo += "In Gifts of Prowess: " + APIResponse.GiftOfProwess + "\n";
            if (APIResponse.EnvoyInsignia > 0)
                detailedInfo += "In Envoy Insignias: " + APIResponse.EnvoyInsignia + "\n";
            moduleRaids.LIDetail = detailedInfo;

            detailedInfo = "";
            if (APIResponse.OnHandLD > 0)
                detailedInfo += "On hand: " + APIResponse.OnHandLD + "\n";
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
                    var obj = (TabPages.Raids)RaidsTab;
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
                var obj = (TabPages.Raids)RaidsTab;
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