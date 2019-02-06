namespace GuildLounge
{
    partial class TabPage_LFG
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
            this.labelLFG = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // labelLFG
            // 
            this.labelLFG.AutoSize = true;
            this.labelLFG.Location = new System.Drawing.Point(12, 12);
            this.labelLFG.Name = "labelLFG";
            this.labelLFG.Size = new System.Drawing.Size(99, 13);
            this.labelLFG.TabIndex = 8;
            this.labelLFG.Text = "LFG coming soon...";
            // 
            // UserControl_LFG
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(55)))), ((int)(((byte)(55)))), ((int)(((byte)(55)))));
            this.Controls.Add(this.labelLFG);
            this.ForeColor = System.Drawing.Color.White;
            this.Name = "UserControl_LFG";
            this.Size = new System.Drawing.Size(740, 436);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label labelLFG;
    }
}
