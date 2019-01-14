namespace GuildLounge
{
    partial class UserControl_Dashboard
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
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.buttonNewsNext = new System.Windows.Forms.Button();
            this.buttonNewsPrevious = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.pictureBox1.BackgroundImage = global::GuildLounge.Properties.Resources.news_placeholder;
            this.pictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.pictureBox1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pictureBox1.Location = new System.Drawing.Point(98, 12);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(544, 164);
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // buttonNewsNext
            // 
            this.buttonNewsNext.BackColor = System.Drawing.Color.Transparent;
            this.buttonNewsNext.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.buttonNewsNext.FlatAppearance.BorderSize = 0;
            this.buttonNewsNext.FlatAppearance.CheckedBackColor = System.Drawing.Color.Transparent;
            this.buttonNewsNext.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.buttonNewsNext.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.buttonNewsNext.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonNewsNext.ForeColor = System.Drawing.Color.Gray;
            this.buttonNewsNext.Image = global::GuildLounge.Properties.Resources.ui_arrow_rt;
            this.buttonNewsNext.Location = new System.Drawing.Point(648, 12);
            this.buttonNewsNext.Name = "buttonNewsNext";
            this.buttonNewsNext.Size = new System.Drawing.Size(80, 164);
            this.buttonNewsNext.TabIndex = 15;
            this.buttonNewsNext.UseVisualStyleBackColor = false;
            // 
            // buttonNewsPrevious
            // 
            this.buttonNewsPrevious.BackColor = System.Drawing.Color.Transparent;
            this.buttonNewsPrevious.FlatAppearance.BorderSize = 0;
            this.buttonNewsPrevious.FlatAppearance.CheckedBackColor = System.Drawing.Color.Transparent;
            this.buttonNewsPrevious.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.buttonNewsPrevious.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.buttonNewsPrevious.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonNewsPrevious.ForeColor = System.Drawing.Color.Gray;
            this.buttonNewsPrevious.Image = global::GuildLounge.Properties.Resources.ui_arrow_lt;
            this.buttonNewsPrevious.Location = new System.Drawing.Point(12, 12);
            this.buttonNewsPrevious.Name = "buttonNewsPrevious";
            this.buttonNewsPrevious.Size = new System.Drawing.Size(80, 164);
            this.buttonNewsPrevious.TabIndex = 14;
            this.buttonNewsPrevious.UseVisualStyleBackColor = false;
            // 
            // UserControl_Dashboard
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(55)))), ((int)(((byte)(55)))), ((int)(((byte)(55)))));
            this.Controls.Add(this.buttonNewsNext);
            this.Controls.Add(this.buttonNewsPrevious);
            this.Controls.Add(this.pictureBox1);
            this.ForeColor = System.Drawing.Color.White;
            this.Name = "UserControl_Dashboard";
            this.Size = new System.Drawing.Size(740, 436);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button buttonNewsPrevious;
        private System.Windows.Forms.Button buttonNewsNext;
    }
}
