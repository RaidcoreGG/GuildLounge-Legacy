using System;
using System.Windows.Forms;

namespace GuildLounge
{
    public partial class ModulePvP : UserControl
    {
        public int AscendedShardsOfGlory
        {
            get
            {
                return Convert.ToInt32(labelAscendedShardsOfGlory.Text);
            }
            set
            {
                labelAscendedShardsOfGlory.Text = value.ToString();
            }
        }
        public int LeagueTicket
        {
            get
            {
                return Convert.ToInt32(labelPvPLeagueTicket.Text);
            }
            set
            {
                labelPvPLeagueTicket.Text = value.ToString();
            }
        }
        public ModulePvP()
        {
            InitializeComponent();
        }
    }
}
