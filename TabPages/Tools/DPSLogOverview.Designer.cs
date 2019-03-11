namespace GuildLounge.TabPages.Tools
{
    partial class DPSLogOverview
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
            this.listBoxEncounters = new System.Windows.Forms.ListBox();
            this.listBoxLogs = new System.Windows.Forms.ListBox();
            this.buttonRefresh = new GuildLounge.Controls.HighlightButton();
            this.buttonExport = new GuildLounge.Controls.HighlightButton();
            this.buttonOpenFolder = new GuildLounge.Controls.HighlightButton();
            this.SuspendLayout();
            // 
            // listBoxEncounters
            // 
            this.listBoxEncounters.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.listBoxEncounters.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.listBoxEncounters.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.listBoxEncounters.ForeColor = System.Drawing.Color.White;
            this.listBoxEncounters.FormattingEnabled = true;
            this.listBoxEncounters.ItemHeight = 16;
            this.listBoxEncounters.Location = new System.Drawing.Point(12, 12);
            this.listBoxEncounters.Name = "listBoxEncounters";
            this.listBoxEncounters.Size = new System.Drawing.Size(355, 370);
            this.listBoxEncounters.TabIndex = 16;
            this.listBoxEncounters.SelectedIndexChanged += new System.EventHandler(this.listBoxEncounters_SelectedIndexChanged);
            // 
            // listBoxLogs
            // 
            this.listBoxLogs.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.listBoxLogs.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.listBoxLogs.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.listBoxLogs.ForeColor = System.Drawing.Color.White;
            this.listBoxLogs.FormattingEnabled = true;
            this.listBoxLogs.ItemHeight = 16;
            this.listBoxLogs.Location = new System.Drawing.Point(373, 12);
            this.listBoxLogs.Name = "listBoxLogs";
            this.listBoxLogs.Size = new System.Drawing.Size(355, 370);
            this.listBoxLogs.TabIndex = 17;
            // 
            // buttonRefresh
            // 
            this.buttonRefresh.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(185)))), ((int)(((byte)(13)))), ((int)(((byte)(10)))));
            this.buttonRefresh.FlatAppearance.BorderSize = 0;
            this.buttonRefresh.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonRefresh.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.buttonRefresh.ForeColor = System.Drawing.Color.White;
            this.buttonRefresh.Location = new System.Drawing.Point(118, 404);
            this.buttonRefresh.Name = "buttonRefresh";
            this.buttonRefresh.Size = new System.Drawing.Size(100, 20);
            this.buttonRefresh.TabIndex = 20;
            this.buttonRefresh.Text = "Refresh";
            this.buttonRefresh.UseVisualStyleBackColor = false;
            this.buttonRefresh.Click += new System.EventHandler(this.buttonRefresh_Click);
            // 
            // buttonExport
            // 
            this.buttonExport.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(185)))), ((int)(((byte)(13)))), ((int)(((byte)(10)))));
            this.buttonExport.FlatAppearance.BorderSize = 0;
            this.buttonExport.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonExport.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.buttonExport.ForeColor = System.Drawing.Color.White;
            this.buttonExport.Location = new System.Drawing.Point(628, 404);
            this.buttonExport.Name = "buttonExport";
            this.buttonExport.Size = new System.Drawing.Size(100, 20);
            this.buttonExport.TabIndex = 19;
            this.buttonExport.Text = "Export";
            this.buttonExport.UseVisualStyleBackColor = false;
            this.buttonExport.Click += new System.EventHandler(this.buttonExport_Click);
            // 
            // buttonOpenFolder
            // 
            this.buttonOpenFolder.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(185)))), ((int)(((byte)(13)))), ((int)(((byte)(10)))));
            this.buttonOpenFolder.FlatAppearance.BorderSize = 0;
            this.buttonOpenFolder.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonOpenFolder.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.buttonOpenFolder.ForeColor = System.Drawing.Color.White;
            this.buttonOpenFolder.Location = new System.Drawing.Point(12, 404);
            this.buttonOpenFolder.Name = "buttonOpenFolder";
            this.buttonOpenFolder.Size = new System.Drawing.Size(100, 20);
            this.buttonOpenFolder.TabIndex = 18;
            this.buttonOpenFolder.Text = "Open Folder";
            this.buttonOpenFolder.UseVisualStyleBackColor = false;
            this.buttonOpenFolder.Click += new System.EventHandler(this.buttonOpenFolder_Click);
            // 
            // DPSLogOverview
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(55)))), ((int)(((byte)(55)))), ((int)(((byte)(55)))));
            this.Controls.Add(this.buttonRefresh);
            this.Controls.Add(this.buttonExport);
            this.Controls.Add(this.buttonOpenFolder);
            this.Controls.Add(this.listBoxLogs);
            this.Controls.Add(this.listBoxEncounters);
            this.ForeColor = System.Drawing.Color.White;
            this.Name = "DPSLogOverview";
            this.Size = new System.Drawing.Size(740, 436);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListBox listBoxEncounters;
        private System.Windows.Forms.ListBox listBoxLogs;
        private Controls.HighlightButton buttonOpenFolder;
        private Controls.HighlightButton buttonExport;
        private Controls.HighlightButton buttonRefresh;
    }
}
