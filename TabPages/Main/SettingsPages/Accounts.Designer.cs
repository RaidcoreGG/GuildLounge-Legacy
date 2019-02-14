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
            this.groupBox1 = new GuildLounge.Controls.GroupBox();
            this.buttonToggleShowPassword = new GuildLounge.Controls.Button();
            this.buttonAddAccount = new GuildLounge.Controls.HighlightButton();
            this.label1 = new System.Windows.Forms.Label();
            this.textBoxPassword = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.textBoxEmail = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.textBoxAPIKey = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.textBoxName = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.groupBox2 = new GuildLounge.Controls.GroupBox();
            this.listBoxAPIKeys = new System.Windows.Forms.ListBox();
            this.label6 = new System.Windows.Forms.Label();
            this.buttonEditAccount = new GuildLounge.Controls.HighlightButton();
            this.buttonRemoveAccount = new GuildLounge.Controls.HighlightButton();
            this.apiKeyInfo1 = new GuildLounge.Controls.ApiKeyInfo();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.groupBox1.BorderColor = System.Drawing.Color.Gray;
            this.groupBox1.BorderSize = 1;
            this.groupBox1.Controls.Add(this.buttonToggleShowPassword);
            this.groupBox1.Controls.Add(this.buttonAddAccount);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.textBoxPassword);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.textBoxEmail);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.textBoxAPIKey);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.textBoxName);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(546, 158);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "groupBoxAccountEdit";
            // 
            // buttonToggleShowPassword
            // 
            this.buttonToggleShowPassword.BackColor = System.Drawing.Color.Transparent;
            this.buttonToggleShowPassword.BackgroundImage = global::GuildLounge.Properties.Resources.ui_locked;
            this.buttonToggleShowPassword.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.buttonToggleShowPassword.FlatAppearance.BorderSize = 0;
            this.buttonToggleShowPassword.FlatAppearance.CheckedBackColor = System.Drawing.Color.Transparent;
            this.buttonToggleShowPassword.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.buttonToggleShowPassword.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.buttonToggleShowPassword.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonToggleShowPassword.ForeColor = System.Drawing.Color.Gray;
            this.buttonToggleShowPassword.Location = new System.Drawing.Point(520, 106);
            this.buttonToggleShowPassword.Name = "buttonToggleShowPassword";
            this.buttonToggleShowPassword.Size = new System.Drawing.Size(20, 20);
            this.buttonToggleShowPassword.TabIndex = 23;
            this.buttonToggleShowPassword.TabStop = false;
            this.buttonToggleShowPassword.UseVisualStyleBackColor = false;
            this.buttonToggleShowPassword.Click += new System.EventHandler(this.buttonToggleShowPassword_Click);
            // 
            // buttonAddAccount
            // 
            this.buttonAddAccount.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(185)))), ((int)(((byte)(13)))), ((int)(((byte)(10)))));
            this.buttonAddAccount.FlatAppearance.BorderSize = 0;
            this.buttonAddAccount.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonAddAccount.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.buttonAddAccount.ForeColor = System.Drawing.Color.White;
            this.buttonAddAccount.Location = new System.Drawing.Point(440, 132);
            this.buttonAddAccount.Name = "buttonAddAccount";
            this.buttonAddAccount.Size = new System.Drawing.Size(100, 20);
            this.buttonAddAccount.TabIndex = 18;
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
            this.label1.TabIndex = 16;
            this.label1.Text = "Save a new account:";
            // 
            // textBoxPassword
            // 
            this.textBoxPassword.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.textBoxPassword.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textBoxPassword.ForeColor = System.Drawing.Color.White;
            this.textBoxPassword.Location = new System.Drawing.Point(76, 106);
            this.textBoxPassword.Name = "textBoxPassword";
            this.textBoxPassword.Size = new System.Drawing.Size(438, 20);
            this.textBoxPassword.TabIndex = 15;
            this.textBoxPassword.UseSystemPasswordChar = true;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(14, 108);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(56, 13);
            this.label5.TabIndex = 14;
            this.label5.Text = "Password:";
            // 
            // textBoxEmail
            // 
            this.textBoxEmail.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.textBoxEmail.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textBoxEmail.ForeColor = System.Drawing.Color.White;
            this.textBoxEmail.Location = new System.Drawing.Point(76, 80);
            this.textBoxEmail.Name = "textBoxEmail";
            this.textBoxEmail.Size = new System.Drawing.Size(464, 20);
            this.textBoxEmail.TabIndex = 13;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(31, 82);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(39, 13);
            this.label4.TabIndex = 12;
            this.label4.Text = "E-Mail:";
            // 
            // textBoxAPIKey
            // 
            this.textBoxAPIKey.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.textBoxAPIKey.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textBoxAPIKey.ForeColor = System.Drawing.Color.White;
            this.textBoxAPIKey.Location = new System.Drawing.Point(76, 54);
            this.textBoxAPIKey.Name = "textBoxAPIKey";
            this.textBoxAPIKey.Size = new System.Drawing.Size(464, 20);
            this.textBoxAPIKey.TabIndex = 11;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(22, 56);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(48, 13);
            this.label3.TabIndex = 10;
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
            this.textBoxName.TabIndex = 9;
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
            // groupBox2
            // 
            this.groupBox2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.groupBox2.BorderColor = System.Drawing.Color.Gray;
            this.groupBox2.BorderSize = 1;
            this.groupBox2.Controls.Add(this.listBoxAPIKeys);
            this.groupBox2.Controls.Add(this.label6);
            this.groupBox2.Controls.Add(this.buttonEditAccount);
            this.groupBox2.Controls.Add(this.buttonRemoveAccount);
            this.groupBox2.Controls.Add(this.apiKeyInfo1);
            this.groupBox2.Location = new System.Drawing.Point(12, 186);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(546, 238);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "groupBoxAccounts";
            // 
            // listBoxAPIKeys
            // 
            this.listBoxAPIKeys.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.listBoxAPIKeys.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.listBoxAPIKeys.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.listBoxAPIKeys.ForeColor = System.Drawing.Color.White;
            this.listBoxAPIKeys.FormattingEnabled = true;
            this.listBoxAPIKeys.ItemHeight = 16;
            this.listBoxAPIKeys.Location = new System.Drawing.Point(6, 6);
            this.listBoxAPIKeys.Name = "listBoxAPIKeys";
            this.listBoxAPIKeys.Size = new System.Drawing.Size(352, 226);
            this.listBoxAPIKeys.TabIndex = 22;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(364, 6);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(140, 13);
            this.label6.TabIndex = 21;
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
            this.buttonEditAccount.TabIndex = 20;
            this.buttonEditAccount.Text = "Edit";
            this.buttonEditAccount.UseVisualStyleBackColor = false;
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
            this.buttonRemoveAccount.TabIndex = 19;
            this.buttonRemoveAccount.Text = "Remove";
            this.buttonRemoveAccount.UseVisualStyleBackColor = false;
            // 
            // apiKeyInfo1
            // 
            this.apiKeyInfo1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(55)))), ((int)(((byte)(55)))), ((int)(((byte)(55)))));
            this.apiKeyInfo1.ForeColor = System.Drawing.Color.White;
            this.apiKeyInfo1.Location = new System.Drawing.Point(364, 22);
            this.apiKeyInfo1.Name = "apiKeyInfo1";
            this.apiKeyInfo1.Size = new System.Drawing.Size(176, 156);
            this.apiKeyInfo1.TabIndex = 1;
            // 
            // Accounts
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(55)))), ((int)(((byte)(55)))), ((int)(((byte)(55)))));
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.ForeColor = System.Drawing.Color.White;
            this.Name = "Accounts";
            this.Size = new System.Drawing.Size(570, 436);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private Controls.GroupBox groupBox1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textBoxPassword;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox textBoxEmail;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox textBoxAPIKey;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox textBoxName;
        private System.Windows.Forms.Label label1;
        private Controls.HighlightButton buttonAddAccount;
        private Controls.Button buttonToggleShowPassword;
        private Controls.GroupBox groupBox2;
        private System.Windows.Forms.Label label6;
        private Controls.HighlightButton buttonEditAccount;
        private Controls.HighlightButton buttonRemoveAccount;
        private Controls.ApiKeyInfo apiKeyInfo1;
        private System.Windows.Forms.ListBox listBoxAPIKeys;
    }
}
