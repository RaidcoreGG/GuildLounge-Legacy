using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GuildLounge
{
    public partial class ModuleDailies : UserControl
    {
        private static readonly ApiHandler _api = new ApiHandler();
        private static AchievementObject dailies;

        public string DailyType { get; set; }

        private ApiEntry m_oActiveKey;
        public ApiEntry ActiveAPIEntry
        {
            get { return m_oActiveKey; }
            set
            {
                //SET VALUES
                m_oActiveKey = value;

                //UPDATA DATA
                UpdateDailies();
            }
        }

        private async Task<AchievementObject> GetDailiesAsync()
        {
            if (dailies == null)
            {
                dailies = await _api.GetResponse<AchievementObject>("achievements/daily");
            }
            return dailies;
        }

        private async void UpdateDailies()
        {
            var dailies = await GetDailiesAsync();

            var dailiesDetail = await _api.GetResponse<AchievementDetail[]>("achievements", GetAchievementParam(dailies.pve));

            foreach (var a in dailiesDetail)
            {
                Label achievementName = new Label();
                achievementName.Text = a.name;
                achievementName.AutoSize = true;
                Console.WriteLine(achievementName.Text);
                tableLayoutPanelDaily.Controls.Add(achievementName);
            }
        }

        private string GetAchievementParam(List<Achievement> achievements)
        {
            string[] ids = achievements.Select(x => x.id.ToString()).ToArray();
            return "ids=" + String.Join(",", ids);
        }

        public ModuleDailies(string label, string endPoint)
        {
            InitializeComponent();
        }
    }
}
