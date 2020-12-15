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
    public partial class Scrollbar : UserControl
    {
        public Button Thumb { get; set; }

        private float factor { get; set; }

        private int Maximum { get; set; }
        private int Minimum { get; set; }
        public int Value { get; set; }
        private int Step { get; set; }

        public Scrollbar()
        {
            InitializeComponent();

            BackColor = Color.FromArgb(30, 30, 30);

            Thumb = new Button()
            {
                Location = new Point(1, 1),
                Size = new Size(Width - 2, (int)((Height - 2) * 0.2)),
                BackColor = Color.FromArgb(100, 100, 100)
            };

            Recalculate(Height, Height);

            Controls.Add(Thumb);

            //HANDLED BY MAIN
            //this.MouseWheel += new MouseEventHandler(OnMouseWheel);
            this.SizeChanged += new EventHandler(OnSizeChanged);
        }

        protected void OnSizeChanged(object sender, EventArgs e)
        {
            Recalculate(Height, 1);
        }

        public void Recalculate(int normalHeight, int overflowedHeight)
        {
            if (overflowedHeight < normalHeight)
            {
                this.Visible = false;
                return;
            }
            else
            {
                this.Visible = true;
                factor = (float)normalHeight / (float)overflowedHeight;
            }

            Thumb.Size = new Size(Width - 2, (int)((Height - 2) * factor));

            Step = (int)(overflowedHeight * 0.1);

            Maximum = Height - 1 - Thumb.Height;
            Minimum = 1;
        }

        public void OnMouseWheel(object sender, MouseEventArgs e)
        {
            if (e.Delta > 0)
            {
                //Console.WriteLine("up");
                if (!((Thumb.Top - Step) < Minimum))
                {
                    Thumb.Top -= Step;
                    Value -= Step;
                }
                else
                {
                    Thumb.Top = Minimum;
                    Value = 0;
                }
            }
            else
            {
                //Console.WriteLine("dn");
                if (!((Thumb.Top + Step) > Maximum))
                {
                    Thumb.Top += Step;
                    Value += Step;
                }
                else
                {
                    Thumb.Top = Maximum;
                    Value = (int)(Maximum/(factor*100)*100);
                }
            }
        }
    }
}
