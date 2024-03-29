﻿using System;
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
            
            InitializeDefaultNews();
            
            FetchNews();
            SetNewsImage();
            
            InitializeTimer();
        }

        #region news
        private void InitializeDefaultNews()
        {
            //this method sets the default news from embedded images, in case the API can't be reached

            News = new NewsObject[]
            {
                new NewsObject { Link = "", HeaderImage = Properties.Resources.news_panel1 },
                new NewsObject { Link = "", HeaderImage = Properties.Resources.news_panel2 },
            };
        }

        private void InitializeTimer()
        {
            //Initializing the timer at an interval of 7 seconds

            NewsClock = new Timer();
            NewsClock.Interval = 7000;
            NewsClock.Tick += NewsClock_Tick;
            NewsClock.Start();
        }

        private async void FetchNews()
        {
            //fetching the news from the GuildLounge API and serializing them
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
                {
                    //Load the image into the pictureBox from the URL, then Cache image into NewsObject
                    pictureBoxNews.Load(News[NewsIndex].HeaderImageLink);
                    News[NewsIndex].HeaderImage = pictureBoxNews.Image;
                }
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
            //Set the next image each tick
            buttonNewsNext_Click(null, null);
        }
        
        private void buttonNewsPrevious_Click(object sender, EventArgs e)
        {
            //Reset the timer each time the news are manually switched
            NewsClock.Stop();
            //Show previous news
            NewsIndex--;
            if (NewsIndex < 0)
                NewsIndex = News.Length - 1;
            SetNewsImage();
            NewsClock.Start();
        }

        private void buttonNewsNext_Click(object sender, EventArgs e)
        {
            //Reset the timer each time the news are manually switched
            NewsClock.Stop();
            //Show next news
            NewsIndex++;
            if (NewsIndex > News.Length - 1)
                NewsIndex = 0;
            SetNewsImage();
            NewsClock.Start();
        }

        private void pictureBoxNews_Click(object sender, EventArgs e)
        {
            //If Link Property is set (properly), open the browser with the link
            if(Regex.IsMatch(News[NewsIndex].Link, @"(http(s)?:\/\/)?(www.)?[\w-_\/]"))
                System.Diagnostics.Process.Start(News[NewsIndex].Link);
        }
        #endregion
        
        #region links
        //Start a new process with the clicked link, aka open it in the browser
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
        //Cast the parent form (Main)
        //Use the SetActiveTab method of the parent form to the corresponding tab
        private void linkLabelDailies_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            var obj = (Main)Parent;
            obj.SetActiveTab(obj.DailiesTab, sender);
        }

        private void linkLabelWindowedResolution_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            var obj = (Main)Parent;
            obj.SetActiveTab(obj.WindowedResolutionTab, sender);
        }
        
        private void linkLabelDPSLogOverview_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            var obj = (Main)Parent;
            obj.SetActiveTab(obj.DPSLogOverviewTab, sender);
        }
        #endregion
    }
}