namespace GuildLounge.TabPages.Popups
{
    partial class UserTokenHelp
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UserTokenHelp));
            this.label2 = new System.Windows.Forms.Label();
            this.linkLabelDPSReportTokenHelp = new System.Windows.Forms.LinkLabel();
            this.label1 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.label4 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 89);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(65, 13);
            this.label2.TabIndex = 0;
            this.label2.Text = "Navigate to:";
            // 
            // linkLabelDPSReportTokenHelp
            // 
            this.linkLabelDPSReportTokenHelp.ActiveLinkColor = System.Drawing.Color.OrangeRed;
            this.linkLabelDPSReportTokenHelp.AutoSize = true;
            this.linkLabelDPSReportTokenHelp.LinkColor = System.Drawing.Color.Red;
            this.linkLabelDPSReportTokenHelp.Location = new System.Drawing.Point(83, 89);
            this.linkLabelDPSReportTokenHelp.Name = "linkLabelDPSReportTokenHelp";
            this.linkLabelDPSReportTokenHelp.Size = new System.Drawing.Size(127, 13);
            this.linkLabelDPSReportTokenHelp.TabIndex = 31;
            this.linkLabelDPSReportTokenHelp.TabStop = true;
            this.linkLabelDPSReportTokenHelp.Text = "dps.report/getUserToken";
            this.linkLabelDPSReportTokenHelp.VisitedLinkColor = System.Drawing.Color.OrangeRed;
            this.linkLabelDPSReportTokenHelp.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabelDPSReportTokenHelp_LinkClicked);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 12);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(312, 65);
            this.label1.TabIndex = 32;
            this.label1.Text = resources.GetString("label1.Text");
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 113);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(212, 13);
            this.label3.TabIndex = 33;
            this.label3.Text = "Copy the text between the quotation marks:";
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackgroundImage = global::GuildLounge.Properties.Resources.help_DPSReportToken;
            this.pictureBox1.Location = new System.Drawing.Point(15, 129);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(360, 64);
            this.pictureBox1.TabIndex = 34;
            this.pictureBox1.TabStop = false;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 208);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(336, 13);
            this.label4.TabIndex = 35;
            this.label4.Text = "Paste the token into the textbox in the Guild Lounge General Settings!";
            // 
            // DPSReportUserToken
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(55)))), ((int)(((byte)(55)))), ((int)(((byte)(55)))));
            this.ClientSize = new System.Drawing.Size(390, 235);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.linkLabelDPSReportTokenHelp);
            this.Controls.Add(this.label2);
            this.ForeColor = System.Drawing.Color.White;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "DPSReportUserToken";
            this.Text = "Help: dps.report User Token";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.LinkLabel linkLabelDPSReportTokenHelp;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label4;
    }
}