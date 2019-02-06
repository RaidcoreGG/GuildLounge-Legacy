namespace GuildLounge
{
    partial class UserControl_Settings
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
            this.gL_GroupBoxStartParams = new GuildLounge.Control_GroupBox();
            this.textBoxStartParams = new System.Windows.Forms.TextBox();
            this.labelStartParams = new System.Windows.Forms.Label();
            this.buttonRestore = new GuildLounge.Control_HighlightButton();
            this.buttonSave = new GuildLounge.Control_HighlightButton();
            this.gL_GroupBoxAddOns = new GuildLounge.Control_GroupBox();
            this.buttonForceUpdate = new GuildLounge.Control_HighlightButton();
            this.buttonRemoveAddOn = new GuildLounge.Control_HighlightButton();
            this.buttonEditAddOn = new GuildLounge.Control_HighlightButton();
            this.labelUpdateInfo = new System.Windows.Forms.Label();
            this.labelError = new System.Windows.Forms.Label();
            this.buttonAddAddOn = new GuildLounge.Control_HighlightButton();
            this.textBoxAddOnLink = new System.Windows.Forms.TextBox();
            this.labelUpdateLink = new System.Windows.Forms.Label();
            this.listBoxAddOns = new System.Windows.Forms.ListBox();
            this.checkBoxUpdateAddOns = new System.Windows.Forms.CheckBox();
            this.gL_GroupBoxGameDir = new GuildLounge.Control_GroupBox();
            this.buttonBrowseGameDirectory = new GuildLounge.Control_HighlightButton();
            this.textBoxGameDirectory = new System.Windows.Forms.TextBox();
            this.labelDirectory = new System.Windows.Forms.Label();
            this.gL_GroupBoxLaunchBehavior = new GuildLounge.Control_GroupBox();
            this.radioButtonLaunchStayOpen = new System.Windows.Forms.RadioButton();
            this.radioButtonLaunchClose = new System.Windows.Forms.RadioButton();
            this.radioButtonLaunchMinimize = new System.Windows.Forms.RadioButton();
            this.labelLaunchBehavior = new System.Windows.Forms.Label();
            this.gL_GroupBoxStartParams.SuspendLayout();
            this.gL_GroupBoxAddOns.SuspendLayout();
            this.gL_GroupBoxGameDir.SuspendLayout();
            this.gL_GroupBoxLaunchBehavior.SuspendLayout();
            this.SuspendLayout();
            // 
            // gL_GroupBoxStartParams
            // 
            this.gL_GroupBoxStartParams.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.gL_GroupBoxStartParams.BorderColor = System.Drawing.Color.Gray;
            this.gL_GroupBoxStartParams.BorderSize = 1;
            this.gL_GroupBoxStartParams.Controls.Add(this.textBoxStartParams);
            this.gL_GroupBoxStartParams.Controls.Add(this.labelStartParams);
            this.gL_GroupBoxStartParams.Location = new System.Drawing.Point(296, 65);
            this.gL_GroupBoxStartParams.Name = "gL_GroupBoxStartParams";
            this.gL_GroupBoxStartParams.Size = new System.Drawing.Size(432, 47);
            this.gL_GroupBoxStartParams.TabIndex = 22;
            this.gL_GroupBoxStartParams.TabStop = false;
            this.gL_GroupBoxStartParams.Text = "gL_GroupBox4";
            // 
            // textBoxStartParams
            // 
            this.textBoxStartParams.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.textBoxStartParams.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textBoxStartParams.ForeColor = System.Drawing.Color.White;
            this.textBoxStartParams.Location = new System.Drawing.Point(9, 21);
            this.textBoxStartParams.Name = "textBoxStartParams";
            this.textBoxStartParams.Size = new System.Drawing.Size(420, 20);
            this.textBoxStartParams.TabIndex = 13;
            this.textBoxStartParams.TextChanged += new System.EventHandler(this.textBoxStartParams_TextChanged);
            // 
            // labelStartParams
            // 
            this.labelStartParams.AutoSize = true;
            this.labelStartParams.Location = new System.Drawing.Point(6, 6);
            this.labelStartParams.Name = "labelStartParams";
            this.labelStartParams.Size = new System.Drawing.Size(185, 13);
            this.labelStartParams.TabIndex = 0;
            this.labelStartParams.Text = "Start Parameters (e.g. \"-maploadinfo\")";
            // 
            // buttonRestore
            // 
            this.buttonRestore.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(185)))), ((int)(((byte)(13)))), ((int)(((byte)(10)))));
            this.buttonRestore.FlatAppearance.BorderSize = 0;
            this.buttonRestore.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonRestore.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.buttonRestore.ForeColor = System.Drawing.Color.White;
            this.buttonRestore.Location = new System.Drawing.Point(522, 394);
            this.buttonRestore.Name = "buttonRestore";
            this.buttonRestore.Size = new System.Drawing.Size(100, 30);
            this.buttonRestore.TabIndex = 19;
            this.buttonRestore.Text = "Restore";
            this.buttonRestore.UseVisualStyleBackColor = false;
            this.buttonRestore.Click += new System.EventHandler(this.buttonRestore_Click);
            // 
            // buttonSave
            // 
            this.buttonSave.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(185)))), ((int)(((byte)(13)))), ((int)(((byte)(10)))));
            this.buttonSave.Enabled = false;
            this.buttonSave.FlatAppearance.BorderSize = 0;
            this.buttonSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonSave.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.buttonSave.ForeColor = System.Drawing.Color.White;
            this.buttonSave.Location = new System.Drawing.Point(628, 394);
            this.buttonSave.Name = "buttonSave";
            this.buttonSave.Size = new System.Drawing.Size(100, 30);
            this.buttonSave.TabIndex = 18;
            this.buttonSave.Text = "Save";
            this.buttonSave.UseVisualStyleBackColor = false;
            this.buttonSave.Click += new System.EventHandler(this.buttonSave_Click);
            // 
            // gL_GroupBoxAddOns
            // 
            this.gL_GroupBoxAddOns.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.gL_GroupBoxAddOns.BorderColor = System.Drawing.Color.Gray;
            this.gL_GroupBoxAddOns.BorderSize = 1;
            this.gL_GroupBoxAddOns.Controls.Add(this.buttonForceUpdate);
            this.gL_GroupBoxAddOns.Controls.Add(this.buttonRemoveAddOn);
            this.gL_GroupBoxAddOns.Controls.Add(this.buttonEditAddOn);
            this.gL_GroupBoxAddOns.Controls.Add(this.labelUpdateInfo);
            this.gL_GroupBoxAddOns.Controls.Add(this.labelError);
            this.gL_GroupBoxAddOns.Controls.Add(this.buttonAddAddOn);
            this.gL_GroupBoxAddOns.Controls.Add(this.textBoxAddOnLink);
            this.gL_GroupBoxAddOns.Controls.Add(this.labelUpdateLink);
            this.gL_GroupBoxAddOns.Controls.Add(this.listBoxAddOns);
            this.gL_GroupBoxAddOns.Controls.Add(this.checkBoxUpdateAddOns);
            this.gL_GroupBoxAddOns.Location = new System.Drawing.Point(12, 117);
            this.gL_GroupBoxAddOns.Name = "gL_GroupBoxAddOns";
            this.gL_GroupBoxAddOns.Size = new System.Drawing.Size(716, 270);
            this.gL_GroupBoxAddOns.TabIndex = 19;
            this.gL_GroupBoxAddOns.TabStop = false;
            this.gL_GroupBoxAddOns.Text = "gL_GroupBox3";
            // 
            // buttonForceUpdate
            // 
            this.buttonForceUpdate.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(185)))), ((int)(((byte)(13)))), ((int)(((byte)(10)))));
            this.buttonForceUpdate.FlatAppearance.BorderSize = 0;
            this.buttonForceUpdate.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonForceUpdate.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.buttonForceUpdate.ForeColor = System.Drawing.Color.White;
            this.buttonForceUpdate.Location = new System.Drawing.Point(292, 244);
            this.buttonForceUpdate.Name = "buttonForceUpdate";
            this.buttonForceUpdate.Size = new System.Drawing.Size(100, 20);
            this.buttonForceUpdate.TabIndex = 20;
            this.buttonForceUpdate.Text = "Force Update";
            this.buttonForceUpdate.UseVisualStyleBackColor = false;
            this.buttonForceUpdate.Click += new System.EventHandler(this.buttonForceUpdate_Click);
            // 
            // buttonRemoveAddOn
            // 
            this.buttonRemoveAddOn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(185)))), ((int)(((byte)(13)))), ((int)(((byte)(10)))));
            this.buttonRemoveAddOn.FlatAppearance.BorderSize = 0;
            this.buttonRemoveAddOn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonRemoveAddOn.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.buttonRemoveAddOn.ForeColor = System.Drawing.Color.White;
            this.buttonRemoveAddOn.Location = new System.Drawing.Point(398, 244);
            this.buttonRemoveAddOn.Name = "buttonRemoveAddOn";
            this.buttonRemoveAddOn.Size = new System.Drawing.Size(100, 20);
            this.buttonRemoveAddOn.TabIndex = 19;
            this.buttonRemoveAddOn.Text = "Remove";
            this.buttonRemoveAddOn.UseVisualStyleBackColor = false;
            this.buttonRemoveAddOn.Click += new System.EventHandler(this.buttonRemoveAddOn_Click);
            // 
            // buttonEditAddOn
            // 
            this.buttonEditAddOn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(185)))), ((int)(((byte)(13)))), ((int)(((byte)(10)))));
            this.buttonEditAddOn.FlatAppearance.BorderSize = 0;
            this.buttonEditAddOn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonEditAddOn.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.buttonEditAddOn.ForeColor = System.Drawing.Color.White;
            this.buttonEditAddOn.Location = new System.Drawing.Point(504, 244);
            this.buttonEditAddOn.Name = "buttonEditAddOn";
            this.buttonEditAddOn.Size = new System.Drawing.Size(100, 20);
            this.buttonEditAddOn.TabIndex = 18;
            this.buttonEditAddOn.Text = "Edit";
            this.buttonEditAddOn.UseVisualStyleBackColor = false;
            this.buttonEditAddOn.Click += new System.EventHandler(this.buttonEditAddOn_Click);
            // 
            // labelUpdateInfo
            // 
            this.labelUpdateInfo.AutoSize = true;
            this.labelUpdateInfo.Location = new System.Drawing.Point(233, 10);
            this.labelUpdateInfo.Name = "labelUpdateInfo";
            this.labelUpdateInfo.Size = new System.Drawing.Size(82, 13);
            this.labelUpdateInfo.TabIndex = 0;
            this.labelUpdateInfo.Text = "[UPDATEINFO]";
            this.labelUpdateInfo.Visible = false;
            // 
            // labelError
            // 
            this.labelError.AutoSize = true;
            this.labelError.Location = new System.Drawing.Point(6, 248);
            this.labelError.Name = "labelError";
            this.labelError.Size = new System.Drawing.Size(52, 13);
            this.labelError.TabIndex = 0;
            this.labelError.Text = "[ERROR]";
            this.labelError.Visible = false;
            // 
            // buttonAddAddOn
            // 
            this.buttonAddAddOn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(185)))), ((int)(((byte)(13)))), ((int)(((byte)(10)))));
            this.buttonAddAddOn.FlatAppearance.BorderSize = 0;
            this.buttonAddAddOn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonAddAddOn.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.buttonAddAddOn.ForeColor = System.Drawing.Color.White;
            this.buttonAddAddOn.Location = new System.Drawing.Point(610, 244);
            this.buttonAddAddOn.Name = "buttonAddAddOn";
            this.buttonAddAddOn.Size = new System.Drawing.Size(100, 20);
            this.buttonAddAddOn.TabIndex = 17;
            this.buttonAddAddOn.Text = "Add";
            this.buttonAddAddOn.UseVisualStyleBackColor = false;
            this.buttonAddAddOn.Click += new System.EventHandler(this.buttonAddAddOn_Click);
            // 
            // textBoxAddOnLink
            // 
            this.textBoxAddOnLink.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.textBoxAddOnLink.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textBoxAddOnLink.ForeColor = System.Drawing.Color.White;
            this.textBoxAddOnLink.Location = new System.Drawing.Point(6, 218);
            this.textBoxAddOnLink.Name = "textBoxAddOnLink";
            this.textBoxAddOnLink.Size = new System.Drawing.Size(704, 20);
            this.textBoxAddOnLink.TabIndex = 16;
            // 
            // labelUpdateLink
            // 
            this.labelUpdateLink.AutoSize = true;
            this.labelUpdateLink.Location = new System.Drawing.Point(6, 202);
            this.labelUpdateLink.Name = "labelUpdateLink";
            this.labelUpdateLink.Size = new System.Drawing.Size(431, 13);
            this.labelUpdateLink.TabIndex = 0;
            this.labelUpdateLink.Text = "Insert DLL Download Link (e.g. \"https://www.deltaconnected.com/arcdps/x64/d3d9.dl" +
    "l\")";
            // 
            // listBoxAddOns
            // 
            this.listBoxAddOns.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.listBoxAddOns.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.listBoxAddOns.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.listBoxAddOns.ForeColor = System.Drawing.Color.White;
            this.listBoxAddOns.FormattingEnabled = true;
            this.listBoxAddOns.ItemHeight = 16;
            this.listBoxAddOns.Location = new System.Drawing.Point(6, 29);
            this.listBoxAddOns.Name = "listBoxAddOns";
            this.listBoxAddOns.Size = new System.Drawing.Size(704, 162);
            this.listBoxAddOns.TabIndex = 15;
            this.listBoxAddOns.KeyDown += new System.Windows.Forms.KeyEventHandler(this.listboxAddOns_OnKeyDown);
            // 
            // checkBoxUpdateAddOns
            // 
            this.checkBoxUpdateAddOns.AutoSize = true;
            this.checkBoxUpdateAddOns.Location = new System.Drawing.Point(9, 9);
            this.checkBoxUpdateAddOns.Name = "checkBoxUpdateAddOns";
            this.checkBoxUpdateAddOns.Size = new System.Drawing.Size(168, 17);
            this.checkBoxUpdateAddOns.TabIndex = 14;
            this.checkBoxUpdateAddOns.Text = "Automatically update Add-Ons";
            this.checkBoxUpdateAddOns.UseVisualStyleBackColor = true;
            this.checkBoxUpdateAddOns.CheckedChanged += new System.EventHandler(this.checkBoxUpdateAddOns_CheckedChanged);
            // 
            // gL_GroupBoxGameDir
            // 
            this.gL_GroupBoxGameDir.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.gL_GroupBoxGameDir.BorderColor = System.Drawing.Color.Gray;
            this.gL_GroupBoxGameDir.BorderSize = 1;
            this.gL_GroupBoxGameDir.Controls.Add(this.buttonBrowseGameDirectory);
            this.gL_GroupBoxGameDir.Controls.Add(this.textBoxGameDirectory);
            this.gL_GroupBoxGameDir.Controls.Add(this.labelDirectory);
            this.gL_GroupBoxGameDir.Location = new System.Drawing.Point(12, 12);
            this.gL_GroupBoxGameDir.Name = "gL_GroupBoxGameDir";
            this.gL_GroupBoxGameDir.Size = new System.Drawing.Size(716, 47);
            this.gL_GroupBoxGameDir.TabIndex = 3;
            this.gL_GroupBoxGameDir.TabStop = false;
            this.gL_GroupBoxGameDir.Text = "gL_GroupBox2";
            // 
            // buttonBrowseGameDirectory
            // 
            this.buttonBrowseGameDirectory.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(185)))), ((int)(((byte)(13)))), ((int)(((byte)(10)))));
            this.buttonBrowseGameDirectory.FlatAppearance.BorderSize = 0;
            this.buttonBrowseGameDirectory.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonBrowseGameDirectory.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.buttonBrowseGameDirectory.ForeColor = System.Drawing.Color.White;
            this.buttonBrowseGameDirectory.Location = new System.Drawing.Point(610, 21);
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
            this.textBoxGameDirectory.Location = new System.Drawing.Point(6, 21);
            this.textBoxGameDirectory.Name = "textBoxGameDirectory";
            this.textBoxGameDirectory.Size = new System.Drawing.Size(598, 20);
            this.textBoxGameDirectory.TabIndex = 8;
            this.textBoxGameDirectory.TextChanged += new System.EventHandler(this.textBoxGameDirectory_TextChanged);
            // 
            // labelDirectory
            // 
            this.labelDirectory.AutoSize = true;
            this.labelDirectory.Location = new System.Drawing.Point(6, 6);
            this.labelDirectory.Name = "labelDirectory";
            this.labelDirectory.Size = new System.Drawing.Size(286, 13);
            this.labelDirectory.TabIndex = 0;
            this.labelDirectory.Text = "GW2 Directory (Normally: \"C:\\Program Files\\Guild Wars 2\")";
            // 
            // gL_GroupBoxLaunchBehavior
            // 
            this.gL_GroupBoxLaunchBehavior.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.gL_GroupBoxLaunchBehavior.BorderColor = System.Drawing.Color.Gray;
            this.gL_GroupBoxLaunchBehavior.BorderSize = 1;
            this.gL_GroupBoxLaunchBehavior.Controls.Add(this.radioButtonLaunchStayOpen);
            this.gL_GroupBoxLaunchBehavior.Controls.Add(this.radioButtonLaunchClose);
            this.gL_GroupBoxLaunchBehavior.Controls.Add(this.radioButtonLaunchMinimize);
            this.gL_GroupBoxLaunchBehavior.Controls.Add(this.labelLaunchBehavior);
            this.gL_GroupBoxLaunchBehavior.Location = new System.Drawing.Point(12, 65);
            this.gL_GroupBoxLaunchBehavior.Name = "gL_GroupBoxLaunchBehavior";
            this.gL_GroupBoxLaunchBehavior.Size = new System.Drawing.Size(278, 47);
            this.gL_GroupBoxLaunchBehavior.TabIndex = 0;
            this.gL_GroupBoxLaunchBehavior.TabStop = false;
            this.gL_GroupBoxLaunchBehavior.Text = "gL_GroupBox1";
            // 
            // radioButtonLaunchStayOpen
            // 
            this.radioButtonLaunchStayOpen.AutoSize = true;
            this.radioButtonLaunchStayOpen.Location = new System.Drawing.Point(9, 22);
            this.radioButtonLaunchStayOpen.Name = "radioButtonLaunchStayOpen";
            this.radioButtonLaunchStayOpen.Size = new System.Drawing.Size(71, 17);
            this.radioButtonLaunchStayOpen.TabIndex = 10;
            this.radioButtonLaunchStayOpen.TabStop = true;
            this.radioButtonLaunchStayOpen.Text = "stay open";
            this.radioButtonLaunchStayOpen.UseVisualStyleBackColor = true;
            this.radioButtonLaunchStayOpen.CheckedChanged += new System.EventHandler(this.radioButtonLaunchStayOpen_CheckedChanged);
            // 
            // radioButtonLaunchClose
            // 
            this.radioButtonLaunchClose.AutoSize = true;
            this.radioButtonLaunchClose.Location = new System.Drawing.Point(222, 22);
            this.radioButtonLaunchClose.Name = "radioButtonLaunchClose";
            this.radioButtonLaunchClose.Size = new System.Drawing.Size(50, 17);
            this.radioButtonLaunchClose.TabIndex = 12;
            this.radioButtonLaunchClose.TabStop = true;
            this.radioButtonLaunchClose.Text = "close";
            this.radioButtonLaunchClose.UseVisualStyleBackColor = true;
            this.radioButtonLaunchClose.CheckedChanged += new System.EventHandler(this.radioButtonLaunchClose_CheckedChanged);
            // 
            // radioButtonLaunchMinimize
            // 
            this.radioButtonLaunchMinimize.AutoSize = true;
            this.radioButtonLaunchMinimize.Location = new System.Drawing.Point(104, 22);
            this.radioButtonLaunchMinimize.Name = "radioButtonLaunchMinimize";
            this.radioButtonLaunchMinimize.Size = new System.Drawing.Size(96, 17);
            this.radioButtonLaunchMinimize.TabIndex = 11;
            this.radioButtonLaunchMinimize.TabStop = true;
            this.radioButtonLaunchMinimize.Text = "minimize to tray";
            this.radioButtonLaunchMinimize.UseVisualStyleBackColor = true;
            this.radioButtonLaunchMinimize.CheckedChanged += new System.EventHandler(this.radioButtonLaunchMinimize_CheckedChanged);
            // 
            // labelLaunchBehavior
            // 
            this.labelLaunchBehavior.AutoSize = true;
            this.labelLaunchBehavior.Location = new System.Drawing.Point(6, 6);
            this.labelLaunchBehavior.Name = "labelLaunchBehavior";
            this.labelLaunchBehavior.Size = new System.Drawing.Size(219, 13);
            this.labelLaunchBehavior.TabIndex = 0;
            this.labelLaunchBehavior.Text = "When GW2 launches, Guild Lounge should..";
            // 
            // UserControl_Settings
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(55)))), ((int)(((byte)(55)))), ((int)(((byte)(55)))));
            this.Controls.Add(this.gL_GroupBoxStartParams);
            this.Controls.Add(this.buttonRestore);
            this.Controls.Add(this.buttonSave);
            this.Controls.Add(this.gL_GroupBoxAddOns);
            this.Controls.Add(this.gL_GroupBoxGameDir);
            this.Controls.Add(this.gL_GroupBoxLaunchBehavior);
            this.ForeColor = System.Drawing.Color.White;
            this.Name = "UserControl_Settings";
            this.Size = new System.Drawing.Size(740, 436);
            this.gL_GroupBoxStartParams.ResumeLayout(false);
            this.gL_GroupBoxStartParams.PerformLayout();
            this.gL_GroupBoxAddOns.ResumeLayout(false);
            this.gL_GroupBoxAddOns.PerformLayout();
            this.gL_GroupBoxGameDir.ResumeLayout(false);
            this.gL_GroupBoxGameDir.PerformLayout();
            this.gL_GroupBoxLaunchBehavior.ResumeLayout(false);
            this.gL_GroupBoxLaunchBehavior.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private Control_GroupBox gL_GroupBoxLaunchBehavior;
        private System.Windows.Forms.Label labelLaunchBehavior;
        private System.Windows.Forms.RadioButton radioButtonLaunchStayOpen;
        private System.Windows.Forms.RadioButton radioButtonLaunchMinimize;
        private System.Windows.Forms.RadioButton radioButtonLaunchClose;
        private Control_GroupBox gL_GroupBoxGameDir;
        private System.Windows.Forms.TextBox textBoxGameDirectory;
        private System.Windows.Forms.Label labelDirectory;
        private Control_HighlightButton buttonBrowseGameDirectory;
        private Control_GroupBox gL_GroupBoxAddOns;
        private System.Windows.Forms.CheckBox checkBoxUpdateAddOns;
        private System.Windows.Forms.ListBox listBoxAddOns;
        private Control_HighlightButton buttonAddAddOn;
        private System.Windows.Forms.TextBox textBoxAddOnLink;
        private System.Windows.Forms.Label labelUpdateLink;
        private Control_HighlightButton buttonSave;
        private Control_HighlightButton buttonRestore;
        private System.Windows.Forms.Label labelError;
        private System.Windows.Forms.Label labelUpdateInfo;
        private Control_GroupBox gL_GroupBoxStartParams;
        private System.Windows.Forms.TextBox textBoxStartParams;
        private System.Windows.Forms.Label labelStartParams;
        private Control_HighlightButton buttonRemoveAddOn;
        private Control_HighlightButton buttonEditAddOn;
        private Control_HighlightButton buttonForceUpdate;
    }
}
