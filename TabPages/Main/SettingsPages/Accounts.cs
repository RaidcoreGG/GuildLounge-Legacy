using System;
using System.Collections.Generic;
using System.IO;
using System.Web.Script.Serialization;
using System.Windows.Forms;

namespace GuildLounge.TabPages.SettingsPages
{
    public partial class Accounts : UserControl
    {
        private static string _appdata = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "GuildLounge");
        public Account[] StoredAccounts { get; set; }

        public Accounts()
        {
            InitializeComponent();

            try
            {
                LoadAccounts();
            }
            catch (Exception exc)
            {
                Console.WriteLine(exc.Message);
            }
        }

        public void LoadAccounts()
        {
            //Deserialize accounts and load them
            StoredAccounts = new JavaScriptSerializer().Deserialize<List<Account>>(File.ReadAllText(Path.Combine(_appdata, "accounts.json"))).ToArray();
            listBoxAccounts.Items.AddRange(StoredAccounts);
        }

        public void SaveAccounts()
        {
            if (listBoxAccounts.Items.Count > 0)
            {
                //Reinitialize array with accounts from listbox
                StoredAccounts = new Account[listBoxAccounts.Items.Count];
                for (int i = 0; i < listBoxAccounts.Items.Count; i++)
                    StoredAccounts[i] = (Account)listBoxAccounts.Items[i];

                //Serialize json and write to file
                string parsedKeys = new JavaScriptSerializer().Serialize(StoredAccounts);
                File.WriteAllText(Path.Combine(_appdata, "accounts.json"), parsedKeys);
            }
            else
            {
                //Write empty json
                File.WriteAllText(Path.Combine(_appdata, "accounts.json"), "[]");
                StoredAccounts = null;
            }

            //Call parent to refetch accounts
            var obj = (Settings)Parent;
            obj.RefetchAccounts();
        }
        
        private void buttonAddAccount_Click(object sender, EventArgs e)
        {
            try
            {
                //Create new account object from values
                listBoxAccounts.Items.Add(new Account {
                    Name = textBoxName.Text,
                    Key = textBoxAPIKey.Text
                });

                //Get permissions of last added key
                FetchPermissionsProxy();
                
                //Clear textboxes
                textBoxName.Clear();
                textBoxAPIKey.Clear();

                SaveAccounts();
            }
            catch (Exception exc)
            {
                labelError.Text = exc.Message;
                Utility.TimeoutToDisappear(labelError);
            }
        }

        private async void FetchPermissionsProxy()
        {
            try
            {
                //Get permissions of last added key
                ((Account)listBoxAccounts.Items[listBoxAccounts.Items.Count - 1]).Permissions =
                await Account.FetchPermissions(((Account)listBoxAccounts.Items[listBoxAccounts.Items.Count - 1]).Key);
            }
            catch
            {
                //Set the selected index and invoke edit
                listBoxAccounts.SelectedIndex = listBoxAccounts.Items.Count - 1;
                buttonEditAccount_Click(null, null);

                labelError.Text = "Invalid API-Key.";
                Utility.TimeoutToDisappear(labelError);
            }
            SaveAccounts();
        }

        private void buttonRemoveAccount_Click(object sender, EventArgs e)
        {
            if (listBoxAccounts.SelectedIndex >= 0)
            {
                listBoxAccounts.Items.RemoveAt(listBoxAccounts.SelectedIndex);
                SaveAccounts();
            }
        }

        private void buttonEditAccount_Click(object sender, EventArgs e)
        {
            if (listBoxAccounts.SelectedIndex >= 0)
            {
                //Load selected values of selected account into textboxes
                var obj = (Account)listBoxAccounts.Items[listBoxAccounts.SelectedIndex];
                textBoxName.Text = obj.Name;
                textBoxAPIKey.Text = obj.Key;

                //Remove selected account
                listBoxAccounts.Items.Remove(obj);

                SaveAccounts();
            }
            else
            {
                labelError.Text = "Select an account to edit first!";
                Utility.TimeoutToDisappear(labelError);
            }
        }

        private void listBoxAccounts_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(listBoxAccounts.SelectedIndex >= 0)
            {
                //Load permissions of selected key for display
                var obj = (Account)listBoxAccounts.Items[listBoxAccounts.SelectedIndex];
                if (obj.Permissions != null)
                    apiKeyInfo.UpdatePermissions(obj.Permissions);

                //Set linked .DAT file name
                string gw2appdata = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "Guild Wars 2");
                string locl;
                if (obj.Name != null && obj.Name != "")
                    locl = obj.Name + "_Local.dat";
                else
                    locl = obj.Key.Substring(56) + "_Local.dat";

                //Display if a .DAT file is linked
                if (File.Exists(Path.Combine(_appdata, locl)))
                    labelDatFile.Text = locl;
                else
                    labelDatFile.Text = "not linked";
            }
        }

        private void buttonLinkCurrentDAT_Click(object sender, EventArgs e)
        {
            try
            {
                if (listBoxAccounts.SelectedIndex >= 0)
                {
                    //Set linked .DAT file name
                    var obj = (Account)listBoxAccounts.Items[listBoxAccounts.SelectedIndex];
                    string locl;
                    if (obj.Name != null && obj.Name != "")
                        locl = obj.Name + "_Local.dat";
                    else
                        locl = obj.Key.Substring(56) + "_Local.dat";

                    //Copy Local.dat to create USER_Local.dat
                    string gw2appdata = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "Guild Wars 2");
                    if (!File.Exists(Path.Combine(_appdata, locl)))
                        File.Copy(Path.Combine(gw2appdata, "Local.dat"), Path.Combine(_appdata, locl));
                    else if(MessageBox.Show("Overwrite linked Local.dat?", "Account Quick-Switching", MessageBoxButtons.OKCancel) == DialogResult.OK)
                    {
                        File.Delete(Path.Combine(_appdata, locl));
                        File.Copy(Path.Combine(gw2appdata, "Local.dat"), Path.Combine(_appdata, locl));
                    }
                }
                else
                {
                    labelLinkingError.Text = "Select an account to link first!";
                    Utility.TimeoutToDisappear(labelLinkingError);
                }
            }
            catch (Exception exc)
            {
                labelLinkingError.Text = exc.Message;
                Utility.TimeoutToDisappear(labelLinkingError);
            }
        }

        private void buttonUnlinkDAT_Click(object sender, EventArgs e)
        {
            try
            {
                if(listBoxAccounts.SelectedIndex >= 0)
                {
                    //Set linked .DAT file name
                    var obj = (Account)listBoxAccounts.Items[listBoxAccounts.SelectedIndex];
                    string locl;
                    if (obj.Name != null && obj.Name != "")
                        locl = obj.Name + "_Local.dat";
                    else
                        locl = obj.Key.Substring(56) + "_Local.dat";

                    //Delete USER_Local.dat
                    if (File.Exists(Path.Combine(_appdata, locl)))
                        File.Delete(Path.Combine(_appdata, locl));
                }
                else
                {
                    labelLinkingError.Text = "Select an account to unlink first!";
                    Utility.TimeoutToDisappear(labelLinkingError);
                }
            }
            catch (Exception exc)
            {
                labelLinkingError.Text = exc.Message;
                Utility.TimeoutToDisappear(labelLinkingError);
            }
        }

        private void linkLabelQuickSwitchingHelp_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Help.AccountQuickSwitching help = new Help.AccountQuickSwitching();
            help.StartPosition = FormStartPosition.CenterParent;
            help.ShowDialog();
        }
    }
}
