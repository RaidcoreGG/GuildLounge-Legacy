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
            panelAccount.Active = permissions.Contains("account");
            panelInventories.Active = permissions.Contains("inventories");
            panelCharacters.Active = permissions.Contains("characters");
            panelTradingPost.Active = permissions.Contains("tradingpost");
            panelWallet.Active = permissions.Contains("wallet");
        }
    }
}
