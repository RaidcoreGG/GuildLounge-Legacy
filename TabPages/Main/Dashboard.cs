using System;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace GuildLounge.TabPages
{
    public partial class Dashboard : UserControl
    {
        private static readonly ApiHandler _api = new ApiHandler();

        private NewsObject[] News;
        private int NewsIndex;
        private Timer NewsClock;

        public Dashboard()
        {
            InitializeComponent();

            News = new NewsObject[]
            {
                new NewsObject { Link = "", HeaderImage = Properties.Resources.news_panel1 },
                new NewsObject { Link = "", HeaderImage = Properties.Resources.news_panel2 },
                //new NewsObject { Link = "http://guildlounge.com", HeaderImage = Properties.Resources.news_panel3 },
            };

            FetchNews();

            NewsIndex = 0;
            NewsClock = new Timer();
            NewsClock.Interval = 7000;
            NewsClock.Tick += NewsClock_Tick;
            NewsClock.Start();

            SetNewsImage();
        }

        #region news
        private async void FetchNews()
        {
            try
            {
                NewsObject[] APIResponse = await _api.GetResponseWithEntryPoint<NewsObject[]>("http://api.guildlounge.com/", "news");
                News = APIResponse;
            }
            catch (Exception exc)
            {
                Console.WriteLine(exc.Message);
            }
        }
        
        private void SetNewsImage()
        {
            try
            {
                if (News[NewsIndex].HeaderImage == null)
                    pictureBoxNews.Load(News[NewsIndex].HeaderImageLink);
                else
                    pictureBoxNews.Image = News[NewsIndex].HeaderImage;
            }
            catch (Exception exc)
            {
                Console.WriteLine(exc.Message);
            }
        }

        private void NewsClock_Tick(object sender, EventArgs e)
        {
            buttonNewsNext_Click(null, null);
        }
        
        private void buttonNewsPrevious_Click(object sender, EventArgs e)
        {
            NewsClock.Stop();
            NewsIndex--;
            if (NewsIndex < 0)
                NewsIndex = News.Length - 1;
            SetNewsImage();
            NewsClock.Start();
        }

        private void buttonNewsNext_Click(object sender, EventArgs e)
        {
            NewsClock.Stop();
            NewsIndex++;
            if (NewsIndex > News.Length - 1)
                NewsIndex = 0;
            SetNewsImage();
            NewsClock.Start();
        }

        private void pictureBoxNews_Click(object sender, EventArgs e)
        {
            if(Regex.IsMatch(News[NewsIndex].Link, @"(http(s)?:\/\/)?(www.)?[\w-_\/]"))
                System.Diagnostics.Process.Start(News[NewsIndex].Link);
        }
        #endregion

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
            System.Diagnostics.Process.Start("https://discord.gg/MSgPhDv");
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

        #region tools
        private void linkLabelDailies_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            var obj = (Main)Parent;
            obj.SetActiveTab(obj.DailiesTab, sender);
        }
        #endregion
    }
}