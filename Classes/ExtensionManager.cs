﻿using System;
using System.IO;
using System.Linq;
using System.Net;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace GuildLounge
{
    public static class ExtensionManager
    {
        private static string _ExtDir = Path.Combine(Properties.Settings.Default.GameDir, "bin64");
        private static WebClient _Client = new WebClient();
        public static string Status { get; set; }
        public static bool Working { get; set; }

        public static async void UpdateExtensions(Extension[] extensions, bool checkForLastModified)
        {
            await Task.Run(() =>
            {
                DateTime dt = DateTime.Now;
                Working = true;

                bool d3d9 = false;
                int amtUpdated = 0;
                int chainload = 1;

                for (int i = 0; i < extensions.Length; i++)
                {
                    Status = $"{i + 1}/{extensions.Length} done.";

                    string name = extensions[i].Link;
                    name = name.Substring(name.LastIndexOf("/") + 1);

                    //If there's already an extension called "d3d9.dll" we give it a substitutional name
                    if (d3d9 && (name == "d3d9.dll"))
                    {
                        //Either use the provided alternative name or a generic suffix
                        if (!String.IsNullOrEmpty(extensions[i].Name))
                            name = name.Insert(name.IndexOf("."), "_" + extensions[i].Name);
                        else
                            name = name.Insert(name.IndexOf("."), "_chainload" + chainload++);
                    }
                    else
                    {
                        if (name == "d3d9.dll")
                            d3d9 = true;
                    }

                    if (checkForLastModified)
                    {
                        HttpWebRequest req = (HttpWebRequest)WebRequest.Create(new Uri(extensions[i].Link));
                        WebResponse resp = (HttpWebResponse)req.GetResponse();

                        if (resp.Headers.AllKeys.Contains("Last-Modified")
                            && File.Exists(Path.Combine(_ExtDir, name)))
                        {
                            DateTime dtOnline = Convert.ToDateTime(resp.Headers.Get("Last-Modified"));
                            if (dtOnline > File.GetLastWriteTime(Path.Combine(_ExtDir, name)))
                            {
                                _Client.DownloadFile(extensions[i].Link, Path.Combine(_ExtDir, name));
                                Console.WriteLine("[EXT: OUTDATED]");
                                amtUpdated++;
                            }
                            else
                            {
                                Console.WriteLine("[EXT: UP-TO-DATE]");
                            }
                        }
                        else
                        {
                            _Client.DownloadFile(extensions[i].Link, Path.Combine(_ExtDir, name));
                            Console.WriteLine("[EXT: NOT CHECKED]");
                            amtUpdated++;
                        }

                        resp.Close();
                    }
                    else
                    {
                        _Client.DownloadFile(extensions[i].Link, Path.Combine(_ExtDir, name));
                        Console.WriteLine("[EXT: DOWNLOADED]");
                        amtUpdated++;
                    }
                }

                if (amtUpdated > 0)
                    Status = $"{amtUpdated} updated.";
                else
                    Status = $"Up-To-Date.";

                Working = false;
                Console.WriteLine("[EXT: " + (DateTime.Now - dt).TotalSeconds + "]");
            });
        }
    }

    public class Extension
    {
        private string m_sLink { get; set; }

        public string Name { get; set; }
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

        public override string ToString()
        {
            if (!string.IsNullOrEmpty(Name) && !string.IsNullOrWhiteSpace(Name))
                return Name;
            else
                return m_sLink;
        }
    }
}
