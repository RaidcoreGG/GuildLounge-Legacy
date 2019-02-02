using System;
using System.Windows.Forms;

namespace GuildLounge
{
    public partial class ModuleFractals : UserControl
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
        public ModuleFractals()
        {
            InitializeComponent();
        }
    }
}
