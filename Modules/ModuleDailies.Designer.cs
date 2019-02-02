namespace GuildLounge
{
    partial class ModuleDailies
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
            this.labelDaily = new System.Windows.Forms.Label();
            this.tableLayoutPanelDaily = new System.Windows.Forms.TableLayoutPanel();
            this.SuspendLayout();
            // 
            // labelDaily
            // 
            this.labelDaily.AutoSize = true;
            this.labelDaily.Location = new System.Drawing.Point(3, 0);
            this.labelDaily.Name = "labelDaily";
            this.labelDaily.Size = new System.Drawing.Size(106, 13);
            this.labelDaily.TabIndex = 0;
            this.labelDaily.Text = "[DAILY CATEGORY]";
            // 
            // tableLayoutPanelDaily
            // 
            this.tableLayoutPanelDaily.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.tableLayoutPanelDaily.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.Single;
            this.tableLayoutPanelDaily.ColumnCount = 1;
            this.tableLayoutPanelDaily.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanelDaily.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanelDaily.ForeColor = System.Drawing.Color.White;
            this.tableLayoutPanelDaily.Location = new System.Drawing.Point(3, 16);
            this.tableLayoutPanelDaily.Name = "tableLayoutPanelDaily";
            this.tableLayoutPanelDaily.RowCount = 1;
            this.tableLayoutPanelDaily.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanelDaily.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanelDaily.Size = new System.Drawing.Size(200, 21);
            this.tableLayoutPanelDaily.TabIndex = 1;
            // 
            // ModuleDailies
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.BackColor = System.Drawing.Color.Transparent;
            this.Controls.Add(this.tableLayoutPanelDaily);
            this.Controls.Add(this.labelDaily);
            this.ForeColor = System.Drawing.Color.White;
            this.Name = "ModuleDailies";
            this.Size = new System.Drawing.Size(206, 40);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label labelDaily;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanelDaily;
    }
}
