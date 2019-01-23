using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GuildLounge
{
    public partial class UserControl_Dashboard : UserControl
    {
        NewsObject[] News;
        int NewsIndex;

        public UserControl_Dashboard()
        {
            InitializeComponent();
            News = new NewsObject[3];
            News[0] = new NewsObject { Link = "", HeaderImage = Properties.Resources.news_placeholder1 };
            News[1] = new NewsObject { Link = "", HeaderImage = Properties.Resources.news_placeholder2 };
            News[2] = new NewsObject { Link = "", HeaderImage = Properties.Resources.news_placeholder3 };
            NewsIndex = 0;
        }

        private void buttonNewsPrevious_Click(object sender, EventArgs e)
        {
            NewsIndex--;
            if (NewsIndex < 0)
                NewsIndex = News.Length - 1;
            pictureBoxNews.BackgroundImage = News[NewsIndex].HeaderImage;
        }

        private void buttonNewsNext_Click(object sender, EventArgs e)
        {
            NewsIndex++;
            if (NewsIndex > News.Length - 1)
                NewsIndex = 0;
            pictureBoxNews.BackgroundImage = News[NewsIndex].HeaderImage;
        }
    }

    class NewsObject
    {
        public string Link { get; set; }
        public Image HeaderImage { get; set; }
    }
}