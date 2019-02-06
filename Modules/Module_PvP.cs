using System;
using System.Windows.Forms;

namespace GuildLounge
{
    public partial class Module_PvP : UserControl
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
        public Module_PvP()
        {
            InitializeComponent();
        }
    }
}
