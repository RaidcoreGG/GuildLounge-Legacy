﻿namespace GuildLounge.TabPages
{
    partial class Guides
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
            this.labelGuides = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // labelGuides
            // 
            this.labelGuides.AutoSize = true;
            this.labelGuides.Location = new System.Drawing.Point(12, 12);
            this.labelGuides.Name = "labelGuides";
            this.labelGuides.Size = new System.Drawing.Size(112, 13);
            this.labelGuides.TabIndex = 10;
            this.labelGuides.Text = "Guides coming soon...";
            // 
            // UserControl_Guides
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(55)))), ((int)(((byte)(55)))), ((int)(((byte)(55)))));
            this.Controls.Add(this.labelGuides);
            this.ForeColor = System.Drawing.Color.White;
            this.Name = "UserControl_Guides";
            this.Size = new System.Drawing.Size(740, 436);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label labelGuides;
    }
}
