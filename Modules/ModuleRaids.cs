using System;
using System.Windows.Forms;

namespace GuildLounge
{
    public partial class ModuleRaids : UserControl
    {
        private Control_ToolTip ToolTipLI;
        private Control_ToolTip ToolTipLD;
        
        public int LegendaryInsights
        {
            get
            {
                return Convert.ToInt32(labelLI.Text);
            }
            set
            {
                labelLI.Text = value.ToString();
            }
        }
        public int LegendaryDivinations
        {
            get
            {
                return Convert.ToInt32(labelLD.Text);
            }
            set
            {
                labelLD.Text = value.ToString();
            }
        }
        public string LIDetail
        {
            get
            {
                return ToolTipLI.Text;
            }
            set
            {
                ToolTipLI.Text = value;
            }
        }
        public string LDDetail
        {
            get
            {
                return ToolTipLD.Text;
            }
            set
            {
                ToolTipLD.Text = value;
            }
        }
        public int MagnetiteShards
        {
            get
            {
                return Convert.ToInt32(labelMagnetiteShard.Text);
            }
            set
            {
                labelMagnetiteShard.Text = value.ToString();
            }
        }
        public int GaetingCrystals
        {
            get
            {
                return Convert.ToInt32(labelGaetingCrystal.Text);
            }
            set
            {
                labelGaetingCrystal.Text = value.ToString();
            }
        }

        public ModuleRaids()
        {
            InitializeComponent();

            ToolTipLI = new Control_ToolTip();
            ToolTipLD = new Control_ToolTip();

            pictureBoxLI.MouseEnter += new System.EventHandler(LI_OnMouseEnter);
            pictureBoxLI.MouseLeave += new System.EventHandler(LI_OnMouseLeave);
            pictureBoxLD.MouseEnter += new System.EventHandler(LD_OnMouseEnter);
            pictureBoxLD.MouseLeave += new System.EventHandler(LD_OnMouseLeave);
        }

        private void LI_OnMouseEnter(object sender, EventArgs e)
        {
            var obj = (PictureBox)sender;
            ToolTipLI.Show(ToolTipLI.Text, obj, 0, obj.Height);
        }

        private void LI_OnMouseLeave(object sender, EventArgs e)
        {
            ToolTipLI.RemoveAll();
            ToolTipLI.Hide(this);
        }

        private void LD_OnMouseEnter(object sender, EventArgs e)
        {
            var obj = (PictureBox)sender;
            ToolTipLD.Show(ToolTipLD.Text, obj, 0, obj.Height);
        }

        private void LD_OnMouseLeave(object sender, EventArgs e)
        {
            ToolTipLD.RemoveAll();
            ToolTipLD.Hide(this);
        }
    }
}
