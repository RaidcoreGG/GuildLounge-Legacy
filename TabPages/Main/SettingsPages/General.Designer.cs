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
            this.gL_GroupBoxStartParams = new GuildLounge.Controls.GroupBox();
            this.textBoxStartParams = new System.Windows.Forms.TextBox();
            this.labelStartParams = new System.Windows.Forms.Label();
            this.gL_GroupBoxGameDir = new GuildLounge.Controls.GroupBox();
            this.buttonBrowseGameDirectory = new GuildLounge.Controls.HighlightButton();
            this.textBoxGameDirectory = new System.Windows.Forms.TextBox();
            this.labelDirectory = new System.Windows.Forms.Label();
            this.gL_GroupBoxLaunchBehavior = new GuildLounge.Controls.GroupBox();
            this.radioButtonLaunchStayOpen = new System.Windows.Forms.RadioButton();
            this.radioButtonLaunchClose = new System.Windows.Forms.RadioButton();
            this.radioButtonLaunchMinimize = new System.Windows.Forms.RadioButton();
            this.labelLaunchBehavior = new System.Windows.Forms.Label();
            this.gL_GroupBoxStartParams.SuspendLayout();
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
            this.gL_GroupBoxStartParams.Location = new System.Drawing.Point(12, 66);
            this.gL_GroupBoxStartParams.Name = "gL_GroupBoxStartParams";
            this.gL_GroupBoxStartParams.Size = new System.Drawing.Size(546, 48);
            this.gL_GroupBoxStartParams.TabIndex = 25;
            this.gL_GroupBoxStartParams.TabStop = false;
            this.gL_GroupBoxStartParams.Text = "gL_GroupBox4";
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
            this.gL_GroupBoxGameDir.Size = new System.Drawing.Size(546, 48);
            this.gL_GroupBoxGameDir.TabIndex = 24;
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
            this.buttonBrowseGameDirectory.Location = new System.Drawing.Point(440, 22);
            this.buttonBrowseGameDirectory.Name = "buttonBrowseGameDirectory";
            this.buttonBrowseGameDirectory.Size = new System.Drawing.Size(100, 20);
            this.buttonBrowseGameDirectory.TabIndex = 9;
            this.buttonBrowseGameDirectory.Text = "Browse";
            this.buttonBrowseGameDirectory.UseVisualStyleBackColor = false;
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
            // 
            // labelDirectory
            // 
            this.labelDirectory.AutoSize = true;
            this.labelDirectory.Location = new System.Drawing.Point(6, 6);
            this.labelDirectory.Name = "labelDirectory";
            this.labelDirectory.Size = new System.Drawing.Size(280, 13);
            this.labelDirectory.TabIndex = 0;
            this.labelDirectory.Text = "GW2 Directory (Usually: \"C:\\Program Files\\Guild Wars 2\")";
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
            this.gL_GroupBoxLaunchBehavior.Location = new System.Drawing.Point(12, 120);
            this.gL_GroupBoxLaunchBehavior.Name = "gL_GroupBoxLaunchBehavior";
            this.gL_GroupBoxLaunchBehavior.Size = new System.Drawing.Size(278, 47);
            this.gL_GroupBoxLaunchBehavior.TabIndex = 23;
            this.gL_GroupBoxLaunchBehavior.TabStop = false;
            this.gL_GroupBoxLaunchBehavior.Text = "gL_GroupBox1";
            // 
            // radioButtonLaunchStayOpen
            // 
            this.radioButtonLaunchStayOpen.AutoSize = true;
            this.radioButtonLaunchStayOpen.Location = new System.Drawing.Point(6, 22);
            this.radioButtonLaunchStayOpen.Name = "radioButtonLaunchStayOpen";
            this.radioButtonLaunchStayOpen.Size = new System.Drawing.Size(71, 17);
            this.radioButtonLaunchStayOpen.TabIndex = 10;
            this.radioButtonLaunchStayOpen.TabStop = true;
            this.radioButtonLaunchStayOpen.Text = "stay open";
            this.radioButtonLaunchStayOpen.UseVisualStyleBackColor = true;
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
            // General
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(55)))), ((int)(((byte)(55)))), ((int)(((byte)(55)))));
            this.Controls.Add(this.gL_GroupBoxStartParams);
            this.Controls.Add(this.gL_GroupBoxGameDir);
            this.Controls.Add(this.gL_GroupBoxLaunchBehavior);
            this.ForeColor = System.Drawing.Color.White;
            this.Name = "General";
            this.Size = new System.Drawing.Size(570, 436);
            this.gL_GroupBoxStartParams.ResumeLayout(false);
            this.gL_GroupBoxStartParams.PerformLayout();
            this.gL_GroupBoxGameDir.ResumeLayout(false);
            this.gL_GroupBoxGameDir.PerformLayout();
            this.gL_GroupBoxLaunchBehavior.ResumeLayout(false);
            this.gL_GroupBoxLaunchBehavior.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private Controls.GroupBox gL_GroupBoxStartParams;
        private System.Windows.Forms.TextBox textBoxStartParams;
        private System.Windows.Forms.Label labelStartParams;
        private Controls.GroupBox gL_GroupBoxGameDir;
        private Controls.HighlightButton buttonBrowseGameDirectory;
        private System.Windows.Forms.TextBox textBoxGameDirectory;
        private System.Windows.Forms.Label labelDirectory;
        private Controls.GroupBox gL_GroupBoxLaunchBehavior;
        private System.Windows.Forms.RadioButton radioButtonLaunchStayOpen;
        private System.Windows.Forms.RadioButton radioButtonLaunchClose;
        private System.Windows.Forms.RadioButton radioButtonLaunchMinimize;
        private System.Windows.Forms.Label labelLaunchBehavior;
    }
}
