namespace GuildLounge.TabPages
{
    partial class Dashboard
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.pictureBoxNews = new System.Windows.Forms.PictureBox();
            this.groupBoxTools = new GuildLounge.Controls.GroupBox();
            this.linkLabelDPSLogOverview = new System.Windows.Forms.LinkLabel();
            this.linkLabelWindowedResolution = new System.Windows.Forms.LinkLabel();
            this.linkLabelDailies = new System.Windows.Forms.LinkLabel();
            this.labelTools = new System.Windows.Forms.Label();
            this.groupBoxLinks = new GuildLounge.Controls.GroupBox();
            this.linkLabelGLDiscord = new System.Windows.Forms.LinkLabel();
            this.linkLabelGW2Forums = new System.Windows.Forms.LinkLabel();
            this.linkLabelGW2ReleaseNotes = new System.Windows.Forms.LinkLabel();
            this.linkLabelGW2Wiki = new System.Windows.Forms.LinkLabel();
            this.linkLabelGW2Efficiency = new System.Windows.Forms.LinkLabel();
            this.linkLabelGLReleaseNotes = new System.Windows.Forms.LinkLabel();
            this.labelLinks = new System.Windows.Forms.Label();
            this.buttonNewsNext = new GuildLounge.Controls.Button();
            this.buttonNewsPrevious = new GuildLounge.Controls.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxNews)).BeginInit();
            this.groupBoxTools.SuspendLayout();
            this.groupBoxLinks.SuspendLayout();
            this.SuspendLayout();
            // 
            // pictureBoxNews
            // 
            this.pictureBoxNews.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.pictureBoxNews.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.pictureBoxNews.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pictureBoxNews.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pictureBoxNews.Image = global::GuildLounge.Properties.Resources.news_panel1;
            this.pictureBoxNews.Location = new System.Drawing.Point(98, 12);
            this.pictureBoxNews.Name = "pictureBoxNews";
            this.pictureBoxNews.Size = new System.Drawing.Size(544, 164);
            this.pictureBoxNews.TabIndex = 0;
            this.pictureBoxNews.TabStop = false;
            this.pictureBoxNews.Click += new System.EventHandler(this.pictureBoxNews_Click);
            // 
            // groupBoxTools
            // 
            this.groupBoxTools.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.groupBoxTools.BorderColor = System.Drawing.Color.Gray;
            this.groupBoxTools.BorderSize = 1;
            this.groupBoxTools.Controls.Add(this.linkLabelDPSLogOverview);
            this.groupBoxTools.Controls.Add(this.linkLabelWindowedResolution);
            this.groupBoxTools.Controls.Add(this.linkLabelDailies);
            this.groupBoxTools.Controls.Add(this.labelTools);
            this.groupBoxTools.Location = new System.Drawing.Point(386, 188);
            this.groupBoxTools.Name = "groupBoxTools";
            this.groupBoxTools.Size = new System.Drawing.Size(256, 145);
            this.groupBoxTools.TabIndex = 27;
            this.groupBoxTools.TabStop = false;
            this.groupBoxTools.Text = "gL_GroupBox1";
            // 
            // linkLabelDPSLogOverview
            // 
            this.linkLabelDPSLogOverview.ActiveLinkColor = System.Drawing.Color.OrangeRed;
            this.linkLabelDPSLogOverview.AutoSize = true;
            this.linkLabelDPSLogOverview.LinkBehavior = System.Windows.Forms.LinkBehavior.NeverUnderline;
            this.linkLabelDPSLogOverview.LinkColor = System.Drawing.Color.Red;
            this.linkLabelDPSLogOverview.Location = new System.Drawing.Point(7, 58);
            this.linkLabelDPSLogOverview.Name = "linkLabelDPSLogOverview";
            this.linkLabelDPSLogOverview.Size = new System.Drawing.Size(98, 13);
            this.linkLabelDPSLogOverview.TabIndex = 22;
            this.linkLabelDPSLogOverview.TabStop = true;
            this.linkLabelDPSLogOverview.Text = "DPS Log Overview";
            this.linkLabelDPSLogOverview.VisitedLinkColor = System.Drawing.Color.OrangeRed;
            this.linkLabelDPSLogOverview.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabelDPSLogOverview_LinkClicked);
            // 
            // linkLabelWindowedResolution
            // 
            this.linkLabelWindowedResolution.ActiveLinkColor = System.Drawing.Color.OrangeRed;
            this.linkLabelWindowedResolution.AutoSize = true;
            this.linkLabelWindowedResolution.LinkBehavior = System.Windows.Forms.LinkBehavior.NeverUnderline;
            this.linkLabelWindowedResolution.LinkColor = System.Drawing.Color.Red;
            this.linkLabelWindowedResolution.Location = new System.Drawing.Point(7, 42);
            this.linkLabelWindowedResolution.Name = "linkLabelWindowedResolution";
            this.linkLabelWindowedResolution.Size = new System.Drawing.Size(111, 13);
            this.linkLabelWindowedResolution.TabIndex = 21;
            this.linkLabelWindowedResolution.TabStop = true;
            this.linkLabelWindowedResolution.Text = "Windowed Resolution";
            this.linkLabelWindowedResolution.VisitedLinkColor = System.Drawing.Color.OrangeRed;
            this.linkLabelWindowedResolution.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabelWindowedResolution_LinkClicked);
            // 
            // linkLabelDailies
            // 
            this.linkLabelDailies.ActiveLinkColor = System.Drawing.Color.OrangeRed;
            this.linkLabelDailies.AutoSize = true;
            this.linkLabelDailies.LinkBehavior = System.Windows.Forms.LinkBehavior.NeverUnderline;
            this.linkLabelDailies.LinkColor = System.Drawing.Color.Red;
            this.linkLabelDailies.Location = new System.Drawing.Point(7, 26);
            this.linkLabelDailies.Name = "linkLabelDailies";
            this.linkLabelDailies.Size = new System.Drawing.Size(38, 13);
            this.linkLabelDailies.TabIndex = 20;
            this.linkLabelDailies.TabStop = true;
            this.linkLabelDailies.Text = "Dailies";
            this.linkLabelDailies.VisitedLinkColor = System.Drawing.Color.OrangeRed;
            this.linkLabelDailies.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabelDailies_LinkClicked);
            // 
            // labelTools
            // 
            this.labelTools.AutoSize = true;
            this.labelTools.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.labelTools.Location = new System.Drawing.Point(6, 6);
            this.labelTools.Name = "labelTools";
            this.labelTools.Size = new System.Drawing.Size(47, 20);
            this.labelTools.TabIndex = 0;
            this.labelTools.Text = "Tools";
            // 
            // groupBoxLinks
            // 
            this.groupBoxLinks.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.groupBoxLinks.BorderColor = System.Drawing.Color.Gray;
            this.groupBoxLinks.BorderSize = 1;
            this.groupBoxLinks.Controls.Add(this.linkLabelGLDiscord);
            this.groupBoxLinks.Controls.Add(this.linkLabelGW2Forums);
            this.groupBoxLinks.Controls.Add(this.linkLabelGW2ReleaseNotes);
            this.groupBoxLinks.Controls.Add(this.linkLabelGW2Wiki);
            this.groupBoxLinks.Controls.Add(this.linkLabelGW2Efficiency);
            this.groupBoxLinks.Controls.Add(this.linkLabelGLReleaseNotes);
            this.groupBoxLinks.Controls.Add(this.labelLinks);
            this.groupBoxLinks.Location = new System.Drawing.Point(98, 188);
            this.groupBoxLinks.Name = "groupBoxLinks";
            this.groupBoxLinks.Size = new System.Drawing.Size(256, 145);
            this.groupBoxLinks.TabIndex = 16;
            this.groupBoxLinks.TabStop = false;
            this.groupBoxLinks.Text = "gL_GroupBox1";
            // 
            // linkLabelGLDiscord
            // 
            this.linkLabelGLDiscord.ActiveLinkColor = System.Drawing.Color.OrangeRed;
            this.linkLabelGLDiscord.AutoSize = true;
            this.linkLabelGLDiscord.LinkBehavior = System.Windows.Forms.LinkBehavior.NeverUnderline;
            this.linkLabelGLDiscord.LinkColor = System.Drawing.Color.Red;
            this.linkLabelGLDiscord.Location = new System.Drawing.Point(7, 42);
            this.linkLabelGLDiscord.Name = "linkLabelGLDiscord";
            this.linkLabelGLDiscord.Size = new System.Drawing.Size(109, 13);
            this.linkLabelGLDiscord.TabIndex = 26;
            this.linkLabelGLDiscord.TabStop = true;
            this.linkLabelGLDiscord.Text = "Guild Lounge Discord";
            this.linkLabelGLDiscord.VisitedLinkColor = System.Drawing.Color.OrangeRed;
            this.linkLabelGLDiscord.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabelGLDiscord_LinkClicked);
            // 
            // linkLabelGW2Forums
            // 
            this.linkLabelGW2Forums.ActiveLinkColor = System.Drawing.Color.OrangeRed;
            this.linkLabelGW2Forums.AutoSize = true;
            this.linkLabelGW2Forums.LinkBehavior = System.Windows.Forms.LinkBehavior.NeverUnderline;
            this.linkLabelGW2Forums.LinkColor = System.Drawing.Color.Red;
            this.linkLabelGW2Forums.Location = new System.Drawing.Point(7, 106);
            this.linkLabelGW2Forums.Name = "linkLabelGW2Forums";
            this.linkLabelGW2Forums.Size = new System.Drawing.Size(104, 13);
            this.linkLabelGW2Forums.TabIndex = 24;
            this.linkLabelGW2Forums.TabStop = true;
            this.linkLabelGW2Forums.Text = "Official GW2 Forums";
            this.linkLabelGW2Forums.VisitedLinkColor = System.Drawing.Color.OrangeRed;
            this.linkLabelGW2Forums.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabelGW2Forums_LinkClicked);
            // 
            // linkLabelGW2ReleaseNotes
            // 
            this.linkLabelGW2ReleaseNotes.ActiveLinkColor = System.Drawing.Color.OrangeRed;
            this.linkLabelGW2ReleaseNotes.AutoSize = true;
            this.linkLabelGW2ReleaseNotes.LinkBehavior = System.Windows.Forms.LinkBehavior.NeverUnderline;
            this.linkLabelGW2ReleaseNotes.LinkColor = System.Drawing.Color.Red;
            this.linkLabelGW2ReleaseNotes.Location = new System.Drawing.Point(7, 90);
            this.linkLabelGW2ReleaseNotes.Name = "linkLabelGW2ReleaseNotes";
            this.linkLabelGW2ReleaseNotes.Size = new System.Drawing.Size(140, 13);
            this.linkLabelGW2ReleaseNotes.TabIndex = 23;
            this.linkLabelGW2ReleaseNotes.TabStop = true;
            this.linkLabelGW2ReleaseNotes.Text = "Official GW2 Release Notes";
            this.linkLabelGW2ReleaseNotes.VisitedLinkColor = System.Drawing.Color.OrangeRed;
            this.linkLabelGW2ReleaseNotes.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabelGW2ReleaseNotes_LinkClicked);
            // 
            // linkLabelGW2Wiki
            // 
            this.linkLabelGW2Wiki.ActiveLinkColor = System.Drawing.Color.OrangeRed;
            this.linkLabelGW2Wiki.AutoSize = true;
            this.linkLabelGW2Wiki.LinkBehavior = System.Windows.Forms.LinkBehavior.NeverUnderline;
            this.linkLabelGW2Wiki.LinkColor = System.Drawing.Color.Red;
            this.linkLabelGW2Wiki.Location = new System.Drawing.Point(7, 74);
            this.linkLabelGW2Wiki.Name = "linkLabelGW2Wiki";
            this.linkLabelGW2Wiki.Size = new System.Drawing.Size(91, 13);
            this.linkLabelGW2Wiki.TabIndex = 22;
            this.linkLabelGW2Wiki.TabStop = true;
            this.linkLabelGW2Wiki.Text = "Official GW2 Wiki";
            this.linkLabelGW2Wiki.VisitedLinkColor = System.Drawing.Color.OrangeRed;
            this.linkLabelGW2Wiki.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabelGW2Wiki_LinkClicked);
            // 
            // linkLabelGW2Efficiency
            // 
            this.linkLabelGW2Efficiency.ActiveLinkColor = System.Drawing.Color.OrangeRed;
            this.linkLabelGW2Efficiency.AutoSize = true;
            this.linkLabelGW2Efficiency.LinkBehavior = System.Windows.Forms.LinkBehavior.NeverUnderline;
            this.linkLabelGW2Efficiency.LinkColor = System.Drawing.Color.Red;
            this.linkLabelGW2Efficiency.Location = new System.Drawing.Point(7, 58);
            this.linkLabelGW2Efficiency.Name = "linkLabelGW2Efficiency";
            this.linkLabelGW2Efficiency.Size = new System.Drawing.Size(81, 13);
            this.linkLabelGW2Efficiency.TabIndex = 21;
            this.linkLabelGW2Efficiency.TabStop = true;
            this.linkLabelGW2Efficiency.Text = "GW2 Efficiency";
            this.linkLabelGW2Efficiency.VisitedLinkColor = System.Drawing.Color.OrangeRed;
            this.linkLabelGW2Efficiency.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabelGW2Efficiency_LinkClicked);
            // 
            // linkLabelGLReleaseNotes
            // 
            this.linkLabelGLReleaseNotes.ActiveLinkColor = System.Drawing.Color.OrangeRed;
            this.linkLabelGLReleaseNotes.AutoSize = true;
            this.linkLabelGLReleaseNotes.LinkBehavior = System.Windows.Forms.LinkBehavior.NeverUnderline;
            this.linkLabelGLReleaseNotes.LinkColor = System.Drawing.Color.Red;
            this.linkLabelGLReleaseNotes.Location = new System.Drawing.Point(7, 26);
            this.linkLabelGLReleaseNotes.Name = "linkLabelGLReleaseNotes";
            this.linkLabelGLReleaseNotes.Size = new System.Drawing.Size(143, 13);
            this.linkLabelGLReleaseNotes.TabIndex = 20;
            this.linkLabelGLReleaseNotes.TabStop = true;
            this.linkLabelGLReleaseNotes.Text = "Guild Lounge Release Notes";
            this.linkLabelGLReleaseNotes.VisitedLinkColor = System.Drawing.Color.OrangeRed;
            this.linkLabelGLReleaseNotes.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabelGLReleaseNotes_LinkClicked);
            // 
            // labelLinks
            // 
            this.labelLinks.AutoSize = true;
            this.labelLinks.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.labelLinks.Location = new System.Drawing.Point(6, 6);
            this.labelLinks.Name = "labelLinks";
            this.labelLinks.Size = new System.Drawing.Size(46, 20);
            this.labelLinks.TabIndex = 0;
            this.labelLinks.Text = "Links";
            // 
            // buttonNewsNext
            // 
            this.buttonNewsNext.BackColor = System.Drawing.Color.Transparent;
            this.buttonNewsNext.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.buttonNewsNext.FlatAppearance.BorderSize = 0;
            this.buttonNewsNext.FlatAppearance.CheckedBackColor = System.Drawing.Color.Transparent;
            this.buttonNewsNext.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.buttonNewsNext.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.buttonNewsNext.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonNewsNext.ForeColor = System.Drawing.Color.Gray;
            this.buttonNewsNext.Image = global::GuildLounge.Properties.Resources.ui_arrow_rt;
            this.buttonNewsNext.Location = new System.Drawing.Point(648, 12);
            this.buttonNewsNext.Name = "buttonNewsNext";
            this.buttonNewsNext.Size = new System.Drawing.Size(80, 164);
            this.buttonNewsNext.TabIndex = 15;
            this.buttonNewsNext.UseVisualStyleBackColor = false;
            this.buttonNewsNext.Click += new System.EventHandler(this.buttonNewsNext_Click);
            // 
            // buttonNewsPrevious
            // 
            this.buttonNewsPrevious.BackColor = System.Drawing.Color.Transparent;
            this.buttonNewsPrevious.FlatAppearance.BorderSize = 0;
            this.buttonNewsPrevious.FlatAppearance.CheckedBackColor = System.Drawing.Color.Transparent;
            this.buttonNewsPrevious.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.buttonNewsPrevious.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.buttonNewsPrevious.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonNewsPrevious.ForeColor = System.Drawing.Color.Gray;
            this.buttonNewsPrevious.Image = global::GuildLounge.Properties.Resources.ui_arrow_lt;
            this.buttonNewsPrevious.Location = new System.Drawing.Point(12, 12);
            this.buttonNewsPrevious.Name = "buttonNewsPrevious";
            this.buttonNewsPrevious.Size = new System.Drawing.Size(80, 164);
            this.buttonNewsPrevious.TabIndex = 14;
            this.buttonNewsPrevious.UseVisualStyleBackColor = false;
            this.buttonNewsPrevious.Click += new System.EventHandler(this.buttonNewsPrevious_Click);
            // 
            // Dashboard
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(55)))), ((int)(((byte)(55)))), ((int)(((byte)(55)))));
            this.Controls.Add(this.groupBoxTools);
            this.Controls.Add(this.groupBoxLinks);
            this.Controls.Add(this.buttonNewsNext);
            this.Controls.Add(this.buttonNewsPrevious);
            this.Controls.Add(this.pictureBoxNews);
            this.ForeColor = System.Drawing.Color.White;
            this.Name = "Dashboard";
            this.Size = new System.Drawing.Size(740, 436);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxNews)).EndInit();
            this.groupBoxTools.ResumeLayout(false);
            this.groupBoxTools.PerformLayout();
            this.groupBoxLinks.ResumeLayout(false);
            this.groupBoxLinks.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBoxNews;
        private GuildLounge.Controls.Button buttonNewsPrevious;
        private GuildLounge.Controls.Button buttonNewsNext;
        private GuildLounge.Controls.GroupBox groupBoxLinks;
        private System.Windows.Forms.Label labelLinks;
        private System.Windows.Forms.LinkLabel linkLabelGLReleaseNotes;
        private System.Windows.Forms.LinkLabel linkLabelGLDiscord;
        private System.Windows.Forms.LinkLabel linkLabelGW2Forums;
        private System.Windows.Forms.LinkLabel linkLabelGW2ReleaseNotes;
        private System.Windows.Forms.LinkLabel linkLabelGW2Wiki;
        private System.Windows.Forms.LinkLabel linkLabelGW2Efficiency;
        private GuildLounge.Controls.GroupBox groupBoxTools;
        private System.Windows.Forms.LinkLabel linkLabelDailies;
        private System.Windows.Forms.Label labelTools;
        private System.Windows.Forms.LinkLabel linkLabelWindowedResolution;
        private System.Windows.Forms.LinkLabel linkLabelDPSLogOverview;
    }
}
