using System;
using System.Diagnostics;
using System.Net;
using System.Reflection;
using System.IO;

namespace GuildLoungeUpdater
{
    class Program
    {
        private static readonly WebClient _client = new WebClient();

        static void Main(string[] args)
        {
            var version = Assembly.GetExecutingAssembly().GetName().Version;
            string v = "Guild Lounge Updater v" + version.Build + "." + version.Revision;
            Console.WriteLine(v + "\n");
            if (args.Length > 0)
            {
                string target = args[0];

                try
                {
                    Console.WriteLine("Executing path: " + target);
                    if (target.EndsWith(".lnk"))
                    {
                        Console.WriteLine("Resolving shortcut...");
                        IWshRuntimeLibrary.IWshShell shell = new IWshRuntimeLibrary.WshShell();
                        IWshRuntimeLibrary.IWshShortcut shortcut = (IWshRuntimeLibrary.IWshShortcut)shell.CreateShortcut(target);
                        target = shortcut.TargetPath;

                        Console.WriteLine("Shortcut target: " + target);
                    }

                    Console.WriteLine("Getting processes...");
                    Process[] running = Process.GetProcessesByName("GuildLounge");

                    Console.WriteLine("Waiting for processes to exit...");
                    foreach (Process p in running)
                    {
                        p.Kill();
                        p.WaitForExit();
                    }

                    Console.WriteLine("Downloading executable...");
                    _client.DownloadFile("http://dev.guildlounge.com/GuildLounge.exe", target);
                }
                finally
                {
                    Console.WriteLine("Running executable...");
                    Process.Start(target);
                }
            }
        }
    }
}