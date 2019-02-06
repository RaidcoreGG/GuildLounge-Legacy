using System.Windows.Forms;

namespace GuildLounge
{
    public partial class Control_ToolTip : ToolTip
    {
        public string Text { get; set; }

        public Control_ToolTip() : base ()
        {
            InitializeComponent();
        }
    }
}
