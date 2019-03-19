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
        //related to dragging for the menustrip
        public const int WM_NCLBUTTONDOWN = 0xA1;
        public const int HT_CAPTION = 0x2;

        [DllImportAttribute("user32.dll")]
        public static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);
        [DllImportAttribute("user32.dll")]
        public static extern bool ReleaseCapture();
        #endregion

        #region variables
        //GuildLounge appdata folder and _client for updater
        private static string _appdata = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "GuildLounge");
        private static readonly WebClient _client = new WebClient();

        //tab control related
        private UserControl ActiveTab;
        private Controls.NavigationButton ActiveTabButton;

        //main pages
        private UserControl DashboardTab;
        private UserControl LFGTab;
        private UserControl RaidsTab;
        private UserControl GuidesTab;
        private UserControl SettingsTab;

        //tool pages
        public UserControl DailiesTab;
        public UserControl WindowedResolutionTab;
        public UserControl DPSLogOverviewTab;

        //api stuff
        private static readonly ApiHandler _api = new ApiHandler();
        public Account[] StoredAccounts { get; set; }
        public Account ActiveAccount { get; set; }

        //misc
        private PictureBox LoadingIcon { get; set; }
        #endregion
        
        public Main()
        {
            InitializeComponent();

            InitializeFiles();

            InitializeSettings();
            
            InitializeLoadingIcon();
            
            InitializeTabPages();
            InitializeToolPages();

            //Set Dashboard as the current tabPage
            SetActiveTab(DashboardTab, buttonDashboard);
            
            InitializeModuleScrolling();

            //Fetch accounts from the sub-page
            //Initialize modules, which also updates its data
            try
            {
                GetAccounts();
                InitializeModules();
            }
            catch (Exception exc)
            {
                Console.WriteLine(exc.Message);
            }
        }

        #region misc
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
            //Check if the required tree exists, and create relevant files if they don't exist

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
            //Fetch keys from accoungs page (over settings as a proxy)
            StoredAccounts = ((TabPages.Settings)SettingsTab).GetAccounts();

            if (StoredAccounts != null)
            {
                //Set the first one in the list as the active
                ActiveAccount = StoredAccounts[0];

                //Update combobox items
                comboBoxAccount.Items.Clear();
                comboBoxAccount.Items.AddRange(StoredAccounts);

                //Correct display of combobox
                comboBoxAccount.DisplayMember = "Name";
                comboBoxAccount.SelectedIndex = 0;

                //(Re-)enable combobox
                comboBoxAccount.Enabled = true;
                buttonRefresh.Enabled = true;
                labelAPIError.Visible = false;
            }
            else
            {
                ActiveAccount = null;
                
                //Disable combobox
                comboBoxAccount.Enabled = false;
                buttonRefresh.Enabled = false;
                labelAPIError.Visible = true;
            }

            //Show refreshbutton again / hide loadingicon
            buttonRefresh.Visible = true;
            LoadingIcon.Visible = false;

            //Set new key for raids page
            ((TabPages.Raids)RaidsTab).UpdateWeeklyRaidProgress(ActiveAccount.Key);
        }
        #endregion

        #region modules
        public void InitializeModules()
        {
            //This method loads the modules into the side panel
            
            //If any control (module) is added already, they will be removed
            for (int i = panelModulesInner.Controls.Count - 1; i >= 0; i--)
                panelModulesInner.Controls.RemoveAt(i);

            //Create a new point which will be shifted
            //to set the location of each module with a padding of 12
            Point loc = new Point(0, 0);
            //For each entry in ActiveModules load a module depending on what the saved string is
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
                //Shift the location down by last added module height + padding of 12
                loc.Y += panelModulesInner.Controls[panelModulesInner.Controls.Count - 1].Height + 12;
            }

            //Recalculate for the scrollbar to be displayed properly and refetch from the API
            scrollbarModules.Recalculate(panelModulesInner.Height, GetModulesOverflow());
            UpdateModuleData();
        }

        private int GetModulesOverflow()
        {
            //This method returns the the total height of the inner panel for the modules
            //The overflow is calculated by taking the last object (furthest down)
            //and adding its height to its location

            if (panelModulesInner.Controls.Count <= 0)
                return panelModulesInner.Height;

            return panelModulesInner.Controls[panelModulesInner.Controls.Count - 1].Location.Y +
                panelModulesInner.Controls[panelModulesInner.Controls.Count - 1].Height;
        }

        private void InitializeModuleScrolling()
        {
            //Since this uses a custom scrollbar, some tweaking is required

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
            //This method fetches the data from the API and assigns it to the modules

            //Disable the combobox and refresh button
            //Hide refresh button and show loading icon
            comboBoxAccount.Enabled = false;
            buttonRefresh.Enabled = false;
            buttonRefresh.Visible = false;
            LoadingIcon.Visible = true;

            try
            {
                ModuleData APIResponse = await _api.FetchModuleData(ActiveAccount.Key);

                //Assign temporary variables to make the assigning easier
                var w = APIResponse.Wallet;
                var tp = APIResponse.TradingPost;

                //For each module assign the proper data
                foreach (Control mod in panelModulesInner.Controls)
                {
                    if (mod is Modules.BaseCurrencies)
                    {
                        ((Modules.BaseCurrencies)mod).Coins = w.Coins;
                        ((Modules.BaseCurrencies)mod).Karma = w.Karma;
                        ((Modules.BaseCurrencies)mod).Laurels = w.Laurels;
                        ((Modules.BaseCurrencies)mod).Gems = w.Gems;
                    }
                    else if (mod is Modules.Fractals)
                    {
                        ((Modules.Fractals)mod).FractalRelics = w.FractalRelics;
                        ((Modules.Fractals)mod).PristineFractalRelics = w.PristineFractalRelics;
                    }
                    else if (mod is Modules.PvP)
                    {
                        ((Modules.PvP)mod).AscendedShardsOfGlory = w.AscendedShardsOfGlory;
                        ((Modules.PvP)mod).LeagueTicket = w.LeagueTicket;
                    }
                    else if (mod is Modules.Raids)
                    {
                        ((Modules.Raids)mod).LegendaryInsights = APIResponse.TotalLegendaryInsights;
                        ((Modules.Raids)mod).LegendaryDivinations = APIResponse.TotalLegendaryDivinations;
                        ((Modules.Raids)mod).MagnetiteShards = w.MagnetiteShards;
                        ((Modules.Raids)mod).GaetingCrystals = w.GaetingCrystals;

                        ((Modules.Raids)mod).LIDetail = SetToolTipTextLI(APIResponse);
                        ((Modules.Raids)mod).LDDetail = SetToolTipTextLD(APIResponse);
                    }
                    else if (mod is Modules.TPPickup)
                    {
                        ((Modules.TPPickup)mod).Coins = tp.Coins;
                        ((Modules.TPPickup)mod).Items = tp.Items.Length;
                    }
                    else if (mod is Modules.WvW)
                    {
                        ((Modules.WvW)mod).BadgesOfHonor = w.BadgeOfHonor;
                        ((Modules.WvW)mod).SkirmishTickets = w.SkirmishTicket;
                    }
                }

            }
            catch (Exception exc)
            {
                //Show "somewhat" accurate error messages
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
                //If an account is saved re-enable combobox + refreshbutton
                //show refreshbutton
                //hide loadingicon and error label
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
        
        protected void OnMouseWheelModules(object sender, MouseEventArgs e)
        {
            //Scrolling
            scrollbarModules.OnMouseWheel(sender, e);
            panelModulesInner.AutoScrollPosition = new Point(0, scrollbarModules.Value);
        }

        private string SetToolTipTextLI(ModuleData APIResponse)
        {
            //Set the detailed info message on hover for LI

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
            //Set the detailed info message on hover for LD

            string detailedInfo = "";
            if (APIResponse.OnHandLD > 0)
                detailedInfo += "On hand: " + APIResponse.OnHandLD + "\n";
            return detailedInfo;
        }
        #endregion

        #region menustrip
        private void toolStripMenuItemClose_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void toolStripMenuItemMinimize_Click(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Minimized;
        }

        private void menuStrip_MouseDown(object sender, MouseEventArgs e)
        {
            //Dragging
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
            //This method updates the active account if a new one was selected
            //it also updates the key for the raid page
            //and refetches the module data from the API

            if (ActiveAccount == null)
                return;

            if (ActiveAccount != StoredAccounts[comboBoxAccount.SelectedIndex])
            {
                ActiveAccount = StoredAccounts[comboBoxAccount.SelectedIndex];
                ((TabPages.Raids)RaidsTab).UpdateWeeklyRaidProgress(ActiveAccount.Key);
                UpdateModuleData();
            }
        }
        #endregion

        #region navigation
        private void InitializeLoadingIcon()
        {
            //This method initializes the loading icon
            //which is shown when the API is called

            //this is a workaround to changing the button icon
            //because GIFs won't play if the button is disabled

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
            WindowedResolutionTab = new TabPages.Tools.WindowedResolution();
            DPSLogOverviewTab = new TabPages.Tools.DPSLogOverview();

            //Fixing visibility
            DailiesTab.Visible
                = WindowedResolutionTab.Visible
                = DPSLogOverviewTab.Visible
                = false;

            //Fixing locations
            DailiesTab.Location
                = WindowedResolutionTab.Location
                = DPSLogOverviewTab.Location
                = new Point(0, 104);

            //Adding them as controls
            Controls.AddRange(new UserControl[]
            {
                DailiesTab,
                WindowedResolutionTab,
                DPSLogOverviewTab
            });
        }

        public void SetActiveTab(UserControl tab, object button)
        {
            //This method is part of the tab control
            //It handles the hiding of the old tab
            //and the showing of the new tab
            //it also handles the red underline for the navigation buttons
            //it does that by setting the button to Active (a custom property)

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
            //this method refreshes the module data and the raids page data

            if (ActiveAccount == null)
                return;

            //Refresh raids by setting the key
            ((TabPages.Raids)RaidsTab).UpdateWeeklyRaidProgress(ActiveAccount.Key);
            
            UpdateModuleData();
        }

        private void buttonLaunch_Click(object sender, EventArgs e)
        {
            //Create a new process to launch GW2
            Process GW2 = new Process();
            //Use 64-Bit version of GW2 if it exists, else fallback to 32-Bit
            if (File.Exists(Path.Combine(Properties.Settings.Default.GameDir, "Gw2-64.exe")))
                GW2.StartInfo = new ProcessStartInfo(Path.Combine(Properties.Settings.Default.GameDir, "Gw2-64.exe"));
            else
                GW2.StartInfo = new ProcessStartInfo(Path.Combine(Properties.Settings.Default.GameDir, "Gw2.exe"));
            //Set the start parameters
            GW2.StartInfo.Arguments = Properties.Settings.Default.StartParams;

            //"Generate" the Local.dat that is used
            string gw2appdata = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "Guild Wars 2");
            string locl;

            //If no account is set, use the copy of Local.dat
            //else, if the name of the current account is set, use the name
            //else use the ending 16 characters of the API-Key stored
            if (ActiveAccount == null)
                locl = "Local.dat";
            else
            {
                if (ActiveAccount.Name != null && ActiveAccount.Name != "")
                    locl = ActiveAccount.Name + "_Local.dat";
                else
                    locl = ActiveAccount.Key.Substring(56) + "_Local.dat";
            }

            try
            {
                //If a file is found with the "generated" Local.dat name, copy it to the gw2appdata directory
                //else use the copy
                if (File.Exists(Path.Combine(_appdata, locl)))
                {
                    if(locl == "Local.dat")
                    {
                        if(!File.Exists(Path.Combine(gw2appdata, "Local.dat")))
                        {
                            File.Delete(Path.Combine(gw2appdata, "Local.dat"));
                            File.Copy(Path.Combine(_appdata, locl), Path.Combine(gw2appdata, "Local.dat"));
                        }
                    }
                    else
                    {
                        File.Delete(Path.Combine(gw2appdata, "Local.dat"));
                        File.Copy(Path.Combine(_appdata, locl), Path.Combine(gw2appdata, "Local.dat"));
                    }
                }
                else
                {
                    File.Delete(Path.Combine(gw2appdata, "Local.dat"));
                    File.Copy(Path.Combine(_appdata, "Local.dat"), Path.Combine(gw2appdata, "Local.dat"));
                }

                //Start the process
                GW2.Start();
                //Depending on the setting hide, close or do nothing with GuildLounge
                if (Properties.Settings.Default.LaunchBehavior == "MINIMIZE")
                {
                    //Hide GuildLounge until GW2 is exited
                    Hide();
                    GW2.WaitForExit();

                    //Copy the Local.dat if it wasn't created already for the current account
                    if (!File.Exists(Path.Combine(_appdata, locl)))
                        File.Copy(Path.Combine(gw2appdata, "Local.dat"), Path.Combine(_appdata, locl));

                    //Display GuildLounge again
                    Show();

                    //Refresh the module data and the dpslog data
                    UpdateModuleData();
                    ((TabPages.Tools.DPSLogOverview)DPSLogOverviewTab).GetEncounters();
                }
                else if (Properties.Settings.Default.LaunchBehavior == "CLOSE")
                    Environment.Exit(0);
            }
            catch (Exception exc)
            {
                //"somewhat" accurate error messages
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