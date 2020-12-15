namespace GuildLounge.TabPages.Popups
{
    partial class UpdateNotification
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
            this.label3 = new System.Windows.Forms.Label();
            this.linkLabelDPSReportTokenHelp = new System.Windows.Forms.LinkLabel();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.labelNote = new System.Windows.Forms.Label();
            this.buttonNo = new GuildLounge.Controls.HighlightButton();
            this.buttonYes = new GuildLounge.Controls.HighlightButton();
            this.SuspendLayout();
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 62);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(186, 13);
            this.label3.TabIndex = 0;
            this.label3.Text = "You can read the full release notes at:";
            // 
            // linkLabelDPSReportTokenHelp
            // 
            this.linkLabelDPSReportTokenHelp.ActiveLinkColor = System.Drawing.Color.OrangeRed;
            this.linkLabelDPSReportTokenHelp.AutoSize = true;
            this.linkLabelDPSReportTokenHelp.LinkColor = System.Drawing.Color.Red;
            this.linkLabelDPSReportTokenHelp.Location = new System.Drawing.Point(12, 87);
            this.linkLabelDPSReportTokenHelp.Name = "linkLabelDPSReportTokenHelp";
            this.linkLabelDPSReportTokenHelp.Size = new System.Drawing.Size(111, 13);
            this.linkLabelDPSReportTokenHelp.TabIndex = 31;
            this.linkLabelDPSReportTokenHelp.TabStop = true;
            this.linkLabelDPSReportTokenHelp.Text = "www.guildlounge.com";
            this.linkLabelDPSReportTokenHelp.VisitedLinkColor = System.Drawing.Color.OrangeRed;
            this.linkLabelDPSReportTokenHelp.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabelDPSReportTokenHelp_LinkClicked);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 12);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(168, 13);
            this.label1.TabIndex = 32;
            this.label1.Text = "There\'s a newer version available!";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 37);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(65, 13);
            this.label2.TabIndex = 33;
            this.label2.Text = "Update info:";
            // 
            // labelNote
            // 
            this.labelNote.AutoSize = true;
            this.labelNote.Location = new System.Drawing.Point(83, 37);
            this.labelNote.Name = "labelNote";
            this.labelNote.Size = new System.Drawing.Size(24, 13);
            this.labelNote.TabIndex = 34;
            this.labelNote.Text = "n/a";
            // 
            // buttonNo
            // 
            this.buttonNo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(185)))), ((int)(((byte)(13)))), ((int)(((byte)(10)))));
            this.buttonNo.FlatAppearance.BorderSize = 0;
            this.buttonNo.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonNo.ForeColor = System.Drawing.Color.White;
            this.buttonNo.Location = new System.Drawing.Point(134, 128);
            this.buttonNo.Name = "buttonNo";
            this.buttonNo.Size = new System.Drawing.Size(64, 23);
            this.buttonNo.TabIndex = 36;
            this.buttonNo.Text = "No";
            this.buttonNo.UseVisualStyleBackColor = false;
            this.buttonNo.Click += new System.EventHandler(this.buttonNo_Click);
            // 
            // buttonYes
            // 
            this.buttonYes.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(185)))), ((int)(((byte)(13)))), ((int)(((byte)(10)))));
            this.buttonYes.FlatAppearance.BorderSize = 0;
            this.buttonYes.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonYes.ForeColor = System.Drawing.Color.White;
            this.buttonYes.Location = new System.Drawing.Point(64, 128);
            this.buttonYes.Name = "buttonYes";
            this.buttonYes.Size = new System.Drawing.Size(64, 23);
            this.buttonYes.TabIndex = 37;
            this.buttonYes.Text = "Yes";
            this.buttonYes.UseVisualStyleBackColor = false;
            this.buttonYes.Click += new System.EventHandler(this.buttonYes_Click);
            // 
            // UpdateNotification
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(55)))), ((int)(((byte)(55)))), ((int)(((byte)(55)))));
            this.ClientSize = new System.Drawing.Size(210, 163);
            this.Controls.Add(this.buttonYes);
            this.Controls.Add(this.buttonNo);
            this.Controls.Add(this.labelNote);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.linkLabelDPSReportTokenHelp);
            this.Controls.Add(this.label3);
            this.ForeColor = System.Drawing.Color.White;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "UpdateNotification";
            this.Text = "Guild Lounge Updater";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.LinkLabel linkLabelDPSReportTokenHelp;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label labelNote;
        private Controls.HighlightButton buttonNo;
        private Controls.HighlightButton buttonYes;
    }
}