namespace GuildLounge
{
    partial class UserControl_APIKeys
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
            this.listBoxAPIKeys = new System.Windows.Forms.ListBox();
            this.textBoxKey = new System.Windows.Forms.TextBox();
            this.textBoxKeyName = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.labelError = new System.Windows.Forms.Label();
            this.buttonEditKey = new GuildLounge.GL_HighlightButton();
            this.buttonAddKey = new GuildLounge.GL_HighlightButton();
            this.buttonRemoveKey = new GuildLounge.GL_HighlightButton();
            this.SuspendLayout();
            // 
            // listBoxAPIKeys
            // 
            this.listBoxAPIKeys.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.listBoxAPIKeys.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.listBoxAPIKeys.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.listBoxAPIKeys.ForeColor = System.Drawing.Color.White;
            this.listBoxAPIKeys.FormattingEnabled = true;
            this.listBoxAPIKeys.ItemHeight = 16;
            this.listBoxAPIKeys.Location = new System.Drawing.Point(12, 12);
            this.listBoxAPIKeys.Name = "listBoxAPIKeys";
            this.listBoxAPIKeys.Size = new System.Drawing.Size(716, 306);
            this.listBoxAPIKeys.TabIndex = 12;
            this.listBoxAPIKeys.KeyDown += new System.Windows.Forms.KeyEventHandler(this.listBoxAPIKeys_KeyDown);
            // 
            // textBoxKey
            // 
            this.textBoxKey.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.textBoxKey.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textBoxKey.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.textBoxKey.ForeColor = System.Drawing.Color.White;
            this.textBoxKey.Location = new System.Drawing.Point(68, 359);
            this.textBoxKey.Name = "textBoxKey";
            this.textBoxKey.Size = new System.Drawing.Size(660, 26);
            this.textBoxKey.TabIndex = 13;
            // 
            // textBoxKeyName
            // 
            this.textBoxKeyName.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.textBoxKeyName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textBoxKeyName.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.textBoxKeyName.ForeColor = System.Drawing.Color.White;
            this.textBoxKeyName.Location = new System.Drawing.Point(68, 327);
            this.textBoxKeyName.Name = "textBoxKeyName";
            this.textBoxKeyName.Size = new System.Drawing.Size(660, 26);
            this.textBoxKeyName.TabIndex = 15;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.label1.Location = new System.Drawing.Point(9, 329);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(55, 20);
            this.label1.TabIndex = 16;
            this.label1.Text = "Name:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.label2.Location = new System.Drawing.Point(9, 361);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(39, 20);
            this.label2.TabIndex = 17;
            this.label2.Text = "Key:";
            // 
            // labelError
            // 
            this.labelError.AutoSize = true;
            this.labelError.Location = new System.Drawing.Point(65, 388);
            this.labelError.Name = "labelError";
            this.labelError.Size = new System.Drawing.Size(52, 13);
            this.labelError.TabIndex = 18;
            this.labelError.Text = "[ERROR]";
            this.labelError.Visible = false;
            // 
            // buttonEditKey
            // 
            this.buttonEditKey.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(185)))), ((int)(((byte)(13)))), ((int)(((byte)(10)))));
            this.buttonEditKey.FlatAppearance.BorderSize = 0;
            this.buttonEditKey.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonEditKey.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.buttonEditKey.ForeColor = System.Drawing.Color.White;
            this.buttonEditKey.Location = new System.Drawing.Point(522, 394);
            this.buttonEditKey.Name = "buttonEditKey";
            this.buttonEditKey.Size = new System.Drawing.Size(100, 30);
            this.buttonEditKey.TabIndex = 20;
            this.buttonEditKey.Text = "Edit";
            this.buttonEditKey.UseVisualStyleBackColor = false;
            this.buttonEditKey.Click += new System.EventHandler(this.buttonEditKey_Click);
            // 
            // buttonAddKey
            // 
            this.buttonAddKey.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(185)))), ((int)(((byte)(13)))), ((int)(((byte)(10)))));
            this.buttonAddKey.FlatAppearance.BorderSize = 0;
            this.buttonAddKey.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonAddKey.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.buttonAddKey.ForeColor = System.Drawing.Color.White;
            this.buttonAddKey.Location = new System.Drawing.Point(628, 394);
            this.buttonAddKey.Name = "buttonAddKey";
            this.buttonAddKey.Size = new System.Drawing.Size(100, 30);
            this.buttonAddKey.TabIndex = 19;
            this.buttonAddKey.Text = "Add";
            this.buttonAddKey.UseVisualStyleBackColor = false;
            this.buttonAddKey.Click += new System.EventHandler(this.buttonAddKey_Click);
            // 
            // buttonRemoveKey
            // 
            this.buttonRemoveKey.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(185)))), ((int)(((byte)(13)))), ((int)(((byte)(10)))));
            this.buttonRemoveKey.FlatAppearance.BorderSize = 0;
            this.buttonRemoveKey.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonRemoveKey.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.buttonRemoveKey.ForeColor = System.Drawing.Color.White;
            this.buttonRemoveKey.Location = new System.Drawing.Point(416, 394);
            this.buttonRemoveKey.Name = "buttonRemoveKey";
            this.buttonRemoveKey.Size = new System.Drawing.Size(100, 30);
            this.buttonRemoveKey.TabIndex = 21;
            this.buttonRemoveKey.Text = "Remove";
            this.buttonRemoveKey.UseVisualStyleBackColor = false;
            this.buttonRemoveKey.Click += new System.EventHandler(this.buttonRemoveKey_Click);
            // 
            // UserControl_APIKeys
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(55)))), ((int)(((byte)(55)))), ((int)(((byte)(55)))));
            this.Controls.Add(this.buttonRemoveKey);
            this.Controls.Add(this.buttonEditKey);
            this.Controls.Add(this.buttonAddKey);
            this.Controls.Add(this.labelError);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.textBoxKeyName);
            this.Controls.Add(this.textBoxKey);
            this.Controls.Add(this.listBoxAPIKeys);
            this.ForeColor = System.Drawing.Color.White;
            this.Name = "UserControl_APIKeys";
            this.Size = new System.Drawing.Size(740, 436);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox listBoxAPIKeys;
        private System.Windows.Forms.TextBox textBoxKey;
        private System.Windows.Forms.TextBox textBoxKeyName;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label labelError;
        private GL_HighlightButton buttonAddKey;
        private GL_HighlightButton buttonEditKey;
        private GL_HighlightButton buttonRemoveKey;
    }
}
