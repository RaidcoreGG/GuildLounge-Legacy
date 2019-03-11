using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GuildLounge.TabPages.Help
{
    public partial class DPSReportUserToken : Form
    {
        public DPSReportUserToken()
        {
            InitializeComponent();
        }

        private void linkLabelDPSReportTokenHelp_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            System.Diagnostics.Process.Start("http://dps.report/getUserToken");
        }
    }
}
