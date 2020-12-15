using System;
using System.Windows.Forms;

namespace GuildLounge.TabPages.Popups
{
    public partial class PreviousLogUploads : Form
    {
        public PreviousLogUploads()
        {
            InitializeComponent();

            LinkLabel ll = new LinkLabel();
            ll.Click += LogLink_Click;
        }

        public void LogLink_Click(object sender, System.EventArgs e)
        {
            try
            {
                System.Diagnostics.Process.Start(((LinkLabel)sender).Text);
            }
            catch (Exception exc)
            {
                MessageBox.Show("Something went wrong!\n" +
                    "Please contact the developer.\n\n" +
                    exc.Message, "Error");
            }
        }
    }
}