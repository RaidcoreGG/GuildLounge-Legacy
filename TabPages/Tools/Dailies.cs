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
            Achievement[] resolvedDailies = await _api.GetResponse<Achievement[]>("achievements", "ids=" + MergeDailyIDs(APIResponse));
            APIResponse = JoinDailies(APIResponse, resolvedDailies);
            APIResponse.fractals = ReduceFractals(APIResponse);
            AssignDailies(APIResponse);
        }

        private string MergeDailyIDs(GuildLounge.Dailies dailies)
        {
            string ids = "";
            foreach (Achievement a in dailies.pve)
                ids += a.id + ",";
            foreach (Achievement a in dailies.pvp)
                ids += a.id + ",";
            foreach (Achievement a in dailies.wvw)
                ids += a.id + ",";
            foreach (Achievement a in dailies.fractals)
                ids += a.id + ",";

            return ids.TrimEnd(Convert.ToChar(","));
        }

        private GuildLounge.Dailies JoinDailies(GuildLounge.Dailies dailies, Achievement[] resolvedIDs)
        {
            foreach (Achievement a in dailies.pve)
                a.name = resolvedIDs[Array.FindIndex(resolvedIDs, r => r.id == a.id)].name;
            foreach (Achievement a in dailies.pvp)
                a.name = resolvedIDs[Array.FindIndex(resolvedIDs, r => r.id == a.id)].name;
            foreach (Achievement a in dailies.wvw)
                a.name = resolvedIDs[Array.FindIndex(resolvedIDs, r => r.id == a.id)].name;
            foreach (Achievement a in dailies.fractals)
                a.name = resolvedIDs[Array.FindIndex(resolvedIDs, r => r.id == a.id)].name;

            return dailies;
        }

        private Achievement[] ReduceFractals(GuildLounge.Dailies dailies)
        {
            Achievement[] fracs = new Achievement[6];
            //SET EMPTY OBJECTS TO PREVENT NULL REFERENCE
            for (int j = 0; j < fracs.Length; j++)
                fracs[j] = new Achievement();

            int i = 0;
            foreach (Achievement a in dailies.fractals)
            {
                if (a.name.Contains("Tier"))
                {
                    a.name = a.name.Remove(a.name.IndexOf("Tier"), 7);
                    if (!Array.Exists(fracs, f => f.name == a.name))
                    {
                        fracs[i] = a;
                        i++;
                    }
                }
                else if (a.name.Contains("Recommended"))
                {
                    a.name = a.name.Remove(a.name.IndexOf("Fractal"), 8);
                    fracs[i] = a;
                    i++;
                }
            }

            return fracs;
        }

        private void AssignDailies(GuildLounge.Dailies dailies)
        {
            Point col1 = new Point(70, 30);
            Point col2 = new Point(274, 30);
            Point col3 = new Point(478, 30);

            Control[] dailyModules = new Control[24];
            int i = 0;
            foreach (Achievement a in dailies.pve)
            {
                dailyModules[i] = new Controls.DailyModule() { Location = col1, Category = "pve", Title = a.name.Substring(6)};
                col1.Y += 38;
                i++;
            }
            foreach (Achievement a in dailies.pvp)
            {
                dailyModules[i] = new Controls.DailyModule() { Location = col2, Category = "pvp", Title = a.name.Substring(6) };
                col2.Y += 38;
                i++;
            }
            foreach (Achievement a in dailies.wvw)
            {
                dailyModules[i] = new Controls.DailyModule() { Location = col2, Category = "wvw", Title = a.name.Substring(6) };
                col2.Y += 38;
                i++;
            }
            foreach (Achievement a in dailies.fractals)
            {
                dailyModules[i] = new Controls.DailyModule() { Location = col3, Category = "fractals", Title = a.name.Substring(6) };
                col3.Y += 38;
                i++;
            }

            labelInfo.Location = new Point(labelInfo.Location.X, col1.Y + 6);

            Controls.AddRange(dailyModules);
        }
    }
}
