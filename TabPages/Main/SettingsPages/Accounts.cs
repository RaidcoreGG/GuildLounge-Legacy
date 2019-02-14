using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GuildLounge.TabPages.SettingsPages
{
    public partial class Accounts : UserControl
    {
        private bool m_bHidePassword { get; set; }
        public Accounts()
        {
            InitializeComponent();
            m_bHidePassword = true;
        }

        private void buttonToggleShowPassword_Click(object sender, EventArgs e)
        {
            m_bHidePassword = !m_bHidePassword;
            textBoxPassword.UseSystemPasswordChar = m_bHidePassword;

            if (m_bHidePassword)
                buttonToggleShowPassword.BackgroundImage = Properties.Resources.ui_locked;
            else
                buttonToggleShowPassword.BackgroundImage = Properties.Resources.ui_unlocked;
        }

        private void buttonAddAccount_Click(object sender, EventArgs e)
        {

        }
    }
}
