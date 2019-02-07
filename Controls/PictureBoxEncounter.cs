using System;
using System.Drawing;
using System.Windows.Forms;

namespace GuildLounge.Controls
{
    public partial class PictureBoxEncounter : PictureBox
    {
        public int BorderSize { get; set; }
        public Color BorderColor { get; set; }
        public bool EncounterFinished { get; set; }
        private bool m_bHasCM { get; set; }
        public bool HasCM
        {
            get
            {
                return m_bHasCM;
            }
            set
            {
                m_bHasCM = value;
                if (m_bHasCM)
                    Image = Properties.Resources.overlay_cm;
                else
                    Image = null;
            }
        }
        private bool m_bDoneCM { get; set; }
        public bool DoneCM
        {
            get
            {
                return m_bDoneCM;
            }
            set
            {
                m_bDoneCM = value;
                if (m_bDoneCM && m_bHasCM)
                    Image = Properties.Resources.overlay_cmdone;
                else if (!m_bDoneCM && m_bHasCM)
                    Image = Properties.Resources.overlay_cm;
                else if (!m_bHasCM)
                    Image = null;
            }
        }
        private ToolTip ToolTipEncounterName { get; set; }

        public PictureBoxEncounter()
        {
            InitializeComponent();

            BorderSize = 2;
            ToolTipEncounterName = new ToolTip();
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
