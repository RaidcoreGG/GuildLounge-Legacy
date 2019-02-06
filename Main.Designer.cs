namespace GuildLounge
{
    partial class Main
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Main));
            this.panelNavigation = new System.Windows.Forms.Panel();
            this.gL_HorizontalLine1 = new GuildLounge.Control_HorizontalLine();
            this.buttonGuides = new GuildLounge.Control_NavigationButton();
            this.buttonRaids = new GuildLounge.Control_NavigationButton();
            this.buttonLFG = new GuildLounge.Control_NavigationButton();
            this.buttonDashboard = new GuildLounge.Control_NavigationButton();
            this.panelOverview = new System.Windows.Forms.Panel();
            this.moduleTPPickup = new GuildLounge.Module_TPPickup();
            this.moduleBaseCurrencies = new GuildLounge.Module_BaseCurrencies();
            this.modulePvP = new GuildLounge.Module_PvP();
            this.moduleWvW = new GuildLounge.Module_WvW();
            this.moduleFractals = new GuildLounge.Module_Fractals();
            this.moduleRaids = new GuildLounge.Module_Raids();
            this.menuStrip = new GuildLounge.Control_MenuStrip();
            this.toolStripMenuItemClose = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItemMinimize = new System.Windows.Forms.ToolStripMenuItem();
            this.panelAccount = new System.Windows.Forms.Panel();
            this.buttonRefresh = new System.Windows.Forms.Button();
            this.labelAPIError = new System.Windows.Forms.Label();
            this.linkLabelSettings = new System.Windows.Forms.LinkLabel();
            this.comboBoxAccount = new System.Windows.Forms.ComboBox();
            this.linkLabelAPIKeys = new System.Windows.Forms.LinkLabel();
            this.panelLaunch = new System.Windows.Forms.Panel();
            this.labelLaunchError = new System.Windows.Forms.Label();
            this.buttonLaunch = new GuildLounge.Control_HighlightButton();
            this.panelNavigation.SuspendLayout();
            this.panelOverview.SuspendLayout();
            this.menuStrip.SuspendLayout();
            this.panelAccount.SuspendLayout();
            this.panelLaunch.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelNavigation
            // 
            this.panelNavigation.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(55)))), ((int)(((byte)(55)))), ((int)(((byte)(55)))));
            this.panelNavigation.Controls.Add(this.gL_HorizontalLine1);
            this.panelNavigation.Controls.Add(this.buttonGuides);
            this.panelNavigation.Controls.Add(this.buttonRaids);
            this.panelNavigation.Controls.Add(this.buttonLFG);
            this.panelNavigation.Controls.Add(this.buttonDashboard);
            this.panelNavigation.Location = new System.Drawing.Point(0, 24);
            this.panelNavigation.Name = "panelNavigation";
            this.panelNavigation.Size = new System.Drawing.Size(740, 80);
            this.panelNavigation.TabIndex = 0;
            // 
            // gL_HorizontalLine1
            // 
            this.gL_HorizontalLine1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(45)))));
            this.gL_HorizontalLine1.Location = new System.Drawing.Point(12, 78);
            this.gL_HorizontalLine1.Name = "gL_HorizontalLine1";
            this.gL_HorizontalLine1.Size = new System.Drawing.Size(716, 2);
            this.gL_HorizontalLine1.TabIndex = 5;
            this.gL_HorizontalLine1.Text = "gL_HorizontalLine1";
            // 
            // buttonGuides
            // 
            this.buttonGuides.Active = false;
            this.buttonGuides.BackColor = System.Drawing.Color.Transparent;
            this.buttonGuides.Enabled = false;
            this.buttonGuides.FlatAppearance.BorderSize = 0;
            this.buttonGuides.FlatAppearance.CheckedBackColor = System.Drawing.Color.Transparent;
            this.buttonGuides.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.buttonGuides.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.buttonGuides.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonGuides.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.buttonGuides.ForeColor = System.Drawing.Color.Gray;
            this.buttonGuides.Location = new System.Drawing.Point(560, 19);
            this.buttonGuides.Name = "buttonGuides";
            this.buttonGuides.Size = new System.Drawing.Size(110, 40);
            this.buttonGuides.TabIndex = 4;
            this.buttonGuides.Text = "Guides";
            this.buttonGuides.UseVisualStyleBackColor = false;
            this.buttonGuides.Click += new System.EventHandler(this.buttonGuides_Click);
            // 
            // buttonRaids
            // 
            this.buttonRaids.Active = false;
            this.buttonRaids.BackColor = System.Drawing.Color.Transparent;
            this.buttonRaids.FlatAppearance.BorderSize = 0;
            this.buttonRaids.FlatAppearance.CheckedBackColor = System.Drawing.Color.Transparent;
            this.buttonRaids.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.buttonRaids.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.buttonRaids.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonRaids.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.buttonRaids.ForeColor = System.Drawing.Color.Gray;
            this.buttonRaids.Location = new System.Drawing.Point(405, 19);
            this.buttonRaids.Name = "buttonRaids";
            this.buttonRaids.Size = new System.Drawing.Size(110, 40);
            this.buttonRaids.TabIndex = 3;
            this.buttonRaids.Text = "Raids";
            this.buttonRaids.UseVisualStyleBackColor = false;
            this.buttonRaids.Click += new System.EventHandler(this.buttonRaids_Click);
            // 
            // buttonLFG
            // 
            this.buttonLFG.Active = false;
            this.buttonLFG.BackColor = System.Drawing.Color.Transparent;
            this.buttonLFG.Enabled = false;
            this.buttonLFG.FlatAppearance.BorderSize = 0;
            this.buttonLFG.FlatAppearance.CheckedBackColor = System.Drawing.Color.Transparent;
            this.buttonLFG.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.buttonLFG.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.buttonLFG.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonLFG.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.buttonLFG.ForeColor = System.Drawing.Color.Gray;
            this.buttonLFG.Location = new System.Drawing.Point(250, 19);
            this.buttonLFG.Name = "buttonLFG";
            this.buttonLFG.Size = new System.Drawing.Size(110, 40);
            this.buttonLFG.TabIndex = 2;
            this.buttonLFG.Text = "LFG";
            this.buttonLFG.UseVisualStyleBackColor = false;
            this.buttonLFG.Click += new System.EventHandler(this.buttonLFG_Click);
            // 
            // buttonDashboard
            // 
            this.buttonDashboard.Active = false;
            this.buttonDashboard.BackColor = System.Drawing.Color.Transparent;
            this.buttonDashboard.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("buttonDashboard.BackgroundImage")));
            this.buttonDashboard.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.buttonDashboard.FlatAppearance.BorderSize = 0;
            this.buttonDashboard.FlatAppearance.CheckedBackColor = System.Drawing.Color.Transparent;
            this.buttonDashboard.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.buttonDashboard.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.buttonDashboard.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonDashboard.ForeColor = System.Drawing.Color.Gray;
            this.buttonDashboard.Location = new System.Drawing.Point(10, 10);
            this.buttonDashboard.Name = "buttonDashboard";
            this.buttonDashboard.Size = new System.Drawing.Size(150, 60);
            this.buttonDashboard.TabIndex = 1;
            this.buttonDashboard.UseVisualStyleBackColor = false;
            this.buttonDashboard.Click += new System.EventHandler(this.buttonDashboard_Click);
            // 
            // panelOverview
            // 
            this.panelOverview.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(45)))));
            this.panelOverview.Controls.Add(this.moduleTPPickup);
            this.panelOverview.Controls.Add(this.moduleBaseCurrencies);
            this.panelOverview.Controls.Add(this.modulePvP);
            this.panelOverview.Controls.Add(this.moduleWvW);
            this.panelOverview.Controls.Add(this.moduleFractals);
            this.panelOverview.Controls.Add(this.moduleRaids);
            this.panelOverview.Location = new System.Drawing.Point(740, 104);
            this.panelOverview.Name = "panelOverview";
            this.panelOverview.Size = new System.Drawing.Size(220, 366);
            this.panelOverview.TabIndex = 0;
            // 
            // moduleTPPickup
            // 
            this.moduleTPPickup.BackColor = System.Drawing.Color.Transparent;
            this.moduleTPPickup.Coins = 0;
            this.moduleTPPickup.ForeColor = System.Drawing.Color.White;
            this.moduleTPPickup.Items = 0;
            this.moduleTPPickup.Location = new System.Drawing.Point(12, 488);
            this.moduleTPPickup.Name = "moduleTPPickup";
            this.moduleTPPickup.Size = new System.Drawing.Size(196, 94);
            this.moduleTPPickup.TabIndex = 28;
            // 
            // moduleBaseCurrencies
            // 
            this.moduleBaseCurrencies.BackColor = System.Drawing.Color.Transparent;
            this.moduleBaseCurrencies.Coins = 0;
            this.moduleBaseCurrencies.ForeColor = System.Drawing.Color.White;
            this.moduleBaseCurrencies.Gems = 0;
            this.moduleBaseCurrencies.Karma = 0;
            this.moduleBaseCurrencies.Laurels = 0;
            this.moduleBaseCurrencies.Location = new System.Drawing.Point(12, 352);
            this.moduleBaseCurrencies.Name = "moduleBaseCurrencies";
            this.moduleBaseCurrencies.Size = new System.Drawing.Size(196, 124);
            this.moduleBaseCurrencies.TabIndex = 3;
            // 
            // modulePvP
            // 
            this.modulePvP.AscendedShardsOfGlory = 0;
            this.modulePvP.BackColor = System.Drawing.Color.Transparent;
            this.modulePvP.ForeColor = System.Drawing.Color.White;
            this.modulePvP.LeagueTicket = 0;
            this.modulePvP.Location = new System.Drawing.Point(12, 274);
            this.modulePvP.Name = "modulePvP";
            this.modulePvP.Size = new System.Drawing.Size(196, 66);
            this.modulePvP.TabIndex = 27;
            // 
            // moduleWvW
            // 
            this.moduleWvW.BackColor = System.Drawing.Color.Transparent;
            this.moduleWvW.BadgesOfHonor = 0;
            this.moduleWvW.ForeColor = System.Drawing.Color.White;
            this.moduleWvW.Location = new System.Drawing.Point(12, 196);
            this.moduleWvW.Name = "moduleWvW";
            this.moduleWvW.Size = new System.Drawing.Size(196, 66);
            this.moduleWvW.SkirmishTickets = 0;
            this.moduleWvW.TabIndex = 26;
            // 
            // moduleFractals
            // 
            this.moduleFractals.BackColor = System.Drawing.Color.Transparent;
            this.moduleFractals.ForeColor = System.Drawing.Color.White;
            this.moduleFractals.FractalRelics = 0;
            this.moduleFractals.Location = new System.Drawing.Point(12, 118);
            this.moduleFractals.Name = "moduleFractals";
            this.moduleFractals.PristineFractalRelics = 0;
            this.moduleFractals.Size = new System.Drawing.Size(196, 66);
            this.moduleFractals.TabIndex = 25;
            // 
            // moduleRaids
            // 
            this.moduleRaids.BackColor = System.Drawing.Color.Transparent;
            this.moduleRaids.ForeColor = System.Drawing.Color.White;
            this.moduleRaids.GaetingCrystals = 0;
            this.moduleRaids.LDDetail = null;
            this.moduleRaids.LegendaryDivinations = 0;
            this.moduleRaids.LegendaryInsights = 0;
            this.moduleRaids.LIDetail = null;
            this.moduleRaids.Location = new System.Drawing.Point(12, 12);
            this.moduleRaids.MagnetiteShards = 0;
            this.moduleRaids.Name = "moduleRaids";
            this.moduleRaids.Size = new System.Drawing.Size(196, 94);
            this.moduleRaids.TabIndex = 24;
            // 
            // menuStrip
            // 
            this.menuStrip.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.menuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItemClose,
            this.toolStripMenuItemMinimize});
            this.menuStrip.Location = new System.Drawing.Point(0, 0);
            this.menuStrip.Name = "menuStrip";
            this.menuStrip.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.menuStrip.Size = new System.Drawing.Size(960, 24);
            this.menuStrip.TabIndex = 0;
            this.menuStrip.MouseDown += new System.Windows.Forms.MouseEventHandler(this.menuStrip_MouseDown);
            // 
            // toolStripMenuItemClose
            // 
            this.toolStripMenuItemClose.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripMenuItemClose.Image = ((System.Drawing.Image)(resources.GetObject("toolStripMenuItemClose.Image")));
            this.toolStripMenuItemClose.Name = "toolStripMenuItemClose";
            this.toolStripMenuItemClose.Size = new System.Drawing.Size(28, 20);
            this.toolStripMenuItemClose.Text = "X";
            this.toolStripMenuItemClose.Click += new System.EventHandler(this.toolStripMenuItemClose_Click);
            // 
            // toolStripMenuItemMinimize
            // 
            this.toolStripMenuItemMinimize.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripMenuItemMinimize.Image = ((System.Drawing.Image)(resources.GetObject("toolStripMenuItemMinimize.Image")));
            this.toolStripMenuItemMinimize.Name = "toolStripMenuItemMinimize";
            this.toolStripMenuItemMinimize.Size = new System.Drawing.Size(28, 20);
            this.toolStripMenuItemMinimize.Text = "_";
            this.toolStripMenuItemMinimize.Click += new System.EventHandler(this.toolStripMenuItemMinimize_Click);
            // 
            // panelAccount
            // 
            this.panelAccount.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(45)))));
            this.panelAccount.Controls.Add(this.buttonRefresh);
            this.panelAccount.Controls.Add(this.labelAPIError);
            this.panelAccount.Controls.Add(this.linkLabelSettings);
            this.panelAccount.Controls.Add(this.comboBoxAccount);
            this.panelAccount.Controls.Add(this.linkLabelAPIKeys);
            this.panelAccount.Location = new System.Drawing.Point(740, 24);
            this.panelAccount.Name = "panelAccount";
            this.panelAccount.Size = new System.Drawing.Size(220, 80);
            this.panelAccount.TabIndex = 1;
            // 
            // buttonRefresh
            // 
            this.buttonRefresh.BackColor = System.Drawing.Color.Transparent;
            this.buttonRefresh.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.buttonRefresh.FlatAppearance.BorderSize = 0;
            this.buttonRefresh.FlatAppearance.CheckedBackColor = System.Drawing.Color.Transparent;
            this.buttonRefresh.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.buttonRefresh.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.buttonRefresh.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonRefresh.ForeColor = System.Drawing.Color.Gray;
            this.buttonRefresh.Image = ((System.Drawing.Image)(resources.GetObject("buttonRefresh.Image")));
            this.buttonRefresh.Location = new System.Drawing.Point(176, 24);
            this.buttonRefresh.Name = "buttonRefresh";
            this.buttonRefresh.Size = new System.Drawing.Size(32, 32);
            this.buttonRefresh.TabIndex = 22;
            this.buttonRefresh.TabStop = false;
            this.buttonRefresh.UseVisualStyleBackColor = false;
            this.buttonRefresh.Click += new System.EventHandler(this.buttonRefresh_Click);
            // 
            // labelAPIError
            // 
            this.labelAPIError.AutoSize = true;
            this.labelAPIError.Location = new System.Drawing.Point(9, 10);
            this.labelAPIError.Name = "labelAPIError";
            this.labelAPIError.Size = new System.Drawing.Size(72, 13);
            this.labelAPIError.TabIndex = 21;
            this.labelAPIError.Text = "[API ERROR]";
            this.labelAPIError.Visible = false;
            // 
            // linkLabelSettings
            // 
            this.linkLabelSettings.ActiveLinkColor = System.Drawing.Color.OrangeRed;
            this.linkLabelSettings.AutoSize = true;
            this.linkLabelSettings.LinkColor = System.Drawing.Color.Red;
            this.linkLabelSettings.Location = new System.Drawing.Point(163, 62);
            this.linkLabelSettings.Name = "linkLabelSettings";
            this.linkLabelSettings.Size = new System.Drawing.Size(45, 13);
            this.linkLabelSettings.TabIndex = 20;
            this.linkLabelSettings.TabStop = true;
            this.linkLabelSettings.Text = "Settings";
            this.linkLabelSettings.VisitedLinkColor = System.Drawing.Color.OrangeRed;
            this.linkLabelSettings.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabelSettings_LinkClicked);
            // 
            // comboBoxAccount
            // 
            this.comboBoxAccount.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(45)))));
            this.comboBoxAccount.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxAccount.Enabled = false;
            this.comboBoxAccount.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.comboBoxAccount.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.comboBoxAccount.ForeColor = System.Drawing.Color.White;
            this.comboBoxAccount.FormattingEnabled = true;
            this.comboBoxAccount.Location = new System.Drawing.Point(12, 26);
            this.comboBoxAccount.Name = "comboBoxAccount";
            this.comboBoxAccount.Size = new System.Drawing.Size(158, 28);
            this.comboBoxAccount.TabIndex = 18;
            this.comboBoxAccount.Tag = "";
            this.comboBoxAccount.SelectedIndexChanged += new System.EventHandler(this.comboBoxAccount_SelectedIndexChanged);
            // 
            // linkLabelAPIKeys
            // 
            this.linkLabelAPIKeys.ActiveLinkColor = System.Drawing.Color.OrangeRed;
            this.linkLabelAPIKeys.AutoSize = true;
            this.linkLabelAPIKeys.LinkColor = System.Drawing.Color.Red;
            this.linkLabelAPIKeys.Location = new System.Drawing.Point(9, 62);
            this.linkLabelAPIKeys.Name = "linkLabelAPIKeys";
            this.linkLabelAPIKeys.Size = new System.Drawing.Size(50, 13);
            this.linkLabelAPIKeys.TabIndex = 19;
            this.linkLabelAPIKeys.TabStop = true;
            this.linkLabelAPIKeys.Text = "API Keys";
            this.linkLabelAPIKeys.VisitedLinkColor = System.Drawing.Color.OrangeRed;
            this.linkLabelAPIKeys.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabelAPIKeys_LinkClicked);
            // 
            // panelLaunch
            // 
            this.panelLaunch.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(45)))));
            this.panelLaunch.Controls.Add(this.labelLaunchError);
            this.panelLaunch.Controls.Add(this.buttonLaunch);
            this.panelLaunch.Location = new System.Drawing.Point(740, 470);
            this.panelLaunch.Name = "panelLaunch";
            this.panelLaunch.Size = new System.Drawing.Size(220, 70);
            this.panelLaunch.TabIndex = 2;
            // 
            // labelLaunchError
            // 
            this.labelLaunchError.AutoSize = true;
            this.labelLaunchError.Location = new System.Drawing.Point(9, 12);
            this.labelLaunchError.Name = "labelLaunchError";
            this.labelLaunchError.Size = new System.Drawing.Size(99, 13);
            this.labelLaunchError.TabIndex = 9;
            this.labelLaunchError.Text = "[LAUNCH ERROR]";
            this.labelLaunchError.Visible = false;
            // 
            // buttonLaunch
            // 
            this.buttonLaunch.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(185)))), ((int)(((byte)(13)))), ((int)(((byte)(10)))));
            this.buttonLaunch.FlatAppearance.BorderSize = 0;
            this.buttonLaunch.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonLaunch.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.buttonLaunch.ForeColor = System.Drawing.Color.White;
            this.buttonLaunch.Location = new System.Drawing.Point(12, 28);
            this.buttonLaunch.Name = "buttonLaunch";
            this.buttonLaunch.Size = new System.Drawing.Size(196, 30);
            this.buttonLaunch.TabIndex = 10;
            this.buttonLaunch.Text = "Launch";
            this.buttonLaunch.UseVisualStyleBackColor = false;
            this.buttonLaunch.Click += new System.EventHandler(this.buttonLaunch_Click);
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(54)))), ((int)(((byte)(57)))), ((int)(((byte)(63)))));
            this.ClientSize = new System.Drawing.Size(960, 540);
            this.Controls.Add(this.panelLaunch);
            this.Controls.Add(this.panelAccount);
            this.Controls.Add(this.panelNavigation);
            this.Controls.Add(this.panelOverview);
            this.Controls.Add(this.menuStrip);
            this.ForeColor = System.Drawing.Color.White;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip;
            this.Name = "Main";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Guild Lounge";
            this.panelNavigation.ResumeLayout(false);
            this.panelOverview.ResumeLayout(false);
            this.menuStrip.ResumeLayout(false);
            this.menuStrip.PerformLayout();
            this.panelAccount.ResumeLayout(false);
            this.panelAccount.PerformLayout();
            this.panelLaunch.ResumeLayout(false);
            this.panelLaunch.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private Control_MenuStrip menuStrip;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItemMinimize;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItemClose;
        private System.Windows.Forms.Panel panelNavigation;
        private System.Windows.Forms.Panel panelOverview;
        private Control_NavigationButton buttonGuides;
        private Control_NavigationButton buttonRaids;
        private Control_NavigationButton buttonLFG;
        private Control_NavigationButton buttonDashboard;
        private Control_HorizontalLine gL_HorizontalLine1;
        private System.Windows.Forms.Panel panelAccount;
        private System.Windows.Forms.Button buttonRefresh;
        private System.Windows.Forms.Label labelAPIError;
        private System.Windows.Forms.LinkLabel linkLabelSettings;
        private System.Windows.Forms.ComboBox comboBoxAccount;
        private System.Windows.Forms.LinkLabel linkLabelAPIKeys;
        private System.Windows.Forms.Panel panelLaunch;
        private System.Windows.Forms.Label labelLaunchError;
        private Control_HighlightButton buttonLaunch;
        private Module_Raids moduleRaids;
        private Module_Fractals moduleFractals;
        private Module_WvW moduleWvW;
        private Module_PvP modulePvP;
        private Module_TPPickup moduleTPPickup;
        private Module_BaseCurrencies moduleBaseCurrencies;
    }
}

