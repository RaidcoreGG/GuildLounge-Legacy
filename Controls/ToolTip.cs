using System.Windows.Forms;

namespace GuildLounge.Controls
{
    public partial class ToolTip : System.Windows.Forms.ToolTip
    {
        public string Text { get; set; }

        public ToolTip() : base ()
        {
            InitializeComponent();
        }
    }
}
