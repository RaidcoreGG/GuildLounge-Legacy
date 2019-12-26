namespace GuildLounge.Controls
{
    partial class ExtensionItem
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
            this.pictureBoxIsMain = new System.Windows.Forms.PictureBox();
            this.pictureBoxIsUpdating = new System.Windows.Forms.PictureBox();
            this.statePanelUpToDate = new GuildLounge.Controls.StatePanel();
            this.labelLastUpdated = new System.Windows.Forms.Label();
            this.labelName = new System.Windows.Forms.Label();
            this.groupBoxContainer.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxIsMain)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxIsUpdating)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBoxContainer
            // 
            this.groupBoxContainer.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.groupBoxContainer.BorderColor = System.Drawing.Color.Gray;
            this.groupBoxContainer.BorderSize = 1;
            this.groupBoxContainer.Controls.Add(this.pictureBoxIsMain);
            this.groupBoxContainer.Controls.Add(this.pictureBoxIsUpdating);
            this.groupBoxContainer.Controls.Add(this.statePanelUpToDate);
            this.groupBoxContainer.Controls.Add(this.labelLastUpdated);
            this.groupBoxContainer.Controls.Add(this.labelName);
            this.groupBoxContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBoxContainer.ForeColor = System.Drawing.Color.White;
            this.groupBoxContainer.Location = new System.Drawing.Point(0, 0);
            this.groupBoxContainer.Name = "groupBoxContainer";
            this.groupBoxContainer.Size = new System.Drawing.Size(512, 32);
            this.groupBoxContainer.TabIndex = 0;
            this.groupBoxContainer.TabStop = false;
            this.groupBoxContainer.Text = "groupBox1";
            // 
            // pictureBoxIsMain
            // 
            this.pictureBoxIsMain.Location = new System.Drawing.Point(431, 1);
            this.pictureBoxIsMain.Name = "pictureBoxIsMain";
            this.pictureBoxIsMain.Size = new System.Drawing.Size(32, 30);
            this.pictureBoxIsMain.TabIndex = 5;
            this.pictureBoxIsMain.TabStop = false;
            // 
            // pictureBoxIsUpdating
            // 
            this.pictureBoxIsUpdating.Location = new System.Drawing.Point(463, 1);
            this.pictureBoxIsUpdating.Name = "pictureBoxIsUpdating";
            this.pictureBoxIsUpdating.Size = new System.Drawing.Size(32, 30);
            this.pictureBoxIsUpdating.TabIndex = 4;
            this.pictureBoxIsUpdating.TabStop = false;
            // 
            // statePanelUpToDate
            // 
            this.statePanelUpToDate.Active = false;
            this.statePanelUpToDate.Location = new System.Drawing.Point(496, 1);
            this.statePanelUpToDate.Name = "statePanelUpToDate";
            this.statePanelUpToDate.Size = new System.Drawing.Size(15, 30);
            this.statePanelUpToDate.TabIndex = 3;
            // 
            // labelLastUpdated
            // 
            this.labelLastUpdated.AutoSize = true;
            this.labelLastUpdated.Location = new System.Drawing.Point(192, 10);
            this.labelLastUpdated.Name = "labelLastUpdated";
            this.labelLastUpdated.Size = new System.Drawing.Size(98, 13);
            this.labelLastUpdated.TabIndex = 2;
            this.labelLastUpdated.Text = "[LAST_UPDATED]";
            // 
            // labelName
            // 
            this.labelName.AutoSize = true;
            this.labelName.Location = new System.Drawing.Point(6, 10);
            this.labelName.Name = "labelName";
            this.labelName.Size = new System.Drawing.Size(112, 13);
            this.labelName.TabIndex = 0;
            this.labelName.Text = "[EXTENSION_NAME]";
            // 
            // ExtensionItem
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(55)))), ((int)(((byte)(55)))), ((int)(((byte)(55)))));
            this.Controls.Add(this.groupBoxContainer);
            this.ForeColor = System.Drawing.Color.White;
            this.Name = "ExtensionItem";
            this.Size = new System.Drawing.Size(512, 32);
            this.groupBoxContainer.ResumeLayout(false);
            this.groupBoxContainer.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxIsMain)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxIsUpdating)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private GroupBox groupBoxContainer;
        private System.Windows.Forms.Label labelLastUpdated;
        private System.Windows.Forms.Label labelName;
        private System.Windows.Forms.PictureBox pictureBoxIsUpdating;
        private StatePanel statePanelUpToDate;
        private System.Windows.Forms.PictureBox pictureBoxIsMain;
    }
}
