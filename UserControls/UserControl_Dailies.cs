using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GuildLounge
{
    public partial class UserControl_Dailies : UserControl
    {
        private static readonly ApiHandler _api = new ApiHandler();
                
        private async void UpdateDailies()
        {
            var dailies = await _api.GetResponse<DailyAchievementObject>("achievements/daily");

            var pveDailies = await _api.GetResponse<List<Achievement>>("achievements", GetAchievementParam(dailies.pve));
            var pvpDailies = await _api.GetResponse<List<Achievement>>("achievements", GetAchievementParam(dailies.pvp));
            var wvwDailies = await _api.GetResponse<List<Achievement>>("achievements", GetAchievementParam(dailies.wvw));
            var fractalDailies = await _api.GetResponse<List<Achievement>>("achievements", GetAchievementParam(dailies.fractals));

            foreach (var a in pveDailies)
            {
                Label achievementName = new Label();
                achievementName.Text = a.name;
                achievementName.BackColor = Color.Transparent;
                achievementName.AutoSize = true;
                GL_TableLayoutPvE.Controls.Add(achievementName);
            }

            foreach (var a in pvpDailies)
            {
                Label achievementName = new Label();
                achievementName.Text = a.name;
                achievementName.BackColor = Color.Transparent;
                achievementName.AutoSize = true;
                GL_TableLayoutPvP.Controls.Add(achievementName);
            }

            foreach (var a in wvwDailies)
            {
                Label achievementName = new Label();
                achievementName.Text = a.name;
                achievementName.BackColor = Color.Transparent;
                achievementName.AutoSize = true;
                GL_TableLayoutWvW.Controls.Add(achievementName);
            }

            HashSet<string> reducedFractalDailies = new HashSet<string>();
            Regex fractalRegex = new Regex(@".*Tier \d ");
            foreach (var a in fractalDailies)
            {
                string match = fractalRegex.Match(a.name).ToString();
                if (match != "")
                {
                    string fractalDesc = $"Daily {a.name.Replace(match, "")} Fractal";
                    reducedFractalDailies.Add(fractalDesc);
                }
                else
                {
                    reducedFractalDailies.Add(a.name);
                }
            }

            foreach (var a in reducedFractalDailies)
            {
                Label achievementName = new Label();
                achievementName.Text = a;
                achievementName.BackColor = Color.Transparent;
                achievementName.AutoSize = true;
                GL_TableLayoutFractals.Controls.Add(achievementName);
            }
        }

        private string GetAchievementParam(List<Achievement> achievements)
        {
            string[] ids = achievements.Select(x => x.id.ToString()).ToArray();
            return "ids=" + String.Join(",", ids);
        }

        public UserControl_Dailies()
        {
            InitializeComponent();
            GL_TableLayoutPvE.BorderStyle = BorderStyle.FixedSingle;
            GL_TableLayoutPvP.BorderStyle = BorderStyle.FixedSingle;
            GL_TableLayoutWvW.BorderStyle = BorderStyle.FixedSingle;
            GL_TableLayoutFractals.BorderStyle = BorderStyle.FixedSingle;
            UpdateDailies();
        }
    }
}
