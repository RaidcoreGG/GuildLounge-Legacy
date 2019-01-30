using System;
using System.Windows.Forms;

namespace GuildLounge
{
    public partial class ModuleWvW : UserControl
    {
        public int BadgesOfHonor
        {
            get
            {
                return Convert.ToInt32(labelBadgeOfHonor.Text);
            }
            set
            {
                labelBadgeOfHonor.Text = value.ToString();
            }
        }
        public int SkirmishTickets
        {
            get
            {
                return Convert.ToInt32(labelWvWSkirmishTicket.Text);
            }
            set
            {
                labelWvWSkirmishTicket.Text = value.ToString();
            }
        }
        public ModuleWvW()
        {
            InitializeComponent();
        }
    }
}
