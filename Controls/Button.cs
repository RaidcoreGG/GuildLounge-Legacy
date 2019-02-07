using System;
using System.Drawing;
using System.Windows.Forms;

namespace GuildLounge.Controls
{
    public partial class Button : System.Windows.Forms.Button
    {
        public Button()
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
