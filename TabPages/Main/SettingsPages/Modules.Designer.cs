namespace GuildLounge.TabPages.SettingsPages
{
    partial class Modules
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.listBoxActive = new System.Windows.Forms.ListBox();
            this.listBoxInactive = new System.Windows.Forms.ListBox();
            this.label4 = new System.Windows.Forms.Label();
            this.linkLabelGLDiscord = new System.Windows.Forms.LinkLabel();
            this.label5 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.buttonMoveToInactive = new GuildLounge.Controls.Button();
            this.buttonMoveToActive = new GuildLounge.Controls.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 12);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(83, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Active Modules:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(359, 12);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(91, 13);
            this.label2.TabIndex = 0;
            this.label2.Text = "Inactive Modules:";
            // 
            // listBoxActive
            // 
            this.listBoxActive.AllowDrop = true;
            this.listBoxActive.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.listBoxActive.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.listBoxActive.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.listBoxActive.ForeColor = System.Drawing.Color.White;
            this.listBoxActive.FormattingEnabled = true;
            this.listBoxActive.ItemHeight = 16;
            this.listBoxActive.Location = new System.Drawing.Point(16, 28);
            this.listBoxActive.Name = "listBoxActive";
            this.listBoxActive.Size = new System.Drawing.Size(192, 194);
            this.listBoxActive.TabIndex = 1;
            this.listBoxActive.DragDrop += new System.Windows.Forms.DragEventHandler(this.listBoxActive_DragDrop);
            this.listBoxActive.DragOver += new System.Windows.Forms.DragEventHandler(this.listBoxActive_DragOver);
            this.listBoxActive.MouseDown += new System.Windows.Forms.MouseEventHandler(this.listBoxActive_MouseDown);
            // 
            // listBoxInactive
            // 
            this.listBoxInactive.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.listBoxInactive.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.listBoxInactive.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.listBoxInactive.ForeColor = System.Drawing.Color.White;
            this.listBoxInactive.FormattingEnabled = true;
            this.listBoxInactive.ItemHeight = 16;
            this.listBoxInactive.Location = new System.Drawing.Point(362, 28);
            this.listBoxInactive.Name = "listBoxInactive";
            this.listBoxInactive.Size = new System.Drawing.Size(192, 194);
            this.listBoxInactive.TabIndex = 4;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(13, 275);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(348, 13);
            this.label4.TabIndex = 0;
            this.label4.Text = "If you have any ideas for more Modules, you can submit them to me over";
            // 
            // linkLabelGLDiscord
            // 
            this.linkLabelGLDiscord.ActiveLinkColor = System.Drawing.Color.OrangeRed;
            this.linkLabelGLDiscord.AutoSize = true;
            this.linkLabelGLDiscord.LinkBehavior = System.Windows.Forms.LinkBehavior.NeverUnderline;
            this.linkLabelGLDiscord.LinkColor = System.Drawing.Color.Red;
            this.linkLabelGLDiscord.Location = new System.Drawing.Point(359, 275);
            this.linkLabelGLDiscord.Name = "linkLabelGLDiscord";
            this.linkLabelGLDiscord.Size = new System.Drawing.Size(46, 13);
            this.linkLabelGLDiscord.TabIndex = 5;
            this.linkLabelGLDiscord.TabStop = true;
            this.linkLabelGLDiscord.Text = "Discord.";
            this.linkLabelGLDiscord.VisitedLinkColor = System.Drawing.Color.OrangeRed;
            this.linkLabelGLDiscord.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabelGLDiscord_LinkClicked);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(13, 294);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(342, 13);
            this.label5.TabIndex = 0;
            this.label5.Text = "If there\'s enough interest, they will soon be added with the next update!";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(13, 241);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(273, 13);
            this.label3.TabIndex = 0;
            this.label3.Text = "Tip: You can change the order by dragging the modules.";
            // 
            // buttonMoveToInactive
            // 
            this.buttonMoveToInactive.BackgroundImage = global::GuildLounge.Properties.Resources.ui_arrow_rt;
            this.buttonMoveToInactive.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.buttonMoveToInactive.FlatAppearance.BorderSize = 0;
            this.buttonMoveToInactive.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonMoveToInactive.Location = new System.Drawing.Point(273, 130);
            this.buttonMoveToInactive.Name = "buttonMoveToInactive";
            this.buttonMoveToInactive.Size = new System.Drawing.Size(24, 24);
            this.buttonMoveToInactive.TabIndex = 3;
            this.buttonMoveToInactive.UseVisualStyleBackColor = false;
            this.buttonMoveToInactive.Click += new System.EventHandler(this.buttonMoveToInactive_Click);
            // 
            // buttonMoveToActive
            // 
            this.buttonMoveToActive.BackgroundImage = global::GuildLounge.Properties.Resources.ui_arrow_lt;
            this.buttonMoveToActive.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.buttonMoveToActive.FlatAppearance.BorderSize = 0;
            this.buttonMoveToActive.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonMoveToActive.Location = new System.Drawing.Point(273, 100);
            this.buttonMoveToActive.Name = "buttonMoveToActive";
            this.buttonMoveToActive.Size = new System.Drawing.Size(24, 24);
            this.buttonMoveToActive.TabIndex = 2;
            this.buttonMoveToActive.UseVisualStyleBackColor = false;
            this.buttonMoveToActive.Click += new System.EventHandler(this.buttonMoveToActive_Click);
            // 
            // Modules
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(55)))), ((int)(((byte)(55)))), ((int)(((byte)(55)))));
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.linkLabelGLDiscord);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.buttonMoveToInactive);
            this.Controls.Add(this.buttonMoveToActive);
            this.Controls.Add(this.listBoxInactive);
            this.Controls.Add(this.listBoxActive);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.ForeColor = System.Drawing.Color.White;
            this.Name = "Modules";
            this.Size = new System.Drawing.Size(570, 436);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ListBox listBoxActive;
        private System.Windows.Forms.ListBox listBoxInactive;
        private Controls.Button buttonMoveToActive;
        private Controls.Button buttonMoveToInactive;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.LinkLabel linkLabelGLDiscord;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label3;
    }
}
