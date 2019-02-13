using System.Windows.Forms;

namespace GuildLounge.Controls
{
    public partial class ApiKeyInfo : UserControl
    {
        public ApiKeyInfo()
        {
            InitializeComponent();
        }

        public void UpdatePermissions(string permissions)
        {
            panelAccount.Allowed = permissions.Contains("account");
            panelInventories.Allowed = permissions.Contains("inventories");
            panelCharacters.Allowed = permissions.Contains("characters");
            panelTradingPost.Allowed = permissions.Contains("tradingpost");
            panelWallet.Allowed = permissions.Contains("wallet");

            panelUnlocks.Allowed = permissions.Contains("unlocks");
            panelPvP.Allowed = permissions.Contains("pvp");
            panelBuilds.Allowed = permissions.Contains("builds");
            panelProgression.Allowed = permissions.Contains("progression");
            panelGuilds.Allowed = permissions.Contains("guilds");
        }
    }
}
