namespace GuildLounge.TabPages.SettingsPages
{
    partial class General
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
            this.labelBuildNumber = new System.Windows.Forms.Label();
            this.groupBox4 = new GuildLounge.Controls.GroupBox();
            this.labelUpdaterInfo = new System.Windows.Forms.Label();
            this.buttonCheckForUpdates = new GuildLounge.Controls.HighlightButton();
            this.checkBoxAutoUpdate = new System.Windows.Forms.CheckBox();
            this.label4 = new System.Windows.Forms.Label();
            this.groupBox2 = new GuildLounge.Controls.GroupBox();
            this.textBoxStartParams = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.groupBox1 = new GuildLounge.Controls.GroupBox();
            this.buttonBrowseGameDirectory = new GuildLounge.Controls.HighlightButton();
            this.textBoxGameDirectory = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox3 = new GuildLounge.Controls.GroupBox();
            this.radioButtonLaunchStayOpen = new System.Windows.Forms.RadioButton();
            this.radioButtonLaunchClose = new System.Windows.Forms.RadioButton();
            this.radioButtonLaunchMinimize = new System.Windows.Forms.RadioButton();
            this.label3 = new System.Windows.Forms.Label();
            this.groupBox4.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // labelBuildNumber
            // 
            this.labelBuildNumber.AutoSize = true;
            this.labelBuildNumber.Location = new System.Drawing.Point(9, 411);
            this.labelBuildNumber.Name = "labelBuildNumber";
            this.labelBuildNumber.Size = new System.Drawing.Size(66, 13);
            this.labelBuildNumber.TabIndex = 26;
            this.labelBuildNumber.Text = "Build: 00000";
            // 
            // groupBox4
            // 
            this.groupBox4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.groupBox4.BorderColor = System.Drawing.Color.Gray;
            this.groupBox4.BorderSize = 1;
            this.groupBox4.Controls.Add(this.labelUpdaterInfo);
            this.groupBox4.Controls.Add(this.buttonCheckForUpdates);
            this.groupBox4.Controls.Add(this.checkBoxAutoUpdate);
            this.groupBox4.Controls.Add(this.label4);
            this.groupBox4.Location = new System.Drawing.Point(296, 120);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(262, 47);
            this.groupBox4.TabIndex = 24;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "gL_GroupBox3";
            // 
            // labelUpdaterInfo
            // 
            this.labelUpdaterInfo.AutoSize = true;
            this.labelUpdaterInfo.Location = new System.Drawing.Point(62, 6);
            this.labelUpdaterInfo.Name = "labelUpdaterInfo";
            this.labelUpdaterInfo.Size = new System.Drawing.Size(90, 13);
            this.labelUpdaterInfo.TabIndex = 16;
            this.labelUpdaterInfo.Text = "[UPDATERINFO]";
            this.labelUpdaterInfo.Visible = false;
            // 
            // buttonCheckForUpdates
            // 
            this.buttonCheckForUpdates.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(185)))), ((int)(((byte)(13)))), ((int)(((byte)(10)))));
            this.buttonCheckForUpdates.FlatAppearance.BorderSize = 0;
            this.buttonCheckForUpdates.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonCheckForUpdates.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.buttonCheckForUpdates.ForeColor = System.Drawing.Color.White;
            this.buttonCheckForUpdates.Location = new System.Drawing.Point(156, 21);
            this.buttonCheckForUpdates.Name = "buttonCheckForUpdates";
            this.buttonCheckForUpdates.Size = new System.Drawing.Size(100, 20);
            this.buttonCheckForUpdates.TabIndex = 10;
            this.buttonCheckForUpdates.Text = "Check Now";
            this.buttonCheckForUpdates.UseVisualStyleBackColor = false;
            this.buttonCheckForUpdates.Click += new System.EventHandler(this.buttonCheckForUpdates_Click);
            // 
            // checkBoxAutoUpdate
            // 
            this.checkBoxAutoUpdate.AutoSize = true;
            this.checkBoxAutoUpdate.Checked = true;
            this.checkBoxAutoUpdate.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBoxAutoUpdate.Location = new System.Drawing.Point(9, 23);
            this.checkBoxAutoUpdate.Name = "checkBoxAutoUpdate";
            this.checkBoxAutoUpdate.Size = new System.Drawing.Size(113, 17);
            this.checkBoxAutoUpdate.TabIndex = 15;
            this.checkBoxAutoUpdate.Text = "Check for updates";
            this.checkBoxAutoUpdate.UseVisualStyleBackColor = true;
            this.checkBoxAutoUpdate.CheckedChanged += new System.EventHandler(this.checkBoxAutoUpdate_CheckedChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(6, 6);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(50, 13);
            this.label4.TabIndex = 0;
            this.label4.Text = "Updates:";
            // 
            // groupBox2
            // 
            this.groupBox2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.groupBox2.BorderColor = System.Drawing.Color.Gray;
            this.groupBox2.BorderSize = 1;
            this.groupBox2.Controls.Add(this.textBoxStartParams);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Location = new System.Drawing.Point(12, 66);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(546, 48);
            this.groupBox2.TabIndex = 25;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "gL_GroupBox2";
            // 
            // textBoxStartParams
            // 
            this.textBoxStartParams.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.textBoxStartParams.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textBoxStartParams.ForeColor = System.Drawing.Color.White;
            this.textBoxStartParams.Location = new System.Drawing.Point(6, 22);
            this.textBoxStartParams.Name = "textBoxStartParams";
            this.textBoxStartParams.Size = new System.Drawing.Size(534, 20);
            this.textBoxStartParams.TabIndex = 13;
            this.textBoxStartParams.TextChanged += new System.EventHandler(this.textBoxStartParams_TextChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 6);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(185, 13);
            this.label2.TabIndex = 0;
            this.label2.Text = "Start Parameters (e.g. \"-maploadinfo\")";
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.groupBox1.BorderColor = System.Drawing.Color.Gray;
            this.groupBox1.BorderSize = 1;
            this.groupBox1.Controls.Add(this.buttonBrowseGameDirectory);
            this.groupBox1.Controls.Add(this.textBoxGameDirectory);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(546, 48);
            this.groupBox1.TabIndex = 24;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "gL_GroupBox1";
            // 
            // buttonBrowseGameDirectory
            // 
            this.buttonBrowseGameDirectory.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(185)))), ((int)(((byte)(13)))), ((int)(((byte)(10)))));
            this.buttonBrowseGameDirectory.FlatAppearance.BorderSize = 0;
            this.buttonBrowseGameDirectory.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonBrowseGameDirectory.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.buttonBrowseGameDirectory.ForeColor = System.Drawing.Color.White;
            this.buttonBrowseGameDirectory.Location = new System.Drawing.Point(440, 22);
            this.buttonBrowseGameDirectory.Name = "buttonBrowseGameDirectory";
            this.buttonBrowseGameDirectory.Size = new System.Drawing.Size(100, 20);
            this.buttonBrowseGameDirectory.TabIndex = 9;
            this.buttonBrowseGameDirectory.Text = "Browse";
            this.buttonBrowseGameDirectory.UseVisualStyleBackColor = false;
            this.buttonBrowseGameDirectory.Click += new System.EventHandler(this.buttonBrowseGameDirectory_Click);
            // 
            // textBoxGameDirectory
            // 
            this.textBoxGameDirectory.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.textBoxGameDirectory.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textBoxGameDirectory.ForeColor = System.Drawing.Color.White;
            this.textBoxGameDirectory.Location = new System.Drawing.Point(6, 22);
            this.textBoxGameDirectory.Name = "textBoxGameDirectory";
            this.textBoxGameDirectory.Size = new System.Drawing.Size(428, 20);
            this.textBoxGameDirectory.TabIndex = 8;
            this.textBoxGameDirectory.TextChanged += new System.EventHandler(this.textBoxGameDirectory_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 6);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(280, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "GW2 Directory (Usually: \"C:\\Program Files\\Guild Wars 2\")";
            // 
            // groupBox3
            // 
            this.groupBox3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.groupBox3.BorderColor = System.Drawing.Color.Gray;
            this.groupBox3.BorderSize = 1;
            this.groupBox3.Controls.Add(this.radioButtonLaunchStayOpen);
            this.groupBox3.Controls.Add(this.radioButtonLaunchClose);
            this.groupBox3.Controls.Add(this.radioButtonLaunchMinimize);
            this.groupBox3.Controls.Add(this.label3);
            this.groupBox3.Location = new System.Drawing.Point(12, 120);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(278, 47);
            this.groupBox3.TabIndex = 23;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "gL_GroupBox3";
            // 
            // radioButtonLaunchStayOpen
            // 
            this.radioButtonLaunchStayOpen.AutoSize = true;
            this.radioButtonLaunchStayOpen.Location = new System.Drawing.Point(6, 22);
            this.radioButtonLaunchStayOpen.Name = "radioButtonLaunchStayOpen";
            this.radioButtonLaunchStayOpen.Size = new System.Drawing.Size(71, 17);
            this.radioButtonLaunchStayOpen.TabIndex = 10;
            this.radioButtonLaunchStayOpen.Text = "stay open";
            this.radioButtonLaunchStayOpen.UseVisualStyleBackColor = true;
            this.radioButtonLaunchStayOpen.CheckedChanged += new System.EventHandler(this.radioButtonLaunchStayOpen_CheckedChanged);
            // 
            // radioButtonLaunchClose
            // 
            this.radioButtonLaunchClose.AutoSize = true;
            this.radioButtonLaunchClose.Location = new System.Drawing.Point(182, 22);
            this.radioButtonLaunchClose.Name = "radioButtonLaunchClose";
            this.radioButtonLaunchClose.Size = new System.Drawing.Size(50, 17);
            this.radioButtonLaunchClose.TabIndex = 12;
            this.radioButtonLaunchClose.Text = "close";
            this.radioButtonLaunchClose.UseVisualStyleBackColor = true;
            this.radioButtonLaunchClose.CheckedChanged += new System.EventHandler(this.radioButtonLaunchClose_CheckedChanged);
            // 
            // radioButtonLaunchMinimize
            // 
            this.radioButtonLaunchMinimize.AutoSize = true;
            this.radioButtonLaunchMinimize.Checked = true;
            this.radioButtonLaunchMinimize.Location = new System.Drawing.Point(107, 22);
            this.radioButtonLaunchMinimize.Name = "radioButtonLaunchMinimize";
            this.radioButtonLaunchMinimize.Size = new System.Drawing.Size(45, 17);
            this.radioButtonLaunchMinimize.TabIndex = 11;
            this.radioButtonLaunchMinimize.TabStop = true;
            this.radioButtonLaunchMinimize.Text = "hide";
            this.radioButtonLaunchMinimize.UseVisualStyleBackColor = true;
            this.radioButtonLaunchMinimize.CheckedChanged += new System.EventHandler(this.radioButtonLaunchMinimize_CheckedChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 6);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(219, 13);
            this.label3.TabIndex = 0;
            this.label3.Text = "When GW2 launches, Guild Lounge should..";
            // 
            // General
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(55)))), ((int)(((byte)(55)))), ((int)(((byte)(55)))));
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.labelBuildNumber);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.groupBox3);
            this.ForeColor = System.Drawing.Color.White;
            this.Name = "General";
            this.Size = new System.Drawing.Size(570, 436);
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Controls.GroupBox groupBox2;
        private System.Windows.Forms.TextBox textBoxStartParams;
        private System.Windows.Forms.Label label2;
        private Controls.GroupBox groupBox1;
        private Controls.HighlightButton buttonBrowseGameDirectory;
        private System.Windows.Forms.TextBox textBoxGameDirectory;
        private System.Windows.Forms.Label label1;
        private Controls.GroupBox groupBox3;
        private System.Windows.Forms.RadioButton radioButtonLaunchStayOpen;
        private System.Windows.Forms.RadioButton radioButtonLaunchClose;
        private System.Windows.Forms.RadioButton radioButtonLaunchMinimize;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label labelBuildNumber;
        private Controls.GroupBox groupBox4;
        private System.Windows.Forms.Label label4;
        private Controls.HighlightButton buttonCheckForUpdates;
        private System.Windows.Forms.CheckBox checkBoxAutoUpdate;
        private System.Windows.Forms.Label labelUpdaterInfo;
    }
}
