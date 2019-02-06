using System;
using System.Drawing;
using System.Windows.Forms;

namespace GuildLounge
{
    public partial class Control_Button : Button
    {
        public Control_Button()
        {
            InitializeComponent();

            FlatStyle = FlatStyle.Flat;
            FlatAppearance.BorderSize = 0;
        }

        public override void NotifyDefault(bool value)
        {
            base.NotifyDefault(false);
        }
    }
}
