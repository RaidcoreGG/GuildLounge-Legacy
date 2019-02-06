using System;
using System.Drawing;
using System.Windows.Forms;

namespace GuildLounge
{
    public partial class GL_HighlightButton : Button
    {
        public GL_HighlightButton()
        {
            InitializeComponent();

            BackColor = Color.FromArgb(185, 13, 10);
            ForeColor = Color.White;
            FlatStyle = FlatStyle.Flat;
            FlatAppearance.BorderSize = 0;
        }

        protected override void OnPaint(PaintEventArgs pe)
        {
            base.OnPaint(pe);
        }

        protected override void OnEnabledChanged(EventArgs e)
        {
            base.OnEnabledChanged(e);
            if(Enabled)
            {
                BackColor = Color.FromArgb(185, 13, 10);
                ForeColor = Color.White;
            }
            else
            {
                BackColor = Color.Gray;
                ForeColor = Color.Black;
            }
        }

        public override void NotifyDefault(bool value)
        {
            base.NotifyDefault(false);
        }
    }
}
