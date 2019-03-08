using System;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using System.IO;
using System.Diagnostics;

namespace GuildLounge.TabPages.Tools
{
    public partial class DPSLogOverview : UserControl
    {
        private static string _logs = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "Guild Wars 2/addons/arcdps/arcdps.cbtlogs");

        public DPSLogOverview()
        {
            InitializeComponent();

            GetEncounters();
        }

        public void GetEncounters()
        {
            if(Directory.Exists(_logs))
            {
                listBoxEncounters.Items.Clear();

                foreach (string s in Directory.GetDirectories(_logs))
                {
                    string[] subFiles = Directory.GetFiles(s);
                    LogFile[] logFiles = new LogFile[subFiles.Length];

                    for (int i = 0; i < logFiles.Length; i++)
                        logFiles[i] = new LogFile() { Path = subFiles[i] };

                    listBoxEncounters.Items.Add(new EncounterDir() { Path = s, Logs = logFiles });
                }

                if(listBoxEncounters.Items.Count >= 0)
                    listBoxEncounters.SelectedItem = listBoxEncounters.Items[0];
            }
        }

        internal class EncounterDir
        {
            public string Path { get; set; }
            public LogFile[] Logs { get; set; }
            public override string ToString()
            {
                return Path.Substring(Path.LastIndexOf("\\")+1);
            }
        }

        internal class LogFile
        {
            public string Path { get; set; }
            public override string ToString()
            {
                //Whoever sees this, instead of shooting me on the spot, please teach me string.Format :)

                string s = Path.Substring(Path.LastIndexOf("\\") + 1);
                s = s.Remove(s.LastIndexOf("."));

                string n = "";
                n += s.Substring(0, 4) + ", "; //Year
                switch (s.Substring(4, 2)) //Month
                {
                    case "01":
                        n += "January ";
                        break;
                    case "02":
                        n += "February ";
                        break;
                    case "03":
                        n += "March ";
                        break;
                    case "04":
                        n += "April ";
                        break;
                    case "05":
                        n += "May ";
                        break;
                    case "06":
                        n += "June ";
                        break;
                    case "07":
                        n += "July ";
                        break;
                    case "08":
                        n += "August ";
                        break;
                    case "09":
                        n += "September ";
                        break;
                    case "10":
                        n += "October ";
                        break;
                    case "11":
                        n += "November ";
                        break;
                    case "12":
                        n += "December ";
                        break;
                }
                n += s.Substring(6, 2) + " "; //Day
                n += s.Substring(8, 1) + " "; //Separator
                n += s.Substring(9, 2) + ":"; //Hour
                n += s.Substring(11, 2); //Minute
                return n;
            }
        }

        private void listBoxEncounters_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listBoxEncounters.SelectedItem == null)
                return;

            listBoxLogs.Items.Clear();
            listBoxLogs.Items.AddRange(((EncounterDir)listBoxEncounters.SelectedItem).Logs);

            if (listBoxLogs.Items.Count >= 0)
                listBoxLogs.SelectedItem = listBoxLogs.Items[listBoxLogs.Items.Count - 1];
        }

        private void buttonOpenFolder_Click(object sender, EventArgs e)
        {
            if(Directory.Exists(_logs))
                Process.Start(_logs);
        }

        private void buttonRefresh_Click(object sender, EventArgs e)
        {
            GetEncounters();
        }

        private void buttonExport_Click(object sender, EventArgs e)
        {

        }
    }
}