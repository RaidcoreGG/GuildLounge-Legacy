using System;
using System.IO;
using System.Linq;
using System.Net;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace GuildLounge
{
    public class ExtensionUpdater
    {
        private static readonly WebClient _client = new WebClient();
        private static string _extDir = Path.Combine(Properties.Settings.Default.GameDir, "bin64");
        public Extension[] StoredExtensions { get; set; }

        public ExtensionUpdater() { }

        public Task UpdateExtensions(Extension[] extensions, bool checkForLastModified)
        {
            Console.WriteLine("[ADDONS: INIT]");
            DateTime dt = DateTime.Now;
            bool d3d9 = false;

            int j = 1;
            for (int i = 0; i < extensions.Length; i++)
            {
                //Renaming duplicate d3d9.DLLs
                string name = extensions[i].Link.ToString();
                if (d3d9 && name.EndsWith("d3d9.dll"))
                {
                    if(extensions[i].Name != null || extensions[i].Name != "")
                    {
                        //Substitutional name
                        name = name.Substring(name.LastIndexOf("/") + 1);
                        name = name.Insert(name.IndexOf("."), "_" + extensions[i].Name);
                    }
                    else
                    {
                        //"_chainload" suffix
                        name = name.Substring(name.LastIndexOf("/") + 1);
                        name = name.Insert(name.IndexOf("."), "_chainload" + j.ToString());
                        j++;
                    }
                }
                else
                    name = name.Substring(name.LastIndexOf("/") + 1);

                if (checkForLastModified)
                {
                    HttpWebRequest req = (HttpWebRequest)WebRequest.Create(new Uri(extensions[i].Link));
                    WebResponse resp = (HttpWebResponse)req.GetResponse();
                    
                    if (resp.Headers.AllKeys.Contains("Last-Modified")
                        && File.Exists(Path.Combine(_extDir, name)))
                    {
                        DateTime dtOnline = Convert.ToDateTime(resp.Headers.Get("Last-Modified"));
                        if (dtOnline > extensions[i].LastChecked)
                        {
                            _client.DownloadFile(extensions[i].Link, Path.Combine(_extDir, name));
                            Console.WriteLine("[ADDON: OUTDATED]");
                        }
                        else
                        {
                            Console.WriteLine("[ADDON: UP-TO-DATE]");
                        }
                    }
                    else
                    {
                        _client.DownloadFile(extensions[i].Link, Path.Combine(_extDir, name));
                        Console.WriteLine("[ADDON: NOT CHECKED]");
                    }

                    resp.Close();
                }
                else
                {
                    _client.DownloadFile(extensions[i].Link, Path.Combine(_extDir, name));
                    Console.WriteLine("[ADDON: DOWNLOADED]");
                }

                extensions[i].LastChecked = DateTime.Now;

                if (extensions[i].Link.Contains("deltaconnected.com/arcdps/x64/d3d9.dll"))
                    d3d9 = true;
            }
            StoredExtensions = extensions;
            Console.WriteLine("[ADDONS: " + (DateTime.Now - dt).TotalSeconds + "]");
            return Task.FromResult(0);
        }
    }

    public class Extension
    {
        private string m_sLink { get; set; }

        public string Name { get; set; }
        public DateTime LastChecked { get; set; }
        public string Link
        {
            get
            {
                return m_sLink;
            }
            set
            {
                if (CheckLink(value))
                    m_sLink = value;
                else
                    throw new Exception("Invalid Link!");
            }
        }

        private bool CheckLink(string l)
        {
            return Regex.IsMatch(l, @"(http(s)?:\/\/)?(www.)?[\w-_\/]*.dll");
        }
    }
}
