using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Diagnostics;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GuildLounge.TabPages.SettingsPages
{
    public partial class About : UserControl
    {
        public About()
        {
            InitializeComponent();
        }

        private void linkLabelRedditName_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            System.Diagnostics.Process.Start("https://www.reddit.com/user/DeltaxHunter");
        }

        private void buttonPayPal_Click(object sender, EventArgs e)
        {

        }

        private void buttonPatreon_Click(object sender, EventArgs e)
        {

        }
    }
}
