using System.Windows.Forms;

namespace GuildLounge.TabPages.Popups
{
    public partial class UserTokenHelp : Form
    {
        public UserTokenHelp()
        {
            InitializeComponent();
        }

        private void linkLabelDPSReportTokenHelp_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            System.Diagnostics.Process.Start("http://dps.report/getUserToken");
        }
    }
}
