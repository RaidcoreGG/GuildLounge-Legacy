using System.Drawing;
using System.Windows.Forms;

namespace GuildLounge.Controls
{
    public partial class GroupBox : System.Windows.Forms.GroupBox
    {
        public int BorderSize { get; set; }
        public Color BorderColor { get; set; }

        public GroupBox()
        {
            InitializeComponent();

            BackColor = Color.FromArgb(30, 30, 30);
            BorderSize = 1;
            BorderColor = Color.Gray;
        }

        protected override void OnPaint(PaintEventArgs pe)
        {
            base.OnPaint(pe);
            
            pe.Graphics.Clear(BackColor);
            Pen p = new Pen(BorderColor, BorderSize);
            Point[] bp = new Point[5];

            //SET UP OUTLINE
            bp[0] = new Point(0, 0);
            bp[1] = new Point(Width - BorderSize, 0);
            bp[2] = new Point(Width - BorderSize, Height - 1);
            bp[3] = new Point(0, Height - 1);
            bp[4] = bp[0];

            //DRAW OUTLINE
            pe.Graphics.DrawLine(p, bp[0], bp[1]);
            pe.Graphics.DrawLine(p, bp[1], bp[2]);
            pe.Graphics.DrawLine(p, bp[2], bp[3]);
            pe.Graphics.DrawLine(p, bp[3], bp[4]);
        }
    }
}
