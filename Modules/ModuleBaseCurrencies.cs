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
    public partial class ModuleBaseCurrencies : UserControl
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
                labelGold.Text = (m_iCoins / 100 / 100).ToString();
                labelSilver.Text = (m_iCoins % 10000 / 100).ToString();
                labelCopper.Text = (m_iCoins % 100).ToString();
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

        public ModuleBaseCurrencies()
        {
            InitializeComponent();
        }
    }
}
