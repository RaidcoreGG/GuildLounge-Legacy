using System;
using System.Drawing;
using System.Windows.Forms;

namespace GuildLounge
{
    public partial class GL_NavigationButton : Button
    {
        private bool m_oActive;
        private GL_HorizontalLine hr;
        public GL_NavigationButton() : base()
        {
            InitializeComponent();

            BackColor = Color.Transparent;
            ForeColor = Color.Gray;
            FlatStyle = FlatStyle.Flat;
            FlatAppearance.BorderSize = 0;

            FlatAppearance.CheckedBackColor =
                FlatAppearance.MouseDownBackColor =
                FlatAppearance.MouseOverBackColor =
                Color.Transparent;

            //SET UP HORIZONTAL LINE
            hr = new GL_HorizontalLine();
            hr.Width = Width;
            hr.Location = new Point(0, Height - hr.Height);
            hr.BackColor = Color.Red;
            hr.Visible = false;

            Controls.Add(hr);
            Active = false;
        }

        public bool Active
        {
            get { return m_oActive; }
            set
            {
                m_oActive = value;
                hr.Visible = value;
                if (value == true)
                    ForeColor = Color.White;
                else
                    ForeColor = Color.Gray;
            }
        }

        protected override void OnSizeChanged(EventArgs e)
        {
            base.OnSizeChanged(e);
            hr.Width = Width;
            hr.Location = new Point(0, Height - hr.Height);
        }

        protected override void OnMouseEnter(EventArgs e)
        {
            base.OnMouseEnter(e);
            hr.BackColor = Color.FromArgb(255, 50, 50);
            hr.Visible = true;
            ForeColor = Color.White;
        }

        protected override void OnMouseLeave(EventArgs e)
        {
            base.OnMouseLeave(e);
            if (!Active)
            {
                hr.Visible = false;
                ForeColor = Color.Gray;
            }
            hr.BackColor = Color.Red;
        }

        protected override void OnMouseDown(MouseEventArgs mevent)
        {
            base.OnMouseDown(mevent);
            hr.BackColor = Color.OrangeRed;
            ForeColor = Color.White;
        }

        protected override void OnMouseUp(MouseEventArgs mevent)
        {
            base.OnMouseUp(mevent);
            hr.BackColor = Color.Red;
        }

        public override void NotifyDefault(bool value)
        {
            base.NotifyDefault(false);
        }
    }
}
