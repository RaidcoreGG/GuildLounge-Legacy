using System.Windows.Forms;

namespace GuildLounge.TabPages.Popups
{
    public partial class UpdateNotification : Form
    {
        public UpdateNotification()
        {
            InitializeComponent();
        }

        public UpdateNotification(string note)
        {
            InitializeComponent();

            labelNote.Text = note;
        }

        private void linkLabelDPSReportTokenHelp_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            System.Diagnostics.Process.Start("http://guildlounge.com");
        }

        private void buttonNo_Click(object sender, System.EventArgs e)
        {
            DialogResult = DialogResult.No;
            Dispose();
        }

        private void buttonYes_Click(object sender, System.EventArgs e)
        {
            DialogResult = DialogResult.Yes;
            Dispose();
        }
    }
}