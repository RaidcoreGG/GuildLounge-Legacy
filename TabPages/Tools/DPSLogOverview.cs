using System;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Script.Serialization;
using System.Windows.Forms;

namespace GuildLounge.TabPages.Tools
{
    public partial class DPSLogOverview : UserControl
    {
        private static readonly HttpClient _client = new HttpClient();
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

                if(listBoxEncounters.Items.Count > 0)
                    listBoxEncounters.SelectedItem = listBoxEncounters.Items[0];
                else
                {
                    labelLogInfo.Text = "No encounters logged.";
                    Utility.TimeoutToDisappear(labelLogInfo);
                }
            }
        }

        private void UploadLog(string path, bool open)
        {
            labelLogInfo.Visible = true;
            Task.Run(async () =>
            {
                try
                {
                    //Emulate a form
                    MultipartFormDataContent content = new MultipartFormDataContent();

                    //Add a filestream to that form
                    HttpContent fsc = new StreamContent(File.OpenRead(path));
                    content.Add(fsc, "file", path);

                    //Extract the token stored in program settings
                    string token = Properties.Settings.Default.DPSReportToken;

                    Parent.Invoke(new Action(() => labelLogInfo.Text = "Uploading file."));
                    //If the token is set use it, else don't
                    HttpResponseMessage response;
                    Console.WriteLine("[DPSLOG: UPLOADING FILE]");
                    if (!string.IsNullOrEmpty(token) && !string.IsNullOrWhiteSpace(token))
                        response = await _client.PostAsync("https://dps.report/uploadContent?json=1&generator=ei&userToken=" + token, content);
                    else
                        response = await _client.PostAsync("https://dps.report/uploadContent?json=1&generator=ei", content);

                    Parent.Invoke(new Action(() => labelLogInfo.Text = "File processed."));
                    //Read response and serialize JSON
                    var res = await response.Content.ReadAsStringAsync();
                    DPSReportLog dpsres = new JavaScriptSerializer().Deserialize<DPSReportLog>(res);

                    //Prompt to save the user token if the user has none saved
                    if (string.IsNullOrEmpty(token) && string.IsNullOrWhiteSpace(token))
                    {
                        Properties.Settings.Default.DPSReportToken = dpsres.UserToken;
                        var result = MessageBox.Show("You have no user token saved.\n\n" +
                            "Save now?", "Guild Lounge DPSLog Overview",
                                         MessageBoxButtons.YesNo,
                                         MessageBoxIcon.Question);

                        if (result == DialogResult.Yes)
                            Properties.Settings.Default.Save();
                    }

                    //Open the DPS Log in the browser
                    if (open)
                    {
                        Console.WriteLine("[DPSLOG: OPENING LOG]");
                        System.Diagnostics.Process.Start(dpsres.Permalink);
                    }
                }
                catch
                {
                    Parent.Invoke(new Action(() => labelLogInfo.Text = "There was an error while uploading the log."));
                }
                finally
                {
                    Utility.TimeoutToDisappear(labelLogInfo);
                }
            });
        }

        private async Task GetPreviousUploads()
        {
            Parent.Invoke(new Action(() => labelLogInfo.Visible = true));
            try
            {
                //Extract the token stored in program settings
                string token = Properties.Settings.Default.DPSReportToken;

                if (!string.IsNullOrEmpty(token) && !string.IsNullOrWhiteSpace(token))
                {
                    Console.WriteLine("[DPSLOG: FETCHING PREV UPLOADS]");
                    Parent.Invoke(new Action(() => labelLogInfo.Text = "Fetching previous uploads."));
                    string response = await _client.GetStringAsync("https://dps.report/getUploads?userToken=" + token);

                    DPSReportUploads uploads = new JavaScriptSerializer().Deserialize<DPSReportUploads>(response);

                    if (uploads.Uploads.Length > 0)
                    {
                        TabPages.Popups.PreviousLogUploads pvu = new TabPages.Popups.PreviousLogUploads();
                        Point p = new Point(12, 12);

                        foreach (DPSReportLog log in uploads.Uploads)
                        {
                            LinkLabel cur = new LinkLabel()
                            {
                                Text = log.Permalink,
                                Location = p,
                                Width = pvu.Width - 12,
                                LinkColor = Color.Red,
                                VisitedLinkColor = Color.OrangeRed
                            };
                            cur.Click += pvu.LogLink_Click;
                            pvu.Controls.Add(cur);
                            p.Y += 23;
                            p.Y += 6;
                        }

                        pvu.Height = p.Y + 6;
                        pvu.StartPosition = FormStartPosition.CenterParent;
                        pvu.AutoScroll = false;
                        pvu.HorizontalScroll.Enabled = false;
                        pvu.HorizontalScroll.Visible = false;
                        pvu.HorizontalScroll.Maximum = 0;
                        pvu.AutoScroll = true;
                        pvu.Show();
                    }
                }
                else
                {
                    Parent.Invoke(new Action(() => labelLogInfo.Text = "No user token saved."));
                }
            }
            catch (Exception exc)
            {
                Parent.Invoke(new Action(() => labelLogInfo.Text = "There was an error, please retry later."));
                Parent.Invoke(new Action(() => Utility.TimeoutToDisappear(labelLogInfo)));
            }
            Parent.Invoke(new Action(() => Utility.TimeoutToDisappear(labelLogInfo)));
        }

        #region events
        private void listBoxEncounters_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listBoxEncounters.SelectedItem == null)
                return;

            listBoxLogs.Items.Clear();
            listBoxLogs.Items.AddRange(((EncounterDir)listBoxEncounters.SelectedItem).Logs);

            if (listBoxLogs.Items.Count > 0)
                listBoxLogs.SelectedItem = listBoxLogs.Items[listBoxLogs.Items.Count - 1];
            else
            {
                labelLogInfo.Text = "No logs stored for this encounter.";
                Utility.TimeoutToDisappear(labelLogInfo);
            }
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

        private void buttonPreviousUploads_Click(object sender, EventArgs e)
        {
            GetPreviousUploads();
        }

        private void buttonExport_Click(object sender, EventArgs e)
        {
            if (listBoxLogs.SelectedItem == null)
                return;

            UploadLog(((LogFile)listBoxLogs.SelectedItem).Path, true);
        }
        #endregion
        
        #region classes
        internal class EncounterDir
        {
            public string Path { get; set; }
            public LogFile[] Logs { get; set; }
            public override string ToString()
            {
                return Path.Substring(Path.LastIndexOf("\\") + 1);
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

        internal class DPSReportLog
        {
            public string Permalink { get; set; }
            public string UserToken { get; set; }
        }

        internal class DPSReportUploads
        {
            public DPSReportLog[] Uploads { get; set; }
        }
        #endregion
    }
}