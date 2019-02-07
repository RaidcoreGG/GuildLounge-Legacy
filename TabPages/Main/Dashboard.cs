using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Text.RegularExpressions;

namespace GuildLounge.TabPages
{
    public partial class Dashboard : UserControl
    {
        NewsObject[] News;
        int NewsIndex;

        class NewsObject
        {
            public string Link { get; set; }
            public Image HeaderImage { get; set; }
        }

        public Dashboard()
        {
            InitializeComponent();
            News = new NewsObject[3];
            News[0] = new NewsObject { Link = "www.guildlounge.com", HeaderImage = Properties.Resources.news_panel1 };
            News[1] = new NewsObject { Link = "www.guildlounge.com", HeaderImage = Properties.Resources.news_panel2 };
            News[2] = new NewsObject { Link = "www.guildlounge.com", HeaderImage = Properties.Resources.news_panel3 };
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

        private void pictureBoxNews_Click(object sender, EventArgs e)
        {
            if(Regex.IsMatch(News[NewsIndex].Link, @"(http(s)?:\/\/)?(www.)?[\w-_\/]"))
                System.Diagnostics.Process.Start(News[NewsIndex].Link);
        }

        #region links
        private void linkLabelGLReleaseNotes_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            System.Diagnostics.Process.Start("https://guildlounge.com/");
        }

        private void linkLabelGLIdeaSubmission_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            System.Diagnostics.Process.Start("https://guildlounge.com/ask");
        }

        private void linkLabelGLDiscord_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            System.Diagnostics.Process.Start("https://discord.gg/bkwWcCb");
        }

        private void linkLabelGW2Efficiency_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            System.Diagnostics.Process.Start("https://gw2efficiency.com");
        }

        private void linkLabelGW2Wiki_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            System.Diagnostics.Process.Start("https://wiki.guildwars2.com/wiki/Main_Page");
        }

        private void linkLabelGW2ReleaseNotes_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            System.Diagnostics.Process.Start("https://en-forum.guildwars2.com/categories/game-release-notes/");
        }

        private void linkLabelGW2Forums_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            System.Diagnostics.Process.Start("https://forum.guildwars2.com");
        }
        #endregion
    }
}