using System.Windows.Forms;

namespace GuildLounge
{
    public partial class GL_ToolTip : ToolTip
    {
        public string Text { get; set; }

        public GL_ToolTip() : base ()
        {
            InitializeComponent();
        }
    }
}
