﻿using System;
using System.Windows.Forms;

namespace GuildLounge
{
    public partial class Module_WvW : UserControl
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
        public Module_WvW()
        {
            InitializeComponent();

            labelBadgeOfHonor.TextChanged += new System.EventHandler(labelBadgeOfHonor_OnTextChanged);
        }

        private void labelBadgeOfHonor_OnTextChanged(object sender, EventArgs e)
        {
            Utility.ResizeFontOnWidthThreshold(labelBadgeOfHonor, 63);
        }
    }
}