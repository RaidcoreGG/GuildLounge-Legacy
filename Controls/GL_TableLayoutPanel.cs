using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GuildLounge
{
    public partial class GL_TableLayoutPanel : TableLayoutPanel
    {
        [Category("Appearance")]
        public double BackgroundScale { get; set; } = 1.0;

        protected override void OnPaintBackground(PaintEventArgs e)
        {
            e.Graphics.Clear(this.BackColor);
            if (this.BackgroundImage != null && this.BackgroundScale != 0)
            {
                var scaledImage = (Image) new Bitmap(this.BackgroundImage, Scale(this.BackgroundImage.Size, this.BackgroundScale));
                var imagePosition = new Point(this.Width - scaledImage.Width, 0);
                e.Graphics.DrawImage(scaledImage, imagePosition);
            }
        }

        private Size Scale(Size original, double amount)
        {
            int newWidth = (int) ((double) original.Width * amount);
            Console.WriteLine($"New width: {newWidth}");
            int newHeight = (int) ((double) original.Height * amount);
            Console.WriteLine($"New height: {newHeight}");
            return new Size(newWidth, newHeight);
        }

        public GL_TableLayoutPanel()
        {
            InitializeComponent();
        }

        public GL_TableLayoutPanel(IContainer container)
        {
            container.Add(this);

            InitializeComponent();
        }
    }
}
