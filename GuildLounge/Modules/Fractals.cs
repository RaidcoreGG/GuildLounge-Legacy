using System;
using System.Windows.Forms;

namespace GuildLounge.Modules
{
    public partial class Fractals : UserControl
    {
        public int FractalRelics
        {
            get
            {
                return Convert.ToInt32(labelFractalRelics.Text);
            }
            set
            {
                labelFractalRelics.Text = value.ToString();
            }
        }
        public int PristineFractalRelics
        {
            get
            {
                return Convert.ToInt32(labelPristineFractalRelics.Text);
            }
            set
            {
                labelPristineFractalRelics.Text = value.ToString();
            }
        }
        public Fractals()
        {
            InitializeComponent();

            labelFractalRelics.TextChanged += new System.EventHandler(labelFractalRelics_OnTextChanged);
        }
        
        private void labelFractalRelics_OnTextChanged(object sender, EventArgs e)
        {
            Utility.ResizeFontOnWidthThreshold(labelFractalRelics, 63);
        }
    }
}
