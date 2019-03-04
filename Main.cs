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
        
        public Main()
        {
            InitializeComponent();

            //Initialize settings
            InitializeSettings();

            //Initialize loading icon
            InitializeLoadingIcon();
            
            //Initializing modules
            InitializeModules();
            InitializeModuleScrolling();

            //Initializing tabPages
            InitializeTabPages();
            InitializeToolPages();

            //Set Dashboard as the current tabPage
            SetActiveTab(DashboardTab, buttonDashboard);

            //Initializing required files
            InitializeFiles();

            //Automatically fetch API data on loadup
            try
            {
                GetAccounts();
                UpdateModuleData();
            }
            catch (Exception exc)
            {
                Console.WriteLine(exc.Message);
            }
        }

        #region misc
        //Required for mutex
        protected override void WndProc(ref Message m)
        {
            if (m.Msg == NativeMethods.WM_SHOWME)
            {
                ShowMe();
            }
            base.WndProc(ref m);
        }
        private void ShowMe()
        {
            if (WindowState == FormWindowState.Minimized)
            {
                WindowState = FormWindowState.Normal;
            }
            // get our current "TopMost" value (ours will always be false though)
            bool top = TopMost;
            // make our form jump to the top of everything
            TopMost = true;
            // set it back to whatever it was
            TopMost = top;
        }

        private void InitializeSettings()
        {
            //Upgrade the settings if necessary and save them
            if (Properties.Settings.Default.UpgradeRequired)
            {
                Properties.Settings.Default.Upgrade();
                Properties.Settings.Default.UpgradeRequired = false;
                Properties.Settings.Default.Save();
            }
        }
        
        private void InitializeFiles()
        {
            //Check if the required tree exists, and create relevant files

            //Base Directory
            if (!Directory.Exists(_appdata))
                Directory.CreateDirectory(_appdata);

            //Accounts file
            if (!File.Exists(Path.Combine(_appdata, "accounts.json")))
                File.Create(Path.Combine(_appdata, "accounts.json"));

            //Extensions file
            if (!File.Exists(Path.Combine(_appdata, "addons.json")))
                File.Create(Path.Combine(_appdata, "addons.json"));

            //Backup Local.DAT
            string gw2appdata = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "Guild Wars 2");
            if (!File.Exists(Path.Combine(_appdata, "Local.dat")))
                File.Copy(Path.Combine(gw2appdata, "Local.dat"), Path.Combine(_appdata, "Local.dat"));

            //updater.exe
            try
            {
                if (!File.Exists(Path.Combine(_appdata, "updater.exe")))
                    _client.DownloadFile("http://dev.guildlounge.com/updater.exe", Path.Combine(_appdata, "updater.exe"));
            }
            catch (Exception exc)
            {
                Console.WriteLine(exc.Message);
            }
        }
        
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

                comboBoxAccount.Enabled = true;
                buttonRefresh.Enabled = true;
                labelAPIError.Visible = false;
            }
            else
            {
                ActiveAccount = null;
                
                comboBoxAccount.Enabled = false;
                buttonRefresh.Enabled = false;
                labelAPIError.Visible = true;
            }

            buttonRefresh.Visible = true;
            LoadingIcon.Visible = false;

            //SET NEW KEY FOR RAIDS TAB
            var obj2 = (TabPages.Raids)RaidsTab;
            obj2.ActiveAccount = ActiveAccount;
        }
        #endregion

        #region modules
        public void InitializeModules()
        {
            for (int i = panelModulesInner.Controls.Count - 1; i >= 0; i--)
                panelModulesInner.Controls.RemoveAt(i);

            Point loc = new Point(0, 0);
            foreach (string s in Properties.Settings.Default.ActiveModules)
            {
                switch (s)
                {
                    case "Basic Currencies":
                        panelModulesInner.Controls.Add(new Modules.BaseCurrencies() { Location = loc });
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

        private void InitializeModuleScrolling()
        {
            //Fixing scrolling for modules
            panelModulesOuter.HorizontalScroll.Maximum = panelModulesInner.HorizontalScroll.Maximum = 0;
            panelModulesOuter.HorizontalScroll.Visible = panelModulesInner.HorizontalScroll.Visible = false;
            panelModulesOuter.VerticalScroll.Maximum = panelModulesInner.VerticalScroll.Maximum = 0;
            panelModulesOuter.VerticalScroll.Visible = panelModulesInner.VerticalScroll.Visible = false;
            panelModulesOuter.AutoScroll = panelModulesInner.AutoScroll = true;

            //Adding eventhandlers for module scrolling
            panelModulesOuter.MouseWheel += new MouseEventHandler(OnMouseWheelModules);
            panelModulesInner.MouseWheel += new MouseEventHandler(OnMouseWheelModules);
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
                {
                    labelAPIError.Text = "Invalid API-Key.";
                    Utility.TimeoutToDisappear(labelAPIError);
                }
                else if (exc.Message.Contains("403 (Forbidden)"))
                {
                    labelAPIError.Text = "Please try again later.";
                    Utility.TimeoutToDisappear(labelAPIError);
                }
                else if (exc is NullReferenceException)
                {
                    labelAPIError.Text = "Please add an API-Key.";
                    labelAPIError.Visible = true;
                }
                else
                {
                    labelAPIError.Text = exc.Message;
                    Utility.TimeoutToDisappear(labelAPIError);
                }
            }
            finally
            {
                if (ActiveAccount != null)
                {
                    comboBoxAccount.Enabled = true;
                    buttonRefresh.Enabled = true;
                    buttonRefresh.Visible = true;
                    LoadingIcon.Visible = false;
                    labelAPIError.Visible = false;
                }
            }
        }

        private int GetModulesOverflow()
        {
            if (panelModulesInner.Controls.Count <= 0)
                return panelModulesInner.Height;

            return panelModulesInner.Controls[panelModulesInner.Controls.Count - 1].Location.Y +
                panelModulesInner.Controls[panelModulesInner.Controls.Count - 1].Height;
        }

        protected void OnMouseWheelModules(object sender, MouseEventArgs e)
        {
            scrollbarModules.OnMouseWheel(sender, e);
            panelModulesInner.AutoScrollPosition = new Point(0, scrollbarModules.Value);
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
        #endregion

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

        #region events
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
        #endregion

        #region navigation
        private void InitializeLoadingIcon()
        {
            //Initializing loading icon
            LoadingIcon = new PictureBox()
            {
                Location = buttonRefresh.Location,
                Size = buttonRefresh.Size,
                Image = Properties.Resources.ui_refresh_ani,
                Visible = false
            };

            //Adding loading icon to controls
            panelAccount.Controls.Add(LoadingIcon);
        }

        private void InitializeTabPages()
        {
            //Initializing the pages
            DashboardTab = new TabPages.Dashboard();
            LFGTab = new TabPages.LFG();
            RaidsTab = new TabPages.Raids();
            GuidesTab = new TabPages.Guides();
            SettingsTab = new TabPages.Settings();

            //Fixing visibility
            DashboardTab.Visible
                = LFGTab.Visible
                = RaidsTab.Visible
                = GuidesTab.Visible
                = SettingsTab.Visible
                = false;

            //Fixing locations
            DashboardTab.Location
                = LFGTab.Location
                = RaidsTab.Location
                = GuidesTab.Location
                = SettingsTab.Location
                = new Point(0, 104);

            //Adding them as controls
            Controls.AddRange(new UserControl[]
            {
                DashboardTab,
                LFGTab,
                RaidsTab,
                GuidesTab,
                SettingsTab
            });
        }

        private void InitializeToolPages()
        {
            //Initializing the pages
            DailiesTab = new TabPages.Tools.Dailies();

            //Fixing visibility
            DailiesTab.Visible = false;

            //Fixing locations
            DailiesTab.Location = new Point(0, 104);

            //Adding them as controls
            Controls.AddRange(new UserControl[]
            {
                DailiesTab
            });
        }

        public void SetActiveTab(UserControl tab, object button)
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

            if (ActiveTabButton != null)
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
            if (File.Exists(Path.Combine(Properties.Settings.Default.GameDir, "Gw2-64.exe")))
                GW2.StartInfo = new ProcessStartInfo(Path.Combine(Properties.Settings.Default.GameDir, "Gw2-64.exe"));
            else
                GW2.StartInfo = new ProcessStartInfo(Path.Combine(Properties.Settings.Default.GameDir, "Gw2.exe"));
            GW2.StartInfo.Arguments = Properties.Settings.Default.StartParams;

            string gw2appdata = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "Guild Wars 2");
            string locl;
            if (ActiveAccount.Name != null && ActiveAccount.Name != "")
                locl = ActiveAccount.Name + "_Local.dat";
            else
                locl = ActiveAccount.Key.Substring(56) + "_Local.dat";

            try
            {
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
                else if (exc is IOException)
                    labelLaunchError.Text = "Game already running.";
                else
                    labelLaunchError.Text = exc.Message;
                Utility.TimeoutToDisappear(labelLaunchError);
            }
        }
        #endregion
    }
}