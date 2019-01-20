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
        private GL_NavigationButton ActiveTabButton;

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

        //LI/LD OVERVIEW
        private GL_ToolTip ToolTipLI;
        private GL_ToolTip ToolTipLD;
        #endregion

        public Main()
        {
            InitializeComponent();

            //INITIALIZING TABS
            DashboardTab = new UserControl_Dashboard();
            LFGTab = new UserControl_LFG();
            RaidsTab = new UserControl_Raids();
            GuidesTab = new UserControl_Guides();
            APIKeysTab = new UserControl_APIKeys();
            SettingsTab = new UserControl_Settings();

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

                //CREATE OBJECTS FOR REQUEST MANAGEMENT
                ToolTipLI = new GL_ToolTip();
                ToolTipLD = new GL_ToolTip();

                //REQUEST&PROCESS DATA FROM API
                UpdateAccountOverview();

                //ADD INFO TOOLTIPS TO LI & LD ON HOVER
                //THESE WON'T BE CREATED IF THERE IS NO API KEY PRESENT AS THIS CODE WON'T BE REACHED DUE TO A THROWN EXCEPTION
                this.pictureBoxLI.MouseEnter += new System.EventHandler(this.LI_OnMouseEnter);
                this.pictureBoxLI.MouseLeave += new System.EventHandler(this.LI_OnMouseLeave);
                this.pictureBoxLD.MouseEnter += new System.EventHandler(this.LD_OnMouseEnter);
                this.pictureBoxLD.MouseLeave += new System.EventHandler(this.LD_OnMouseLeave);
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
                if (button is GL_NavigationButton)
                {
                    ActiveTabButton.Active = false;
                    ActiveTabButton = (GL_NavigationButton)button;
                    ActiveTabButton.Active = true;
                }
                else
                    ActiveTabButton.Active = false;
            }
            else
            {
                ActiveTabButton = (GL_NavigationButton)button;
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
            var obj = (UserControl_APIKeys)APIKeysTab;
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
            var obj2 = (UserControl_Raids)RaidsTab;
            obj2.ActiveAPIEntry = ActiveAPIEntry;
        }

        private async void UpdateAccountOverview()
        {
            comboBoxAccount.Enabled = false;
            buttonRefresh.Enabled = false;

            try
            {
                AccountOverview APIResponse = await _api.FetchAccountOverview(ActiveAPIEntry.Key);

                var w = APIResponse.wallet;

                //RAIDS
                labelLI.Text = APIResponse.sumLI.ToString();
                labelLD.Text = APIResponse.sumLD.ToString();
                labelMagnetiteShard.Text = w.magnetite.ToString();
                labelGaetingCrystal.Text = w.gaeting.ToString();

                //FRACTALS
                labelFractalRelics.Text = w.fractalrelic.ToString();
                labelPristineFractalRelics.Text = w.pristinefractalrelic.ToString();

                //WVW
                labelBadgeOfHonor.Text = w.badgeofhonor.ToString();
                labelWvWSkirmishTicket.Text = w.wvwskirmishticket.ToString();

                //PVP
                labelAscendedShardsOfGlory.Text = w.ascendedshardsofglory.ToString();
                labelPvPLeagueTicket.Text = w.pvpleagueticket.ToString();

                SetToolTipTexts(APIResponse);
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
                ErrorInfo.TimeoutToDisappear(labelAPIError);
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

        #region infoToolTips

        private void SetToolTipTexts(AccountOverview APIResponse)
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
            ToolTipLI.Text = detailedInfo;

            detailedInfo = "";
            if (APIResponse.materialLD > 0)
                detailedInfo += "On hand: " + APIResponse.materialLD + "\n";
            ToolTipLD.Text = detailedInfo;
        }

        private void LI_OnMouseEnter(object sender, EventArgs e)
        {
            var obj = (PictureBox)sender;
            ToolTipLI.Show(ToolTipLI.Text, obj, 0, obj.Height);
        }

        private void LI_OnMouseLeave(object sender, EventArgs e)
        {
            ToolTipLI.Hide(this);
        }

        private void LD_OnMouseEnter(object sender, EventArgs e)
        {
            var obj = (PictureBox)sender;
            ToolTipLD.Show(ToolTipLD.Text, obj, 0, obj.Height);
        }

        private void LD_OnMouseLeave(object sender, EventArgs e)
        {
            ToolTipLD.Hide(this);
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

        private void comboBoxAccount_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ActiveAPIEntry != null)
            {
                if (ActiveAPIEntry != APIEntries[comboBoxAccount.SelectedIndex])
                {
                    //SET MAINTAB ACTIVE ENTRY, REQUESTHANDLER ACTIVE ENTRY & RAIDSTAB ACTIVE ENTRY TO SELECTED ENTRY FROM COMBOBOX
                    var obj = (UserControl_Raids)RaidsTab;
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
                var obj = (UserControl_Raids)RaidsTab;
                obj.ActiveAPIEntry = ActiveAPIEntry;

                //REFRESH OVERVIEW
                UpdateAccountOverview();
            }
        }
        
        private void buttonLaunch_Click(object sender, EventArgs e)
        {
            //CREATING PROCESS WITH PATH AND PARAMETERS FROM SETTINGS
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
                ErrorInfo.TimeoutToDisappear(labelLaunchError);
            }
        }
    }
}