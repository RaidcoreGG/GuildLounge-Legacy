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
    public partial class StatePanel : Control
    {
        private bool _Active;
        public bool Active
        {
            get
            {
                return _Active;
            }
            set
            {
                _Active = value;
                if (_Active)
                    _Color = Color.Green;
                else
                    _Color = Color.Red;
                Refresh();
            }
        }
        private Color _Color { get; set; }

        public StatePanel()
        {
            InitializeComponent();

            Active = false;
        }

        protected override void OnPaint(PaintEventArgs pe)
        {
            pe.Graphics.FillRectangle(new SolidBrush(_Color), 0, 0, Width, Height);
        }
    }
}
