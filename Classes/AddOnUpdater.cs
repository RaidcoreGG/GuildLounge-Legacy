using System;
using System.IO;
using System.Linq;
using System.Net;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace GuildLounge
{
    public class AddOnUpdater
    {
        private static readonly WebClient _client = new WebClient();
        private static string _addonDir = Path.Combine(Properties.Settings.Default.GameDir, "bin64");
        //OBSOLETE IF UPDATEADDONS() WOULD RETURN THE PROCESSED ADDONS
        public AddOn[] AddOns { get; set; }

        public AddOnUpdater()
        {
            
        }

        public Task UpdateAddOns(AddOn[] addOns, bool checkForLastModified)
        {
            Console.WriteLine("[ADDONS: INIT]");
            DateTime dt = DateTime.Now;
            bool arc = false;

            //FIX ARRAY SO IF IT CONTAINS ARCDPS, ARC WILL ALWAYS BE PROCESSED FIRST
            //BECAUSE ARC IS CHAINLOADING OTHER ADDONS
            AddOn pos0 = addOns[0];
            for (int i = 0; i < addOns.Length; i++)
            {
                if (addOns[i].Link.Contains("deltaconnected.com/arcdps/x64/d3d9.dll"))
                {
                    addOns[0] = addOns[i];
                    addOns[i] = pos0;
                }
            }

            int j = 1;
            for (int i = 0; i < addOns.Length; i++)
            {
                string n = addOns[i].Link.ToString();
                //RENAME DUPLICATE D3D9.DLLS
                if (arc && n.EndsWith("d3d9.dll"))
                {
                    n = n.Substring(n.LastIndexOf("/") + 1);
                    n = n.Insert(n.IndexOf("."), "_chainload" + j.ToString());
                    j++;
                }
                else
                    n = n.Substring(n.LastIndexOf("/") + 1);

                if (checkForLastModified)
                {
                    HttpWebRequest req = (HttpWebRequest)WebRequest.Create(new Uri(addOns[i].Link));
                    WebResponse resp = (HttpWebResponse)req.GetResponse();
                    
                    if (resp.Headers.AllKeys.Contains("Last-Modified")
                        && File.Exists(Path.Combine(_addonDir, n)))
                    {
                        DateTime dtOnline = Convert.ToDateTime(resp.Headers.Get("Last-Modified"));
                        if (dtOnline > addOns[i].LastChecked)
                        {
                            _client.DownloadFile(addOns[i].Link, Path.Combine(_addonDir, n));
                            Console.WriteLine("[ADDON: OUTDATED]");
                        }
                        else
                        {
                            Console.WriteLine("[ADDON: UP-TO-DATE]");
                        }
                    }
                    else
                    {
                        _client.DownloadFile(addOns[i].Link, Path.Combine(_addonDir, n));
                        Console.WriteLine("[ADDON: NOT CHECKED]");
                    }

                    resp.Close();
                    resp.Dispose();
                }
                else
                {
                    _client.DownloadFile(addOns[i].Link, Path.Combine(_addonDir, n));
                    Console.WriteLine("[ADDON: DOWNLOADED]");
                }

                addOns[i].LastChecked = DateTime.Now;

                if (addOns[i].Link.Contains("deltaconnected.com/arcdps/x64/d3d9.dll"))
                    arc = true;
            }
            AddOns = addOns;
            Console.WriteLine("[ADDONS: " + (DateTime.Now - dt).TotalSeconds + "]");
            return Task.FromResult(0);
        }
    }

    public class AddOn
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
