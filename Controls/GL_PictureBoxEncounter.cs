using System;
using System.Drawing;
using System.Windows.Forms;

namespace GuildLounge
{
    public partial class GL_PictureBoxEncounter : PictureBox
    {
        public int BorderSize { get; set; }
        public Color BorderColor { get; set; }
        public bool EncounterFinished { get; set; }
        private GL_ToolTip ToolTipEncounterName { get; set; }

        public GL_PictureBoxEncounter()
        {
            InitializeComponent();

            BorderSize = 2;
            EncounterFinished = false;
            ToolTipEncounterName = new GL_ToolTip();
        }

        protected override void OnPaint(PaintEventArgs pe)
        {
            base.OnPaint(pe);

            if(EncounterFinished)
                BorderColor = Color.Green;
            else
                BorderColor = Color.Red;
            
            Pen p = new Pen(BorderColor, BorderSize*2);
            Point[] bp = new Point[5];

            //SET UP OUTLINE
            bp[0] = new Point(0, 0);
            bp[1] = new Point(Width, 0);
            bp[2] = new Point(Width, Height);
            bp[3] = new Point(0, Height);
            bp[4] = bp[0];

            //DRAW OUTLINE
            pe.Graphics.DrawLine(p, bp[0], bp[1]);
            pe.Graphics.DrawLine(p, bp[1], bp[2]);
            pe.Graphics.DrawLine(p, bp[2], bp[3]);
            pe.Graphics.DrawLine(p, bp[3], bp[4]);
        }

        protected override void OnMouseEnter(EventArgs e)
        {
            base.OnMouseEnter(e);
            string txt = "";
            if (Name.StartsWith("pictureBox"))
                txt = Name.Substring(10);
            ToolTipEncounterName.Show(txt, this, 0, Height);
        }

        protected override void OnMouseLeave(EventArgs e)
        {
            base.OnMouseLeave(e);
            ToolTipEncounterName.Hide(this);
        }
    }
}
