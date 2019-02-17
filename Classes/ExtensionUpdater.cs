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
        //OBSOLETE IF UPDATEADDONS() WOULD RETURN THE PROCESSED ADDONS
        public Extension[] StoredExtensions { get; set; }

        public ExtensionUpdater()
        {
            
        }

        public Task UpdateExtensions(Extension[] extensions, bool checkForLastModified)
        {
            Console.WriteLine("[ADDONS: INIT]");
            DateTime dt = DateTime.Now;
            bool arc = false;

            //FIX ARRAY SO IF IT CONTAINS ARCDPS, ARC WILL ALWAYS BE PROCESSED FIRST
            //BECAUSE ARC IS CHAINLOADING OTHER ADDONS
            Extension pos0 = extensions[0];
            for (int i = 0; i < extensions.Length; i++)
            {
                if (extensions[i].Link.Contains("deltaconnected.com/arcdps/x64/d3d9.dll"))
                {
                    extensions[0] = extensions[i];
                    extensions[i] = pos0;
                }
            }

            int j = 1;
            for (int i = 0; i < extensions.Length; i++)
            {
                string n = extensions[i].Link.ToString();
                //RENAME DUPLICATE D3D9.DLLS
                if (arc && n.EndsWith("d3d9.dll"))
                {
                    if(extensions[i].Name != null || extensions[i].Name != "")
                    {
                        n = n.Substring(n.LastIndexOf("/") + 1);
                        n = n.Insert(n.IndexOf("."), "_" + extensions[i].Name);
                    }
                    else
                    {
                        n = n.Substring(n.LastIndexOf("/") + 1);
                        n = n.Insert(n.IndexOf("."), "_chainload" + j.ToString());
                        j++;
                    }
                }
                else
                    n = n.Substring(n.LastIndexOf("/") + 1);

                if (checkForLastModified)
                {
                    HttpWebRequest req = (HttpWebRequest)WebRequest.Create(new Uri(extensions[i].Link));
                    WebResponse resp = (HttpWebResponse)req.GetResponse();
                    
                    if (resp.Headers.AllKeys.Contains("Last-Modified")
                        && File.Exists(Path.Combine(_extDir, n)))
                    {
                        DateTime dtOnline = Convert.ToDateTime(resp.Headers.Get("Last-Modified"));
                        if (dtOnline > extensions[i].LastChecked)
                        {
                            _client.DownloadFile(extensions[i].Link, Path.Combine(_extDir, n));
                            Console.WriteLine("[ADDON: OUTDATED]");
                        }
                        else
                        {
                            Console.WriteLine("[ADDON: UP-TO-DATE]");
                        }
                    }
                    else
                    {
                        _client.DownloadFile(extensions[i].Link, Path.Combine(_extDir, n));
                        Console.WriteLine("[ADDON: NOT CHECKED]");
                    }

                    resp.Close();
                    resp.Dispose();
                }
                else
                {
                    _client.DownloadFile(extensions[i].Link, Path.Combine(_extDir, n));
                    Console.WriteLine("[ADDON: DOWNLOADED]");
                }

                extensions[i].LastChecked = DateTime.Now;

                if (extensions[i].Link.Contains("deltaconnected.com/arcdps/x64/d3d9.dll"))
                    arc = true;
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
