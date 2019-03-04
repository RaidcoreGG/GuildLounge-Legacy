using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GuildLounge.TabPages.Tools
{
    public partial class Dailies : UserControl
    {
        private static readonly ApiHandler _api = new ApiHandler();

        public Dailies()
        {
            InitializeComponent();

            FetchDailies();
        }

        private async void FetchDailies()
        {
            GuildLounge.Dailies APIResponse = await _api.GetResponse<GuildLounge.Dailies>("achievements/daily");
            Achievement[] resolvedDailies = await _api.GetResponse<Achievement[]>("achievements", "ids=" + GetAllIDs(APIResponse));
            APIResponse = JoinDailies(APIResponse, resolvedDailies);
            APIResponse.PvE = ReducePvE(APIResponse);
            APIResponse.PvE = ShortenNamesPvE(APIResponse);
            APIResponse.Fractals = ReduceFractals(APIResponse);
            InitializeDailies(APIResponse);
        }

        private string GetAllIDs(GuildLounge.Dailies dailies)
        {
            string ids = "";
            foreach (Achievement a in dailies.PvE)
                ids += a.Id + ",";
            foreach (Achievement a in dailies.PvP)
                ids += a.Id + ",";
            foreach (Achievement a in dailies.WvW)
                ids += a.Id + ",";
            foreach (Achievement a in dailies.Fractals)
                ids += a.Id + ",";

            return ids.TrimEnd(Convert.ToChar(","));
        }

        private GuildLounge.Dailies JoinDailies(GuildLounge.Dailies dailies, Achievement[] resolvedIDs)
        {
            foreach (Achievement a in dailies.PvE)
                a.Name = resolvedIDs[Array.FindIndex(resolvedIDs, r => r.Id == a.Id)].Name;
            foreach (Achievement a in dailies.PvP)
                a.Name = resolvedIDs[Array.FindIndex(resolvedIDs, r => r.Id == a.Id)].Name;
            foreach (Achievement a in dailies.WvW)
                a.Name = resolvedIDs[Array.FindIndex(resolvedIDs, r => r.Id == a.Id)].Name;
            foreach (Achievement a in dailies.Fractals)
                a.Name = resolvedIDs[Array.FindIndex(resolvedIDs, r => r.Id == a.Id)].Name;

            return dailies;
        }

        private Achievement[] ReducePvE(GuildLounge.Dailies dailies)
        {
            Achievement[] pve = new Achievement[dailies.PvE.Length];
            //SET EMPTY OBJECTS TO PREVENT NULL REFERENCE
            for (int j = 0; j < pve.Length; j++)
                pve[j] = new Achievement();

            int i = 0;
            foreach (Achievement a in dailies.PvE)
            {
                if (!Array.Exists(pve, d => d.Name == a.Name))
                {
                    pve[i] = a;
                    i++;
                }
            }

            Achievement[] pveFix = new Achievement[i];
            for (int j = 0; j < pveFix.Length; j++)
                pveFix[j] = pve[j];

            return pveFix;
        }

        private Achievement[] ShortenNamesPvE(GuildLounge.Dailies dailies)
        {
            Achievement[] pve = new Achievement[dailies.PvE.Length];
            //SET EMPTY OBJECTS TO PREVENT NULL REFERENCE
            for (int j = 0; j < pve.Length; j++)
                pve[j] = new Achievement();

            int i = 0;
            foreach (Achievement a in dailies.PvE)
            {
                if (a.Name.Contains("Event Completer"))
                    a.Name = (a.Name.Remove(a.Name.IndexOf("Event Completer")) + "Events");
                else if (a.Name.Contains("Jumping Puzzle"))
                    a.Name = (a.Name.Remove(a.Name.IndexOf("Jumping Puzzle")) + "JP");
                pve[i] = a;
                i++;
            }

            Achievement[] pveFix = new Achievement[i];
            for (int j = 0; j < pveFix.Length; j++)
                pveFix[j] = pve[j];

            return pveFix;
        }

        private Achievement[] ReduceFractals(GuildLounge.Dailies dailies)
        {
            Achievement[] fracs = new Achievement[6];
            //SET EMPTY OBJECTS TO PREVENT NULL REFERENCE
            for (int j = 0; j < fracs.Length; j++)
                fracs[j] = new Achievement();

            int i = 0;
            foreach (Achievement a in dailies.Fractals)
            {
                if (a.Name.Contains("Tier"))
                {
                    a.Name = a.Name.Remove(a.Name.IndexOf("Tier"), 7);
                    if (!Array.Exists(fracs, f => f.Name == a.Name))
                    {
                        fracs[i] = a;
                        i++;
                    }
                }
                else if (a.Name.Contains("Recommended"))
                {
                    a.Name = a.Name.Remove(a.Name.IndexOf("Fractal"), 8);
                    fracs[i] = a;
                    i++;
                }
            }

            return fracs;
        }

        private void InitializeDailies(GuildLounge.Dailies dailies)
        {
            Point col1 = new Point(70, 30);
            Point col2 = new Point(274, 30);
            Point col3 = new Point(478, 30);

            Control[] dailyModules = new Control[24];
            int i = 0;
            foreach (Achievement a in dailies.PvE)
            {
                dailyModules[i] = new Controls.DailyModule() { Location = col1, Category = "pve", Title = a.Name.Substring(6)};
                col1.Y += 38;
                i++;
            }
            foreach (Achievement a in dailies.PvP)
            {
                dailyModules[i] = new Controls.DailyModule() { Location = col2, Category = "pvp", Title = a.Name.Substring(6) };
                col2.Y += 38;
                i++;
            }
            foreach (Achievement a in dailies.WvW)
            {
                dailyModules[i] = new Controls.DailyModule() { Location = col2, Category = "wvw", Title = a.Name.Substring(6) };
                col2.Y += 38;
                i++;
            }
            foreach (Achievement a in dailies.Fractals)
            {
                dailyModules[i] = new Controls.DailyModule() { Location = col3, Category = "fractals", Title = a.Name.Substring(6) };
                col3.Y += 38;
                i++;
            }

            if (col1.Y < col2.Y)
                labelInfo.Location = new Point(labelInfo.Location.X, col2.Y + 6);
            else
                labelInfo.Location = new Point(labelInfo.Location.X, col1.Y + 6);

            Controls.AddRange(dailyModules);
        }
    }
}