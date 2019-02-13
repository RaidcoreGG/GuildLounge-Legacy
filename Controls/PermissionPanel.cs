using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GuildLounge.Controls
{
    public partial class PermissionPanel : Control
    {
        private bool m_bAllowed { get; set; }
        public bool Allowed
        {
            get
            {
                return m_bAllowed;
            }
            set
            {
                m_bAllowed = value;
                if (m_bAllowed)
                    m_oColor = Color.Green;
                else
                    m_oColor = Color.Red;
                Refresh();
            }
        }
        private Color m_oColor { get; set; }

        public PermissionPanel()
        {
            InitializeComponent();
        }

        protected override void OnPaint(PaintEventArgs pe)
        {
            pe.Graphics.FillRectangle(new SolidBrush(m_oColor), 0, 0, Width, Height);
        }
    }
}
