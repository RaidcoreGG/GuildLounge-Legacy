using System;
using System.Drawing;
using System.Windows.Forms;

namespace GuildLounge.Controls
{
    public partial class DailyModule : GroupBox
    {
        private string m_sCategory;
        public string Category
        {
            get
            {
                return m_sCategory;
            }
            set
            {
                m_sCategory = value;
                switch (m_sCategory)
                {
                    case "pve":
                        CategoryIcon.BackgroundImage = Properties.Resources.daily_pve;
                        break;
                    case "pvp":
                        CategoryIcon.BackgroundImage = Properties.Resources.daily_pvp;
                        break;
                    case "wvw":
                        CategoryIcon.BackgroundImage = Properties.Resources.daily_wvw;
                        break;
                    case "fractals":
                        CategoryIcon.BackgroundImage = Properties.Resources.daily_fractals;
                        break;
                }
            }
        }
        private PictureBox CategoryIcon { get; set; }
        private Label labelTitle { get; set; }
        public string Title
        {
            get
            {
                return labelTitle.Text;
            }
            set
            {
                labelTitle.Text = value;
            }
        }

        public DailyModule()
        {
            InitializeComponent();

            CategoryIcon = new PictureBox();
            CategoryIcon.BackgroundImage = Properties.Resources.daily_pve;
            CategoryIcon.Location = new Point(1, 1);
            CategoryIcon.Size = new Size(30, 30);
            CategoryIcon.BackgroundImageLayout = ImageLayout.Stretch;

            Controls.Add(CategoryIcon);

            labelTitle = new Label();
            labelTitle.BackColor = Color.Transparent;
            labelTitle.Location = new Point(38, ((Height - (int)labelTitle.Font.SizeInPoints) / 2 - 2));
            labelTitle.Width = Width - 38;
            labelTitle.Text = "Daily";

            Controls.Add(labelTitle);
        }
    }
}