namespace GuildLounge
{
    partial class ModuleBaseCurrencies
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
            this.labelBaseCurrencies = new System.Windows.Forms.Label();
            this.groupBoxBaseCurrencies = new GuildLounge.GL_GroupBox();
            this.pictureBoxKarma = new System.Windows.Forms.PictureBox();
            this.labelSilver = new System.Windows.Forms.Label();
            this.pictureBoxSilver = new System.Windows.Forms.PictureBox();
            this.labelCopper = new System.Windows.Forms.Label();
            this.pictureBoxCopper = new System.Windows.Forms.PictureBox();
            this.labelGold = new System.Windows.Forms.Label();
            this.pictureBoxGold = new System.Windows.Forms.PictureBox();
            this.pictureBoxBaseCurrencies = new System.Windows.Forms.PictureBox();
            this.labelKarma = new System.Windows.Forms.Label();
            this.groupBoxBaseCurrencies.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxKarma)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxSilver)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxCopper)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxGold)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxBaseCurrencies)).BeginInit();
            this.SuspendLayout();
            // 
            // labelBaseCurrencies
            // 
            this.labelBaseCurrencies.AutoSize = true;
            this.labelBaseCurrencies.BackColor = System.Drawing.Color.Transparent;
            this.labelBaseCurrencies.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.labelBaseCurrencies.Location = new System.Drawing.Point(30, 2);
            this.labelBaseCurrencies.Name = "labelBaseCurrencies";
            this.labelBaseCurrencies.Size = new System.Drawing.Size(53, 20);
            this.labelBaseCurrencies.TabIndex = 22;
            this.labelBaseCurrencies.Text = "Wallet";
            // 
            // groupBoxBaseCurrencies
            // 
            this.groupBoxBaseCurrencies.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.groupBoxBaseCurrencies.BorderColor = System.Drawing.Color.Gray;
            this.groupBoxBaseCurrencies.BorderSize = 1;
            this.groupBoxBaseCurrencies.Controls.Add(this.labelKarma);
            this.groupBoxBaseCurrencies.Controls.Add(this.pictureBoxKarma);
            this.groupBoxBaseCurrencies.Controls.Add(this.labelSilver);
            this.groupBoxBaseCurrencies.Controls.Add(this.pictureBoxSilver);
            this.groupBoxBaseCurrencies.Controls.Add(this.labelCopper);
            this.groupBoxBaseCurrencies.Controls.Add(this.pictureBoxCopper);
            this.groupBoxBaseCurrencies.Controls.Add(this.labelGold);
            this.groupBoxBaseCurrencies.Controls.Add(this.pictureBoxGold);
            this.groupBoxBaseCurrencies.ForeColor = System.Drawing.Color.White;
            this.groupBoxBaseCurrencies.Location = new System.Drawing.Point(0, 30);
            this.groupBoxBaseCurrencies.Name = "groupBoxBaseCurrencies";
            this.groupBoxBaseCurrencies.Size = new System.Drawing.Size(196, 64);
            this.groupBoxBaseCurrencies.TabIndex = 20;
            this.groupBoxBaseCurrencies.TabStop = false;
            // 
            // pictureBoxKarma
            // 
            this.pictureBoxKarma.BackColor = System.Drawing.Color.Transparent;
            this.pictureBoxKarma.BackgroundImage = global::GuildLounge.Properties.Resources.icon_karma;
            this.pictureBoxKarma.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pictureBoxKarma.Location = new System.Drawing.Point(6, 35);
            this.pictureBoxKarma.Name = "pictureBoxKarma";
            this.pictureBoxKarma.Size = new System.Drawing.Size(24, 24);
            this.pictureBoxKarma.TabIndex = 15;
            this.pictureBoxKarma.TabStop = false;
            // 
            // labelSilver
            // 
            this.labelSilver.AutoSize = true;
            this.labelSilver.BackColor = System.Drawing.Color.Transparent;
            this.labelSilver.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.labelSilver.Location = new System.Drawing.Point(109, 8);
            this.labelSilver.Name = "labelSilver";
            this.labelSilver.Size = new System.Drawing.Size(18, 20);
            this.labelSilver.TabIndex = 13;
            this.labelSilver.Text = "0";
            // 
            // pictureBoxSilver
            // 
            this.pictureBoxSilver.BackColor = System.Drawing.Color.Transparent;
            this.pictureBoxSilver.BackgroundImage = global::GuildLounge.Properties.Resources.icon_coinssilver;
            this.pictureBoxSilver.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pictureBoxSilver.Location = new System.Drawing.Point(82, 6);
            this.pictureBoxSilver.Name = "pictureBoxSilver";
            this.pictureBoxSilver.Size = new System.Drawing.Size(24, 24);
            this.pictureBoxSilver.TabIndex = 14;
            this.pictureBoxSilver.TabStop = false;
            // 
            // labelCopper
            // 
            this.labelCopper.AutoSize = true;
            this.labelCopper.BackColor = System.Drawing.Color.Transparent;
            this.labelCopper.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.labelCopper.Location = new System.Drawing.Point(166, 8);
            this.labelCopper.Name = "labelCopper";
            this.labelCopper.Size = new System.Drawing.Size(18, 20);
            this.labelCopper.TabIndex = 0;
            this.labelCopper.Text = "0";
            // 
            // pictureBoxCopper
            // 
            this.pictureBoxCopper.BackColor = System.Drawing.Color.Transparent;
            this.pictureBoxCopper.BackgroundImage = global::GuildLounge.Properties.Resources.icon_coinscopper;
            this.pictureBoxCopper.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pictureBoxCopper.Location = new System.Drawing.Point(139, 6);
            this.pictureBoxCopper.Name = "pictureBoxCopper";
            this.pictureBoxCopper.Size = new System.Drawing.Size(24, 24);
            this.pictureBoxCopper.TabIndex = 12;
            this.pictureBoxCopper.TabStop = false;
            // 
            // labelGold
            // 
            this.labelGold.AutoSize = true;
            this.labelGold.BackColor = System.Drawing.Color.Transparent;
            this.labelGold.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.labelGold.Location = new System.Drawing.Point(33, 8);
            this.labelGold.Name = "labelGold";
            this.labelGold.Size = new System.Drawing.Size(18, 20);
            this.labelGold.TabIndex = 0;
            this.labelGold.Text = "0";
            // 
            // pictureBoxGold
            // 
            this.pictureBoxGold.BackColor = System.Drawing.Color.Transparent;
            this.pictureBoxGold.BackgroundImage = global::GuildLounge.Properties.Resources.icon_coinsgold;
            this.pictureBoxGold.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pictureBoxGold.Location = new System.Drawing.Point(6, 6);
            this.pictureBoxGold.Name = "pictureBoxGold";
            this.pictureBoxGold.Size = new System.Drawing.Size(24, 24);
            this.pictureBoxGold.TabIndex = 8;
            this.pictureBoxGold.TabStop = false;
            // 
            // pictureBoxBaseCurrencies
            // 
            this.pictureBoxBaseCurrencies.BackColor = System.Drawing.Color.Transparent;
            this.pictureBoxBaseCurrencies.BackgroundImage = global::GuildLounge.Properties.Resources.icon_basecurrencies;
            this.pictureBoxBaseCurrencies.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pictureBoxBaseCurrencies.Location = new System.Drawing.Point(0, 0);
            this.pictureBoxBaseCurrencies.Name = "pictureBoxBaseCurrencies";
            this.pictureBoxBaseCurrencies.Size = new System.Drawing.Size(24, 24);
            this.pictureBoxBaseCurrencies.TabIndex = 21;
            this.pictureBoxBaseCurrencies.TabStop = false;
            // 
            // labelKarma
            // 
            this.labelKarma.AutoSize = true;
            this.labelKarma.BackColor = System.Drawing.Color.Transparent;
            this.labelKarma.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.labelKarma.Location = new System.Drawing.Point(33, 37);
            this.labelKarma.Name = "labelKarma";
            this.labelKarma.Size = new System.Drawing.Size(18, 20);
            this.labelKarma.TabIndex = 16;
            this.labelKarma.Text = "0";
            // 
            // ModuleBaseCurrencies
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Transparent;
            this.Controls.Add(this.labelBaseCurrencies);
            this.Controls.Add(this.pictureBoxBaseCurrencies);
            this.Controls.Add(this.groupBoxBaseCurrencies);
            this.ForeColor = System.Drawing.Color.White;
            this.Name = "ModuleBaseCurrencies";
            this.Size = new System.Drawing.Size(196, 94);
            this.groupBoxBaseCurrencies.ResumeLayout(false);
            this.groupBoxBaseCurrencies.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxKarma)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxSilver)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxCopper)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxGold)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxBaseCurrencies)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label labelBaseCurrencies;
        private System.Windows.Forms.PictureBox pictureBoxBaseCurrencies;
        private GL_GroupBox groupBoxBaseCurrencies;
        private System.Windows.Forms.Label labelCopper;
        private System.Windows.Forms.PictureBox pictureBoxCopper;
        private System.Windows.Forms.Label labelGold;
        private System.Windows.Forms.PictureBox pictureBoxGold;
        private System.Windows.Forms.Label labelSilver;
        private System.Windows.Forms.PictureBox pictureBoxSilver;
        private System.Windows.Forms.PictureBox pictureBoxKarma;
        private System.Windows.Forms.Label labelKarma;
    }
}
