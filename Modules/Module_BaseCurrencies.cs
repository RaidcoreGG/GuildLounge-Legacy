using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GuildLounge
{
    public partial class Module_BaseCurrencies : UserControl
    {
        private int m_iCoins;
        public int Coins
        {
            get
            {
                return m_iCoins;
            }
            set
            {
                m_iCoins = value;
                var srtd = Utility.SortCoins(m_iCoins);
                labelGold.Text = srtd.Gold.ToString();
                labelSilver.Text = srtd.Silver.ToString();
                labelCopper.Text = srtd.Copper.ToString();
            }
        }

        public int Karma
        {
            get
            {
                return Convert.ToInt32(labelKarma.Text);
            }
            set
            {
                labelKarma.Text = String.Format("{0:n0}", value);
            }
        }

        public int Laurels
        {
            get
            {
                return Convert.ToInt32(labelLaurels.Text);
            }
            set
            {
                labelLaurels.Text = value.ToString();
            }
        }

        public int Gems
        {
            get
            {
                return Convert.ToInt32(labelGems.Text);
            }
            set
            {
                labelGems.Text = value.ToString();
            }
        }

        public Module_BaseCurrencies()
        {
            InitializeComponent();

            labelGold.TextChanged += new System.EventHandler(labelGold_OnTextChanged);
        }

        private void labelGold_OnTextChanged(object sender, EventArgs e)
        {
            Utility.ResizeFontOnWidthThreshold(labelGold, 45);
        }
    }
}