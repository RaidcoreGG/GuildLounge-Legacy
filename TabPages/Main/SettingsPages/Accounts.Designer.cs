namespace GuildLounge.TabPages.SettingsPages
{
    partial class Accounts
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
            this.groupBox3 = new GuildLounge.Controls.GroupBox();
            this.labelLinkingError = new System.Windows.Forms.Label();
            this.linkLabelQuickSwitchingHelp = new System.Windows.Forms.LinkLabel();
            this.buttonLinkCurrentDAT = new GuildLounge.Controls.HighlightButton();
            this.buttonUnlinkDAT = new GuildLounge.Controls.HighlightButton();
            this.labelDatFile = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.groupBox2 = new GuildLounge.Controls.GroupBox();
            this.listBoxAccounts = new System.Windows.Forms.ListBox();
            this.label6 = new System.Windows.Forms.Label();
            this.buttonEditAccount = new GuildLounge.Controls.HighlightButton();
            this.buttonRemoveAccount = new GuildLounge.Controls.HighlightButton();
            this.apiKeyInfo = new GuildLounge.Controls.ApiKeyInfo();
            this.groupBox1 = new GuildLounge.Controls.GroupBox();
            this.labelError = new System.Windows.Forms.Label();
            this.buttonAddAccount = new GuildLounge.Controls.HighlightButton();
            this.label1 = new System.Windows.Forms.Label();
            this.textBoxAPIKey = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.textBoxName = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.groupBox3.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox3
            // 
            this.groupBox3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.groupBox3.BorderColor = System.Drawing.Color.Gray;
            this.groupBox3.BorderSize = 1;
            this.groupBox3.Controls.Add(this.labelLinkingError);
            this.groupBox3.Controls.Add(this.linkLabelQuickSwitchingHelp);
            this.groupBox3.Controls.Add(this.buttonLinkCurrentDAT);
            this.groupBox3.Controls.Add(this.buttonUnlinkDAT);
            this.groupBox3.Controls.Add(this.labelDatFile);
            this.groupBox3.Controls.Add(this.label4);
            this.groupBox3.Controls.Add(this.label5);
            this.groupBox3.Location = new System.Drawing.Point(12, 368);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(546, 56);
            this.groupBox3.TabIndex = 2;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "groupBoxAccountDAT";
            // 
            // labelLinkingError
            // 
            this.labelLinkingError.AutoSize = true;
            this.labelLinkingError.Location = new System.Drawing.Point(331, 6);
            this.labelLinkingError.Name = "labelLinkingError";
            this.labelLinkingError.Size = new System.Drawing.Size(52, 13);
            this.labelLinkingError.TabIndex = 0;
            this.labelLinkingError.Text = "[ERROR]";
            this.labelLinkingError.Visible = false;
            // 
            // linkLabelQuickSwitchingHelp
            // 
            this.linkLabelQuickSwitchingHelp.ActiveLinkColor = System.Drawing.Color.OrangeRed;
            this.linkLabelQuickSwitchingHelp.AutoSize = true;
            this.linkLabelQuickSwitchingHelp.LinkColor = System.Drawing.Color.Red;
            this.linkLabelQuickSwitchingHelp.Location = new System.Drawing.Point(142, 6);
            this.linkLabelQuickSwitchingHelp.Name = "linkLabelQuickSwitchingHelp";
            this.linkLabelQuickSwitchingHelp.Size = new System.Drawing.Size(47, 13);
            this.linkLabelQuickSwitchingHelp.TabIndex = 1;
            this.linkLabelQuickSwitchingHelp.TabStop = true;
            this.linkLabelQuickSwitchingHelp.Text = "How to?";
            this.linkLabelQuickSwitchingHelp.VisitedLinkColor = System.Drawing.Color.OrangeRed;
            this.linkLabelQuickSwitchingHelp.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabelQuickSwitchingHelp_LinkClicked);
            // 
            // buttonLinkCurrentDAT
            // 
            this.buttonLinkCurrentDAT.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(185)))), ((int)(((byte)(13)))), ((int)(((byte)(10)))));
            this.buttonLinkCurrentDAT.FlatAppearance.BorderSize = 0;
            this.buttonLinkCurrentDAT.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonLinkCurrentDAT.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.buttonLinkCurrentDAT.ForeColor = System.Drawing.Color.White;
            this.buttonLinkCurrentDAT.Location = new System.Drawing.Point(334, 21);
            this.buttonLinkCurrentDAT.Name = "buttonLinkCurrentDAT";
            this.buttonLinkCurrentDAT.Size = new System.Drawing.Size(100, 20);
            this.buttonLinkCurrentDAT.TabIndex = 2;
            this.buttonLinkCurrentDAT.Text = "Link Current";
            this.buttonLinkCurrentDAT.UseVisualStyleBackColor = false;
            this.buttonLinkCurrentDAT.Click += new System.EventHandler(this.buttonLinkCurrentDAT_Click);
            // 
            // buttonUnlinkDAT
            // 
            this.buttonUnlinkDAT.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(185)))), ((int)(((byte)(13)))), ((int)(((byte)(10)))));
            this.buttonUnlinkDAT.FlatAppearance.BorderSize = 0;
            this.buttonUnlinkDAT.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonUnlinkDAT.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.buttonUnlinkDAT.ForeColor = System.Drawing.Color.White;
            this.buttonUnlinkDAT.Location = new System.Drawing.Point(440, 21);
            this.buttonUnlinkDAT.Name = "buttonUnlinkDAT";
            this.buttonUnlinkDAT.Size = new System.Drawing.Size(100, 20);
            this.buttonUnlinkDAT.TabIndex = 3;
            this.buttonUnlinkDAT.Text = "Unlink";
            this.buttonUnlinkDAT.UseVisualStyleBackColor = false;
            this.buttonUnlinkDAT.Click += new System.EventHandler(this.buttonUnlinkDAT_Click);
            // 
            // labelDatFile
            // 
            this.labelDatFile.AutoSize = true;
            this.labelDatFile.Location = new System.Drawing.Point(84, 25);
            this.labelDatFile.Name = "labelDatFile";
            this.labelDatFile.Size = new System.Drawing.Size(53, 13);
            this.labelDatFile.TabIndex = 0;
            this.labelDatFile.Text = "not linked";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(6, 25);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(72, 13);
            this.label4.TabIndex = 0;
            this.label4.Text = "Current .DAT:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(6, 6);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(130, 13);
            this.label5.TabIndex = 0;
            this.label5.Text = "Account Quick-Switching:";
            // 
            // groupBox2
            // 
            this.groupBox2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.groupBox2.BorderColor = System.Drawing.Color.Gray;
            this.groupBox2.BorderSize = 1;
            this.groupBox2.Controls.Add(this.listBoxAccounts);
            this.groupBox2.Controls.Add(this.label6);
            this.groupBox2.Controls.Add(this.buttonEditAccount);
            this.groupBox2.Controls.Add(this.buttonRemoveAccount);
            this.groupBox2.Controls.Add(this.apiKeyInfo);
            this.groupBox2.Location = new System.Drawing.Point(12, 124);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(546, 238);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "groupBoxAccounts";
            // 
            // listBoxAccounts
            // 
            this.listBoxAccounts.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.listBoxAccounts.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.listBoxAccounts.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.listBoxAccounts.ForeColor = System.Drawing.Color.White;
            this.listBoxAccounts.FormattingEnabled = true;
            this.listBoxAccounts.ItemHeight = 16;
            this.listBoxAccounts.Location = new System.Drawing.Point(6, 6);
            this.listBoxAccounts.Name = "listBoxAccounts";
            this.listBoxAccounts.Size = new System.Drawing.Size(352, 226);
            this.listBoxAccounts.TabIndex = 1;
            this.listBoxAccounts.SelectedIndexChanged += new System.EventHandler(this.listBoxAccounts_SelectedIndexChanged);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(364, 6);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(140, 13);
            this.label6.TabIndex = 0;
            this.label6.Text = "Permissions of selected key:";
            // 
            // buttonEditAccount
            // 
            this.buttonEditAccount.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(185)))), ((int)(((byte)(13)))), ((int)(((byte)(10)))));
            this.buttonEditAccount.FlatAppearance.BorderSize = 0;
            this.buttonEditAccount.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonEditAccount.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.buttonEditAccount.ForeColor = System.Drawing.Color.White;
            this.buttonEditAccount.Location = new System.Drawing.Point(364, 212);
            this.buttonEditAccount.Name = "buttonEditAccount";
            this.buttonEditAccount.Size = new System.Drawing.Size(176, 20);
            this.buttonEditAccount.TabIndex = 3;
            this.buttonEditAccount.Text = "Edit";
            this.buttonEditAccount.UseVisualStyleBackColor = false;
            this.buttonEditAccount.Click += new System.EventHandler(this.buttonEditAccount_Click);
            // 
            // buttonRemoveAccount
            // 
            this.buttonRemoveAccount.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(185)))), ((int)(((byte)(13)))), ((int)(((byte)(10)))));
            this.buttonRemoveAccount.FlatAppearance.BorderSize = 0;
            this.buttonRemoveAccount.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonRemoveAccount.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.buttonRemoveAccount.ForeColor = System.Drawing.Color.White;
            this.buttonRemoveAccount.Location = new System.Drawing.Point(364, 186);
            this.buttonRemoveAccount.Name = "buttonRemoveAccount";
            this.buttonRemoveAccount.Size = new System.Drawing.Size(176, 20);
            this.buttonRemoveAccount.TabIndex = 2;
            this.buttonRemoveAccount.Text = "Remove";
            this.buttonRemoveAccount.UseVisualStyleBackColor = false;
            this.buttonRemoveAccount.Click += new System.EventHandler(this.buttonRemoveAccount_Click);
            // 
            // apiKeyInfo
            // 
            this.apiKeyInfo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(55)))), ((int)(((byte)(55)))), ((int)(((byte)(55)))));
            this.apiKeyInfo.ForeColor = System.Drawing.Color.White;
            this.apiKeyInfo.Location = new System.Drawing.Point(364, 22);
            this.apiKeyInfo.Name = "apiKeyInfo";
            this.apiKeyInfo.Size = new System.Drawing.Size(176, 156);
            this.apiKeyInfo.TabIndex = 0;
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.groupBox1.BorderColor = System.Drawing.Color.Gray;
            this.groupBox1.BorderSize = 1;
            this.groupBox1.Controls.Add(this.labelError);
            this.groupBox1.Controls.Add(this.buttonAddAccount);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.textBoxAPIKey);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.textBoxName);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(546, 106);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "groupBoxAccountEdit";
            // 
            // labelError
            // 
            this.labelError.AutoSize = true;
            this.labelError.Location = new System.Drawing.Point(73, 84);
            this.labelError.Name = "labelError";
            this.labelError.Size = new System.Drawing.Size(52, 13);
            this.labelError.TabIndex = 0;
            this.labelError.Text = "[ERROR]";
            this.labelError.Visible = false;
            // 
            // buttonAddAccount
            // 
            this.buttonAddAccount.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(185)))), ((int)(((byte)(13)))), ((int)(((byte)(10)))));
            this.buttonAddAccount.FlatAppearance.BorderSize = 0;
            this.buttonAddAccount.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonAddAccount.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.buttonAddAccount.ForeColor = System.Drawing.Color.White;
            this.buttonAddAccount.Location = new System.Drawing.Point(440, 80);
            this.buttonAddAccount.Name = "buttonAddAccount";
            this.buttonAddAccount.Size = new System.Drawing.Size(100, 20);
            this.buttonAddAccount.TabIndex = 3;
            this.buttonAddAccount.Text = "Add";
            this.buttonAddAccount.UseVisualStyleBackColor = false;
            this.buttonAddAccount.Click += new System.EventHandler(this.buttonAddAccount_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 6);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(109, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Save a new account:";
            // 
            // textBoxAPIKey
            // 
            this.textBoxAPIKey.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.textBoxAPIKey.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textBoxAPIKey.ForeColor = System.Drawing.Color.White;
            this.textBoxAPIKey.Location = new System.Drawing.Point(76, 54);
            this.textBoxAPIKey.Name = "textBoxAPIKey";
            this.textBoxAPIKey.Size = new System.Drawing.Size(464, 20);
            this.textBoxAPIKey.TabIndex = 2;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(22, 56);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(48, 13);
            this.label3.TabIndex = 0;
            this.label3.Text = "API-Key:";
            // 
            // textBoxName
            // 
            this.textBoxName.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.textBoxName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textBoxName.ForeColor = System.Drawing.Color.White;
            this.textBoxName.Location = new System.Drawing.Point(76, 28);
            this.textBoxName.Name = "textBoxName";
            this.textBoxName.Size = new System.Drawing.Size(464, 20);
            this.textBoxName.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(32, 30);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(38, 13);
            this.label2.TabIndex = 0;
            this.label2.Text = "Name:";
            // 
            // Accounts
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(55)))), ((int)(((byte)(55)))), ((int)(((byte)(55)))));
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.ForeColor = System.Drawing.Color.White;
            this.Name = "Accounts";
            this.Size = new System.Drawing.Size(570, 436);
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private Controls.GroupBox groupBox1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textBoxAPIKey;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox textBoxName;
        private System.Windows.Forms.Label label1;
        private Controls.HighlightButton buttonAddAccount;
        private Controls.GroupBox groupBox2;
        private System.Windows.Forms.Label label6;
        private Controls.HighlightButton buttonEditAccount;
        private Controls.HighlightButton buttonRemoveAccount;
        private Controls.ApiKeyInfo apiKeyInfo;
        private System.Windows.Forms.ListBox listBoxAccounts;
        private System.Windows.Forms.Label labelError;
        private Controls.GroupBox groupBox3;
        private Controls.HighlightButton buttonLinkCurrentDAT;
        private Controls.HighlightButton buttonUnlinkDAT;
        private System.Windows.Forms.Label labelDatFile;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.LinkLabel linkLabelQuickSwitchingHelp;
        private System.Windows.Forms.Label labelLinkingError;
    }
}
