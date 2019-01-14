using System.Drawing;
using System.Windows.Forms;

namespace GuildLounge
{
    public partial class GL_MenuStrip : MenuStrip
    {
        public GL_MenuStrip() : base()
        {
            InitializeComponent();

            Renderer = new MenuStripRenderer();
            BackColor = Color.FromArgb(30, 30, 30);
            RightToLeft = RightToLeft.Yes;
        }

        private class MenuStripRenderer : ToolStripProfessionalRenderer
        {
            public MenuStripRenderer() : base(new MenuStripColors()) { }
        }

        private class MenuStripColors : ProfessionalColorTable
        {
            Color c = Color.FromArgb(40, 42, 45);
            public override Color MenuItemSelected { get { return c; } }
            public override Color MenuItemSelectedGradientBegin { get { return c; } }
            public override Color MenuItemSelectedGradientEnd { get { return c; } }
        }
    }
}
