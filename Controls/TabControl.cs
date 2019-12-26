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
    public partial class TabControl : Control
    {
        public List<UserControl> TabPages;
        public UserControl ActivePage;

        public event EventHandler ActivePageChanged;

        public TabControl()
        {
            InitializeComponent();

            TabPages = new List<UserControl>();
        }

        protected override void OnPaint(PaintEventArgs pe)
        {
            base.OnPaint(pe);
        }

        public void AddPage(UserControl page)
        {
            TabPages.Add(page);
            Controls.Add(page);

            if (ActivePage == null)
                ActivePage = page;
        }

        public void AddPages(UserControl[] pages)
        {
            TabPages.AddRange(pages);
            Controls.AddRange(pages);

            if (ActivePage == null)
                ActivePage = pages[0];
        }

        public void SetActiveTab(UserControl page)
        {
            //This handles the hiding of the old tab
            //and the showing of the new tab

            if (ActivePage != null)
            {
                ActivePage.Visible = false;
                ActivePage = page;
                ActivePage.Visible = true;
            }
            else
            {
                ActivePage = page;
                ActivePage.Visible = true;
            }
        }
    }
}
