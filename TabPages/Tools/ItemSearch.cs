using System;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace GuildLounge.TabPages.Tools
{
    public partial class ItemSearch : UserControl
    {
        public Character[] CachedCharacters { get; set; }
        public Item[] CachedVault { get; set; }

        public Timer Timeout { get; set; }

        public ItemSearch()
        {
            InitializeComponent();

            Timeout = new Timer();
            Timeout.Interval = 1000;
            Timeout.Tick += Timeout_Tick;
        }

        private void textBoxItemName_TextChanged(object sender, EventArgs e)
        {
            Timeout.Stop();
            Timeout.Start();
        }

        private void Timeout_Tick(object sender, EventArgs e)
        {
            CrawlData(textBoxItemName.Text);
        }

        private void CrawlData(string name)
        {
            Timeout.Stop();
            if(!string.IsNullOrEmpty(textBoxItemName.Text) && !string.IsNullOrWhiteSpace(textBoxItemName.Text))
            {
                Console.WriteLine("[SEARCH: INIT]");
                DateTime dt = DateTime.Now;

                Console.WriteLine("[SEARCH: CHARACTERS]");
                Console.WriteLine("[SEARCH: VAULT]");

                Console.WriteLine("[SEARCH: " + (DateTime.Now - dt).TotalSeconds + "]");
            }
        }
    }
}