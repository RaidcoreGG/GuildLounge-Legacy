namespace GuildLounge.Controls
{
    partial class ApiKeyInfo
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
            this.groupBoxContainer = new GuildLounge.Controls.GroupBox();
            this.labelAdditional = new System.Windows.Forms.Label();
            this.groupBoxAdditional = new GuildLounge.Controls.GroupBox();
            this.panelGuilds = new GuildLounge.Controls.PermissionPanel();
            this.labelGuilds = new System.Windows.Forms.Label();
            this.panelProgression = new GuildLounge.Controls.PermissionPanel();
            this.labelProgression = new System.Windows.Forms.Label();
            this.panelBuilds = new GuildLounge.Controls.PermissionPanel();
            this.labelBuilds = new System.Windows.Forms.Label();
            this.panelPvP = new GuildLounge.Controls.PermissionPanel();
            this.labelPvP = new System.Windows.Forms.Label();
            this.panelUnlocks = new GuildLounge.Controls.PermissionPanel();
            this.labelUnlocks = new System.Windows.Forms.Label();
            this.groupBoxRequired = new GuildLounge.Controls.GroupBox();
            this.panelWallet = new GuildLounge.Controls.PermissionPanel();
            this.labelWallet = new System.Windows.Forms.Label();
            this.panelTradingPost = new GuildLounge.Controls.PermissionPanel();
            this.labelTradingPost = new System.Windows.Forms.Label();
            this.panelCharacters = new GuildLounge.Controls.PermissionPanel();
            this.labelCharacters = new System.Windows.Forms.Label();
            this.panelInventories = new GuildLounge.Controls.PermissionPanel();
            this.labelInventories = new System.Windows.Forms.Label();
            this.panelAccount = new GuildLounge.Controls.PermissionPanel();
            this.labelAccount = new System.Windows.Forms.Label();
            this.labelRequired = new System.Windows.Forms.Label();
            this.groupBoxContainer.SuspendLayout();
            this.groupBoxAdditional.SuspendLayout();
            this.groupBoxRequired.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBoxContainer
            // 
            this.groupBoxContainer.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.groupBoxContainer.BorderColor = System.Drawing.Color.Gray;
            this.groupBoxContainer.BorderSize = 1;
            this.groupBoxContainer.Controls.Add(this.labelAdditional);
            this.groupBoxContainer.Controls.Add(this.groupBoxAdditional);
            this.groupBoxContainer.Controls.Add(this.groupBoxRequired);
            this.groupBoxContainer.Controls.Add(this.labelRequired);
            this.groupBoxContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBoxContainer.ForeColor = System.Drawing.Color.White;
            this.groupBoxContainer.Location = new System.Drawing.Point(0, 0);
            this.groupBoxContainer.Name = "groupBoxContainer";
            this.groupBoxContainer.Size = new System.Drawing.Size(340, 156);
            this.groupBoxContainer.TabIndex = 0;
            this.groupBoxContainer.TabStop = false;
            this.groupBoxContainer.Text = "groupBox1";
            // 
            // labelAdditional
            // 
            this.labelAdditional.AutoSize = true;
            this.labelAdditional.ForeColor = System.Drawing.Color.White;
            this.labelAdditional.Location = new System.Drawing.Point(176, 12);
            this.labelAdditional.Name = "labelAdditional";
            this.labelAdditional.Size = new System.Drawing.Size(53, 13);
            this.labelAdditional.TabIndex = 9;
            this.labelAdditional.Text = "Additional";
            // 
            // groupBoxAdditional
            // 
            this.groupBoxAdditional.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.groupBoxAdditional.BorderColor = System.Drawing.Color.Gray;
            this.groupBoxAdditional.BorderSize = 1;
            this.groupBoxAdditional.Controls.Add(this.panelGuilds);
            this.groupBoxAdditional.Controls.Add(this.labelGuilds);
            this.groupBoxAdditional.Controls.Add(this.panelProgression);
            this.groupBoxAdditional.Controls.Add(this.labelProgression);
            this.groupBoxAdditional.Controls.Add(this.panelBuilds);
            this.groupBoxAdditional.Controls.Add(this.labelBuilds);
            this.groupBoxAdditional.Controls.Add(this.panelPvP);
            this.groupBoxAdditional.Controls.Add(this.labelPvP);
            this.groupBoxAdditional.Controls.Add(this.panelUnlocks);
            this.groupBoxAdditional.Controls.Add(this.labelUnlocks);
            this.groupBoxAdditional.Location = new System.Drawing.Point(176, 28);
            this.groupBoxAdditional.Name = "groupBoxAdditional";
            this.groupBoxAdditional.Size = new System.Drawing.Size(152, 116);
            this.groupBoxAdditional.TabIndex = 8;
            this.groupBoxAdditional.TabStop = false;
            this.groupBoxAdditional.Text = "groupBox2";
            // 
            // panelGuilds
            // 
            this.panelGuilds.Allowed = false;
            this.panelGuilds.BackColor = System.Drawing.Color.Red;
            this.panelGuilds.Location = new System.Drawing.Point(82, 94);
            this.panelGuilds.Name = "panelGuilds";
            this.panelGuilds.Size = new System.Drawing.Size(64, 16);
            this.panelGuilds.TabIndex = 7;
            // 
            // labelGuilds
            // 
            this.labelGuilds.AutoSize = true;
            this.labelGuilds.ForeColor = System.Drawing.Color.White;
            this.labelGuilds.Location = new System.Drawing.Point(37, 94);
            this.labelGuilds.Name = "labelGuilds";
            this.labelGuilds.Size = new System.Drawing.Size(39, 13);
            this.labelGuilds.TabIndex = 6;
            this.labelGuilds.Text = "Guilds:";
            // 
            // panelProgression
            // 
            this.panelProgression.Allowed = false;
            this.panelProgression.BackColor = System.Drawing.Color.Red;
            this.panelProgression.Location = new System.Drawing.Point(82, 72);
            this.panelProgression.Name = "panelProgression";
            this.panelProgression.Size = new System.Drawing.Size(64, 16);
            this.panelProgression.TabIndex = 7;
            // 
            // labelProgression
            // 
            this.labelProgression.AutoSize = true;
            this.labelProgression.ForeColor = System.Drawing.Color.White;
            this.labelProgression.Location = new System.Drawing.Point(11, 72);
            this.labelProgression.Name = "labelProgression";
            this.labelProgression.Size = new System.Drawing.Size(65, 13);
            this.labelProgression.TabIndex = 6;
            this.labelProgression.Text = "Progression:";
            // 
            // panelBuilds
            // 
            this.panelBuilds.Allowed = false;
            this.panelBuilds.BackColor = System.Drawing.Color.Red;
            this.panelBuilds.Location = new System.Drawing.Point(82, 50);
            this.panelBuilds.Name = "panelBuilds";
            this.panelBuilds.Size = new System.Drawing.Size(64, 16);
            this.panelBuilds.TabIndex = 7;
            // 
            // labelBuilds
            // 
            this.labelBuilds.AutoSize = true;
            this.labelBuilds.ForeColor = System.Drawing.Color.White;
            this.labelBuilds.Location = new System.Drawing.Point(38, 50);
            this.labelBuilds.Name = "labelBuilds";
            this.labelBuilds.Size = new System.Drawing.Size(38, 13);
            this.labelBuilds.TabIndex = 6;
            this.labelBuilds.Text = "Builds:";
            // 
            // panelPvP
            // 
            this.panelPvP.Allowed = false;
            this.panelPvP.BackColor = System.Drawing.Color.Red;
            this.panelPvP.Location = new System.Drawing.Point(82, 28);
            this.panelPvP.Name = "panelPvP";
            this.panelPvP.Size = new System.Drawing.Size(64, 16);
            this.panelPvP.TabIndex = 5;
            // 
            // labelPvP
            // 
            this.labelPvP.AutoSize = true;
            this.labelPvP.ForeColor = System.Drawing.Color.White;
            this.labelPvP.Location = new System.Drawing.Point(46, 28);
            this.labelPvP.Name = "labelPvP";
            this.labelPvP.Size = new System.Drawing.Size(30, 13);
            this.labelPvP.TabIndex = 4;
            this.labelPvP.Text = "PvP:";
            // 
            // panelUnlocks
            // 
            this.panelUnlocks.Allowed = false;
            this.panelUnlocks.BackColor = System.Drawing.Color.Red;
            this.panelUnlocks.Location = new System.Drawing.Point(82, 6);
            this.panelUnlocks.Name = "panelUnlocks";
            this.panelUnlocks.Size = new System.Drawing.Size(64, 16);
            this.panelUnlocks.TabIndex = 3;
            // 
            // labelUnlocks
            // 
            this.labelUnlocks.AutoSize = true;
            this.labelUnlocks.ForeColor = System.Drawing.Color.White;
            this.labelUnlocks.Location = new System.Drawing.Point(27, 6);
            this.labelUnlocks.Name = "labelUnlocks";
            this.labelUnlocks.Size = new System.Drawing.Size(49, 13);
            this.labelUnlocks.TabIndex = 2;
            this.labelUnlocks.Text = "Unlocks:";
            // 
            // groupBoxRequired
            // 
            this.groupBoxRequired.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.groupBoxRequired.BorderColor = System.Drawing.Color.Gold;
            this.groupBoxRequired.BorderSize = 1;
            this.groupBoxRequired.Controls.Add(this.panelWallet);
            this.groupBoxRequired.Controls.Add(this.labelWallet);
            this.groupBoxRequired.Controls.Add(this.panelTradingPost);
            this.groupBoxRequired.Controls.Add(this.labelTradingPost);
            this.groupBoxRequired.Controls.Add(this.panelCharacters);
            this.groupBoxRequired.Controls.Add(this.labelCharacters);
            this.groupBoxRequired.Controls.Add(this.panelInventories);
            this.groupBoxRequired.Controls.Add(this.labelInventories);
            this.groupBoxRequired.Controls.Add(this.panelAccount);
            this.groupBoxRequired.Controls.Add(this.labelAccount);
            this.groupBoxRequired.Location = new System.Drawing.Point(12, 28);
            this.groupBoxRequired.Name = "groupBoxRequired";
            this.groupBoxRequired.Size = new System.Drawing.Size(152, 116);
            this.groupBoxRequired.TabIndex = 1;
            this.groupBoxRequired.TabStop = false;
            this.groupBoxRequired.Text = "groupBox2";
            // 
            // panelWallet
            // 
            this.panelWallet.Allowed = false;
            this.panelWallet.BackColor = System.Drawing.Color.Red;
            this.panelWallet.Location = new System.Drawing.Point(82, 94);
            this.panelWallet.Name = "panelWallet";
            this.panelWallet.Size = new System.Drawing.Size(64, 16);
            this.panelWallet.TabIndex = 7;
            // 
            // labelWallet
            // 
            this.labelWallet.AutoSize = true;
            this.labelWallet.ForeColor = System.Drawing.Color.White;
            this.labelWallet.Location = new System.Drawing.Point(36, 94);
            this.labelWallet.Name = "labelWallet";
            this.labelWallet.Size = new System.Drawing.Size(40, 13);
            this.labelWallet.TabIndex = 6;
            this.labelWallet.Text = "Wallet:";
            // 
            // panelTradingPost
            // 
            this.panelTradingPost.Allowed = false;
            this.panelTradingPost.BackColor = System.Drawing.Color.Red;
            this.panelTradingPost.Location = new System.Drawing.Point(82, 72);
            this.panelTradingPost.Name = "panelTradingPost";
            this.panelTradingPost.Size = new System.Drawing.Size(64, 16);
            this.panelTradingPost.TabIndex = 7;
            // 
            // labelTradingPost
            // 
            this.labelTradingPost.AutoSize = true;
            this.labelTradingPost.ForeColor = System.Drawing.Color.White;
            this.labelTradingPost.Location = new System.Drawing.Point(6, 72);
            this.labelTradingPost.Name = "labelTradingPost";
            this.labelTradingPost.Size = new System.Drawing.Size(70, 13);
            this.labelTradingPost.TabIndex = 6;
            this.labelTradingPost.Text = "Trading Post:";
            // 
            // panelCharacters
            // 
            this.panelCharacters.Allowed = false;
            this.panelCharacters.BackColor = System.Drawing.Color.Red;
            this.panelCharacters.Location = new System.Drawing.Point(82, 50);
            this.panelCharacters.Name = "panelCharacters";
            this.panelCharacters.Size = new System.Drawing.Size(64, 16);
            this.panelCharacters.TabIndex = 7;
            // 
            // labelCharacters
            // 
            this.labelCharacters.AutoSize = true;
            this.labelCharacters.ForeColor = System.Drawing.Color.White;
            this.labelCharacters.Location = new System.Drawing.Point(15, 50);
            this.labelCharacters.Name = "labelCharacters";
            this.labelCharacters.Size = new System.Drawing.Size(61, 13);
            this.labelCharacters.TabIndex = 6;
            this.labelCharacters.Text = "Characters:";
            // 
            // panelInventories
            // 
            this.panelInventories.Allowed = false;
            this.panelInventories.BackColor = System.Drawing.Color.Red;
            this.panelInventories.Location = new System.Drawing.Point(82, 28);
            this.panelInventories.Name = "panelInventories";
            this.panelInventories.Size = new System.Drawing.Size(64, 16);
            this.panelInventories.TabIndex = 5;
            // 
            // labelInventories
            // 
            this.labelInventories.AutoSize = true;
            this.labelInventories.ForeColor = System.Drawing.Color.White;
            this.labelInventories.Location = new System.Drawing.Point(14, 28);
            this.labelInventories.Name = "labelInventories";
            this.labelInventories.Size = new System.Drawing.Size(62, 13);
            this.labelInventories.TabIndex = 4;
            this.labelInventories.Text = "Inventories:";
            // 
            // panelAccount
            // 
            this.panelAccount.Allowed = false;
            this.panelAccount.BackColor = System.Drawing.Color.Red;
            this.panelAccount.Location = new System.Drawing.Point(82, 6);
            this.panelAccount.Name = "panelAccount";
            this.panelAccount.Size = new System.Drawing.Size(64, 16);
            this.panelAccount.TabIndex = 3;
            // 
            // labelAccount
            // 
            this.labelAccount.AutoSize = true;
            this.labelAccount.ForeColor = System.Drawing.Color.White;
            this.labelAccount.Location = new System.Drawing.Point(26, 6);
            this.labelAccount.Name = "labelAccount";
            this.labelAccount.Size = new System.Drawing.Size(50, 13);
            this.labelAccount.TabIndex = 2;
            this.labelAccount.Text = "Account:";
            // 
            // labelRequired
            // 
            this.labelRequired.AutoSize = true;
            this.labelRequired.ForeColor = System.Drawing.Color.White;
            this.labelRequired.Location = new System.Drawing.Point(12, 12);
            this.labelRequired.Name = "labelRequired";
            this.labelRequired.Size = new System.Drawing.Size(50, 13);
            this.labelRequired.TabIndex = 0;
            this.labelRequired.Text = "Required";
            // 
            // ApiKeyInfo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(55)))), ((int)(((byte)(55)))), ((int)(((byte)(55)))));
            this.Controls.Add(this.groupBoxContainer);
            this.ForeColor = System.Drawing.Color.White;
            this.Name = "ApiKeyInfo";
            this.Size = new System.Drawing.Size(340, 156);
            this.groupBoxContainer.ResumeLayout(false);
            this.groupBoxContainer.PerformLayout();
            this.groupBoxAdditional.ResumeLayout(false);
            this.groupBoxAdditional.PerformLayout();
            this.groupBoxRequired.ResumeLayout(false);
            this.groupBoxRequired.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private GroupBox groupBoxContainer;
        private System.Windows.Forms.Label labelAdditional;
        private GroupBox groupBoxAdditional;
        private GuildLounge.Controls.PermissionPanel panelGuilds;
        private System.Windows.Forms.Label labelGuilds;
        private GuildLounge.Controls.PermissionPanel panelProgression;
        private System.Windows.Forms.Label labelProgression;
        private GuildLounge.Controls.PermissionPanel panelBuilds;
        private System.Windows.Forms.Label labelBuilds;
        private GuildLounge.Controls.PermissionPanel panelPvP;
        private System.Windows.Forms.Label labelPvP;
        private GuildLounge.Controls.PermissionPanel panelUnlocks;
        private System.Windows.Forms.Label labelUnlocks;
        private GroupBox groupBoxRequired;
        private GuildLounge.Controls.PermissionPanel panelWallet;
        private System.Windows.Forms.Label labelWallet;
        private GuildLounge.Controls.PermissionPanel panelTradingPost;
        private System.Windows.Forms.Label labelTradingPost;
        private GuildLounge.Controls.PermissionPanel panelCharacters;
        private System.Windows.Forms.Label labelCharacters;
        private GuildLounge.Controls.PermissionPanel panelInventories;
        private System.Windows.Forms.Label labelInventories;
        private GuildLounge.Controls.PermissionPanel panelAccount;
        private System.Windows.Forms.Label labelAccount;
        private System.Windows.Forms.Label labelRequired;
    }
}
