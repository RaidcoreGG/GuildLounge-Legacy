using System;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Net;
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
        private static readonly WebClient _client = new WebClient();

        //TAB CONTROL
        private UserControl ActiveTab;
        private Controls.NavigationButton ActiveTabButton;

        //MAIN PAGES
        private UserControl DashboardTab;
        private UserControl LFGTab;
        private UserControl RaidsTab;
        private UserControl GuidesTab;
        //private UserControl APIKeysTab;
        private UserControl SettingsTab;

        //TOOL PAGES
        public UserControl DailiesTab;

        //API STUFF
        private static readonly ApiHandler _api = new ApiHandler();
        public Account[] StoredAccounts { get; set; }
        private Account ActiveAccount { get; set; }

        //MISC
        private PictureBox LoadingIcon { get; set; }
        #endregion

        protected void OnMouseWheelModules(object sender, MouseEventArgs e)
        {
            scrollbarModules.OnMouseWheel(sender, e);
            panelModulesInner.AutoScrollPosition = new Point(0, scrollbarModules.Value);
        }

        public Main()
        {
            InitializeComponent();

            //UPGRADE SETTINGS IF VERSION HAS CHANGED
            if (Properties.Settings.Default.UpgradeRequired)
            {
                Properties.Settings.Default.Upgrade();
                Properties.Settings.Default.UpgradeRequired = false;
                Properties.Settings.Default.Save();
            }

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

            LoadModules();
            
            panelModulesOuter.MouseWheel += new MouseEventHandler(OnMouseWheelModules);
            panelModulesInner.MouseWheel += new MouseEventHandler(OnMouseWheelModules);

            //INITIALIZING MAIN PAGES
            DashboardTab = new TabPages.Dashboard();
            LFGTab = new TabPages.LFG();
            RaidsTab = new TabPages.Raids();
            GuidesTab = new TabPages.Guides();
            SettingsTab = new TabPages.Settings();

            //INITIALIZING TOOL PAGES
            DailiesTab = new TabPages.Tools.Dailies();

            //HIDING MAIN PAGES
            DashboardTab.Visible
                = LFGTab.Visible
                = RaidsTab.Visible
                = GuidesTab.Visible
                = SettingsTab.Visible
                = false;

            //HIDING TOOL PAGES
            DailiesTab.Visible = false;

            //FIXING MAIN PAGES LOCATION
            DashboardTab.Location
                = LFGTab.Location
                = RaidsTab.Location
                = GuidesTab.Location
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
            if (!File.Exists(Path.Combine(_appdata, "accounts.json")))
                File.Create(Path.Combine(_appdata, "accounts.json"));
            if (!File.Exists(Path.Combine(_appdata, "addons.json")))
                File.Create(Path.Combine(_appdata, "addons.json"));
            string gw2appdata = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "Guild Wars 2");
            if (!File.Exists(Path.Combine(_appdata, "Local.dat")))
                File.Copy(Path.Combine(gw2appdata, "Local.dat"), Path.Combine(_appdata, "Local.dat"));
            try
            {
                if (!File.Exists(Path.Combine(_appdata, "updater.exe")))
                    _client.DownloadFile("http://dev.guildlounge.com/updater.exe", Path.Combine(_appdata, "updater.exe"));
            }
            catch (Exception exc)
            {
                Console.WriteLine(exc.Message);
            }

            //API STUFF
            try
            {
                //GET KEYS FROM API KEYS TAB
                GetAccounts();

                //REQUEST&PROCESS DATA FROM API
                UpdateModuleData();
            }
            catch (Exception exc)
            {
                Console.WriteLine(exc.Message);
            }
        }

        public void LoadModules()
        {
            for (int i = panelModulesInner.Controls.Count-1; i >= 0; i--)
                panelModulesInner.Controls.RemoveAt(i);

            Point loc = new Point(0, 0);
            foreach(string s in Properties.Settings.Default.ActiveModules)
            {
                switch (s)
                {
                    case "Basic Currencies":
                        panelModulesInner.Controls.Add(new Modules.BaseCurrencies() { Location = loc});
                        break;
                    case "Fractals":
                        panelModulesInner.Controls.Add(new Modules.Fractals() { Location = loc });
                        break;
                    case "PvP":
                        panelModulesInner.Controls.Add(new Modules.PvP() { Location = loc });
                        break;
                    case "Raids":
                        panelModulesInner.Controls.Add(new Modules.Raids() { Location = loc });
                        break;
                    case "Trading Post Pickup":
                        panelModulesInner.Controls.Add(new Modules.TPPickup() { Location = loc });
                        break;
                    case "WvW":
                        panelModulesInner.Controls.Add(new Modules.WvW() { Location = loc });
                        break;
                }
                loc.Y += panelModulesInner.Controls[panelModulesInner.Controls.Count - 1].Height + 12;
            }

            scrollbarModules.Recalculate(panelModulesInner.Height, GetModulesOverflow());
            UpdateModuleData();
        }

        private int GetModulesOverflow()
        {
            if (panelModulesInner.Controls.Count <= 0)
                return panelModulesInner.Height;

            return panelModulesInner.Controls[panelModulesInner.Controls.Count - 1].Location.Y +
                panelModulesInner.Controls[panelModulesInner.Controls.Count - 1].Height;
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

        private void buttonSettings_Click(object sender, EventArgs e)
        {
            SetActiveTab(SettingsTab, sender);
        }
        #endregion

        public void GetAccounts()
        {
            //GET KEYS FROM KEYSTAB
            var obj = (TabPages.Settings)SettingsTab;
            StoredAccounts = obj.GetAccounts();

            if (StoredAccounts != null)
            {
                ActiveAccount = StoredAccounts[0];

                //UPDATE COMBOBOX ITEMS
                comboBoxAccount.Items.Clear();
                comboBoxAccount.Items.AddRange(StoredAccounts);

                //CORRECT DISPLAY
                comboBoxAccount.DisplayMember = "Name";
                comboBoxAccount.SelectedIndex = 0;

                comboBoxAccount.Enabled = false;
                buttonRefresh.Enabled = false;
            }
            else
            {
                ActiveAccount = null;
                
                comboBoxAccount.Enabled = true;
                buttonRefresh.Enabled = true;
                
            }

            buttonRefresh.Visible = true;
            LoadingIcon.Visible = false;

            //SET NEW KEY FOR RAIDS TAB
            var obj2 = (TabPages.Raids)RaidsTab;
            obj2.ActiveAccount = ActiveAccount;
        }

        private async void UpdateModuleData()
        {
            comboBoxAccount.Enabled = false;
            buttonRefresh.Enabled = false;
            buttonRefresh.Visible = false;
            LoadingIcon.Visible = true;

            try
            {
                ModuleData APIResponse = await _api.FetchModuleData(ActiveAccount.Key);

                var w = APIResponse.Wallet;
                var tp = APIResponse.TradingPost;

                foreach (Control m in panelModulesInner.Controls)
                {
                    if (m is Modules.BaseCurrencies)
                    {
                        ((Modules.BaseCurrencies)m).Coins = w.Coins;
                        ((Modules.BaseCurrencies)m).Karma = w.Karma;
                        ((Modules.BaseCurrencies)m).Laurels = w.Laurels;
                        ((Modules.BaseCurrencies)m).Gems = w.Gems;
                    }
                    else if (m is Modules.Fractals)
                    {
                        ((Modules.Fractals)m).FractalRelics = w.FractalRelics;
                        ((Modules.Fractals)m).PristineFractalRelics = w.PristineFractalRelics;
                    }
                    else if (m is Modules.PvP)
                    {
                        ((Modules.PvP)m).AscendedShardsOfGlory = w.AscendedShardsOfGlory;
                        ((Modules.PvP)m).LeagueTicket = w.LeagueTicket;
                    }
                    else if (m is Modules.Raids)
                    {
                        ((Modules.Raids)m).LegendaryInsights = APIResponse.TotalLegendaryInsights;
                        ((Modules.Raids)m).LegendaryDivinations = APIResponse.TotalLegendaryDivinations;
                        ((Modules.Raids)m).MagnetiteShards = w.MagnetiteShards;
                        ((Modules.Raids)m).GaetingCrystals = w.GaetingCrystals;

                        ((Modules.Raids)m).LIDetail = SetToolTipTextLI(APIResponse);
                        ((Modules.Raids)m).LDDetail = SetToolTipTextLD(APIResponse);
                    }
                    else if (m is Modules.TPPickup)
                    {
                        ((Modules.TPPickup)m).Coins = tp.Coins;
                        ((Modules.TPPickup)m).Items = tp.Items.Length;
                    }
                    else if (m is Modules.WvW)
                    {
                        ((Modules.WvW)m).BadgesOfHonor = w.BadgeOfHonor;
                        ((Modules.WvW)m).SkirmishTickets = w.SkirmishTicket;
                    }
                }

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
                if (ActiveAccount != null)
                {
                    comboBoxAccount.Enabled = true;
                    buttonRefresh.Enabled = true;
                    buttonRefresh.Visible = true;
                    LoadingIcon.Visible = false;
                }
            }
        }
        
        private string SetToolTipTextLI(ModuleData APIResponse)
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
            return detailedInfo;
        }

        private string SetToolTipTextLD(ModuleData APIResponse)
        {
            string detailedInfo = "";
            if (APIResponse.OnHandLD > 0)
                detailedInfo += "On hand: " + APIResponse.OnHandLD + "\n";
            return detailedInfo;
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
            if (ActiveAccount != null)
            {
                if (ActiveAccount != StoredAccounts[comboBoxAccount.SelectedIndex])
                {
                    //SET MAINTAB ACTIVE ENTRY, REQUESTHANDLER ACTIVE ENTRY & RAIDSTAB ACTIVE ENTRY TO SELECTED ENTRY FROM COMBOBOX
                    var obj = (TabPages.Raids)RaidsTab;
                    ActiveAccount =
                        obj.ActiveAccount =
                        StoredAccounts[comboBoxAccount.SelectedIndex];

                    //REFRESH DATA DUE TO NEWLY SELECTED KEY
                    UpdateModuleData();
                }
            }
        }

        private void buttonRefresh_Click(object sender, EventArgs e)
        {
            if (ActiveAccount != null)
            {
                //REFRESH RAID ENCOUNTER PROGRESS BY SETTING THE KEY
                var obj = (TabPages.Raids)RaidsTab;
                obj.ActiveAccount = ActiveAccount;

                //REFRESH OVERVIEW
                UpdateModuleData();
            }
        }
        
        private void buttonLaunch_Click(object sender, EventArgs e)
        {
            Process GW2 = new Process();
            GW2.StartInfo = new ProcessStartInfo(Path.Combine(Properties.Settings.Default.GameDir, "Gw2-64.exe"));
            GW2.StartInfo.Arguments = Properties.Settings.Default.StartParams;

            string gw2appdata = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "Guild Wars 2");
            string locl = ActiveAccount.Name + "_Local.dat";
            if (File.Exists(Path.Combine(_appdata, locl)))
            {
                File.Delete(Path.Combine(gw2appdata, "Local.dat"));
                File.Copy(Path.Combine(_appdata, locl), Path.Combine(gw2appdata, "Local.dat"));
            }
            else
            {
                File.Delete(Path.Combine(gw2appdata, "Local.dat"));
                File.Copy(Path.Combine(_appdata, "Local.dat"), Path.Combine(gw2appdata, "Local.dat"));
            }

            try
            {
                //RUN PROCESS
                GW2.Start();
                if (Properties.Settings.Default.LaunchBehavior == "MINIMIZE")
                {
                    //HIDE GUILD LOUNGE UNTIL GW2 IS CLOSED
                    Hide();
                    GW2.WaitForExit();

                    if (!File.Exists(Path.Combine(_appdata, locl)))
                        File.Copy(Path.Combine(gw2appdata, "Local.dat"), Path.Combine(_appdata, locl));

                    Show();

                    //REFRESH DATA AS SOON AS THE GAME IS CLOSED
                    UpdateModuleData();
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