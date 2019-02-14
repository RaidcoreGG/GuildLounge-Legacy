namespace GuildLounge.TabPages
{
    partial class Settings
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
            this.panelCategories = new System.Windows.Forms.Panel();
            this.buttonAbout = new GuildLounge.Controls.HighlightButton();
            this.buttonSettingsExtensions = new GuildLounge.Controls.HighlightButton();
            this.buttonSettingsModules = new GuildLounge.Controls.HighlightButton();
            this.buttonSettingsAccounts = new GuildLounge.Controls.HighlightButton();
            this.buttonSettingsGeneral = new GuildLounge.Controls.HighlightButton();
            this.buttonSave = new GuildLounge.Controls.HighlightButton();
            this.buttonRestore = new GuildLounge.Controls.HighlightButton();
            this.horizontalLine1 = new GuildLounge.Controls.HorizontalLine();
            this.panelCategories.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelCategories
            // 
            this.panelCategories.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(45)))));
            this.panelCategories.Controls.Add(this.horizontalLine1);
            this.panelCategories.Controls.Add(this.buttonRestore);
            this.panelCategories.Controls.Add(this.buttonSave);
            this.panelCategories.Controls.Add(this.buttonAbout);
            this.panelCategories.Controls.Add(this.buttonSettingsExtensions);
            this.panelCategories.Controls.Add(this.buttonSettingsModules);
            this.panelCategories.Controls.Add(this.buttonSettingsAccounts);
            this.panelCategories.Controls.Add(this.buttonSettingsGeneral);
            this.panelCategories.Location = new System.Drawing.Point(0, 0);
            this.panelCategories.Name = "panelCategories";
            this.panelCategories.Size = new System.Drawing.Size(170, 436);
            this.panelCategories.TabIndex = 1;
            // 
            // buttonAbout
            // 
            this.buttonAbout.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(185)))), ((int)(((byte)(13)))), ((int)(((byte)(10)))));
            this.buttonAbout.FlatAppearance.BorderSize = 0;
            this.buttonAbout.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonAbout.ForeColor = System.Drawing.Color.White;
            this.buttonAbout.Location = new System.Drawing.Point(12, 335);
            this.buttonAbout.Name = "buttonAbout";
            this.buttonAbout.Size = new System.Drawing.Size(146, 23);
            this.buttonAbout.TabIndex = 4;
            this.buttonAbout.Text = "About";
            this.buttonAbout.UseVisualStyleBackColor = false;
            this.buttonAbout.Click += new System.EventHandler(this.buttonAbout_Click);
            // 
            // buttonSettingsExtensions
            // 
            this.buttonSettingsExtensions.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(185)))), ((int)(((byte)(13)))), ((int)(((byte)(10)))));
            this.buttonSettingsExtensions.FlatAppearance.BorderSize = 0;
            this.buttonSettingsExtensions.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonSettingsExtensions.ForeColor = System.Drawing.Color.White;
            this.buttonSettingsExtensions.Location = new System.Drawing.Point(12, 99);
            this.buttonSettingsExtensions.Name = "buttonSettingsExtensions";
            this.buttonSettingsExtensions.Size = new System.Drawing.Size(146, 23);
            this.buttonSettingsExtensions.TabIndex = 3;
            this.buttonSettingsExtensions.Text = "Add-Ons";
            this.buttonSettingsExtensions.UseVisualStyleBackColor = false;
            this.buttonSettingsExtensions.Click += new System.EventHandler(this.buttonSettingsExtensions_Click);
            // 
            // buttonSettingsModules
            // 
            this.buttonSettingsModules.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(185)))), ((int)(((byte)(13)))), ((int)(((byte)(10)))));
            this.buttonSettingsModules.FlatAppearance.BorderSize = 0;
            this.buttonSettingsModules.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonSettingsModules.ForeColor = System.Drawing.Color.White;
            this.buttonSettingsModules.Location = new System.Drawing.Point(12, 70);
            this.buttonSettingsModules.Name = "buttonSettingsModules";
            this.buttonSettingsModules.Size = new System.Drawing.Size(146, 23);
            this.buttonSettingsModules.TabIndex = 2;
            this.buttonSettingsModules.Text = "Modules";
            this.buttonSettingsModules.UseVisualStyleBackColor = false;
            this.buttonSettingsModules.Click += new System.EventHandler(this.buttonSettingsModules_Click);
            // 
            // buttonSettingsAccounts
            // 
            this.buttonSettingsAccounts.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(185)))), ((int)(((byte)(13)))), ((int)(((byte)(10)))));
            this.buttonSettingsAccounts.FlatAppearance.BorderSize = 0;
            this.buttonSettingsAccounts.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonSettingsAccounts.ForeColor = System.Drawing.Color.White;
            this.buttonSettingsAccounts.Location = new System.Drawing.Point(12, 41);
            this.buttonSettingsAccounts.Name = "buttonSettingsAccounts";
            this.buttonSettingsAccounts.Size = new System.Drawing.Size(146, 23);
            this.buttonSettingsAccounts.TabIndex = 1;
            this.buttonSettingsAccounts.Text = "Accounts";
            this.buttonSettingsAccounts.UseVisualStyleBackColor = false;
            this.buttonSettingsAccounts.Click += new System.EventHandler(this.buttonSettingsAccounts_Click);
            // 
            // buttonSettingsGeneral
            // 
            this.buttonSettingsGeneral.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(185)))), ((int)(((byte)(13)))), ((int)(((byte)(10)))));
            this.buttonSettingsGeneral.FlatAppearance.BorderSize = 0;
            this.buttonSettingsGeneral.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonSettingsGeneral.ForeColor = System.Drawing.Color.White;
            this.buttonSettingsGeneral.Location = new System.Drawing.Point(12, 12);
            this.buttonSettingsGeneral.Name = "buttonSettingsGeneral";
            this.buttonSettingsGeneral.Size = new System.Drawing.Size(146, 23);
            this.buttonSettingsGeneral.TabIndex = 0;
            this.buttonSettingsGeneral.Text = "General";
            this.buttonSettingsGeneral.UseVisualStyleBackColor = false;
            this.buttonSettingsGeneral.Click += new System.EventHandler(this.buttonSettingsGeneral_Click);
            // 
            // buttonSave
            // 
            this.buttonSave.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(185)))), ((int)(((byte)(13)))), ((int)(((byte)(10)))));
            this.buttonSave.FlatAppearance.BorderSize = 0;
            this.buttonSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonSave.ForeColor = System.Drawing.Color.White;
            this.buttonSave.Location = new System.Drawing.Point(12, 401);
            this.buttonSave.Name = "buttonSave";
            this.buttonSave.Size = new System.Drawing.Size(146, 23);
            this.buttonSave.TabIndex = 5;
            this.buttonSave.Text = "Save";
            this.buttonSave.UseVisualStyleBackColor = false;
            this.buttonSave.Click += new System.EventHandler(this.buttonSave_Click);
            // 
            // buttonRestore
            // 
            this.buttonRestore.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(185)))), ((int)(((byte)(13)))), ((int)(((byte)(10)))));
            this.buttonRestore.FlatAppearance.BorderSize = 0;
            this.buttonRestore.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonRestore.ForeColor = System.Drawing.Color.White;
            this.buttonRestore.Location = new System.Drawing.Point(12, 372);
            this.buttonRestore.Name = "buttonRestore";
            this.buttonRestore.Size = new System.Drawing.Size(146, 23);
            this.buttonRestore.TabIndex = 6;
            this.buttonRestore.Text = "Restore";
            this.buttonRestore.UseVisualStyleBackColor = false;
            this.buttonRestore.Click += new System.EventHandler(this.buttonRestore_Click);
            // 
            // horizontalLine1
            // 
            this.horizontalLine1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(55)))), ((int)(((byte)(55)))), ((int)(((byte)(55)))));
            this.horizontalLine1.Location = new System.Drawing.Point(12, 364);
            this.horizontalLine1.Name = "horizontalLine1";
            this.horizontalLine1.Size = new System.Drawing.Size(146, 2);
            this.horizontalLine1.TabIndex = 7;
            this.horizontalLine1.Text = "horizontalLine1";
            // 
            // Settings
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(54)))), ((int)(((byte)(57)))), ((int)(((byte)(63)))));
            this.Controls.Add(this.panelCategories);
            this.ForeColor = System.Drawing.Color.White;
            this.Name = "Settings";
            this.Size = new System.Drawing.Size(740, 436);
            this.panelCategories.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panelCategories;
        private Controls.HighlightButton buttonAbout;
        private Controls.HighlightButton buttonSettingsExtensions;
        private Controls.HighlightButton buttonSettingsModules;
        private Controls.HighlightButton buttonSettingsAccounts;
        private Controls.HighlightButton buttonSettingsGeneral;
        private Controls.HorizontalLine horizontalLine1;
        private Controls.HighlightButton buttonRestore;
        private Controls.HighlightButton buttonSave;
    }
}
