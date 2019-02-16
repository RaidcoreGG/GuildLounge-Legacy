using System;
using System.IO;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Web.Script.Serialization;

namespace GuildLounge.TabPages.SettingsPages
{
    public partial class Accounts : UserControl
    {
        private static string _appdata = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "GuildLounge");
        private bool m_bHidePassword { get; set; }
        public Account[] StoredAccounts { get; set; }

        public Accounts()
        {
            InitializeComponent();
            m_bHidePassword = true;

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
            //READ API KEYS FROM FILE AND ADD THEM TO THE LISTBOX
            StoredAccounts = new JavaScriptSerializer().Deserialize<List<Account>>(File.ReadAllText(Path.Combine(_appdata, "api_keys.json"))).ToArray();
            listBoxAccounts.Items.AddRange(StoredAccounts);
        }

        public void SaveAccounts()
        {
            if (listBoxAccounts.Items.Count > 0)
            {
                //REINITIALIZE ARRAY WITH EDITED/UPDATED VALUES FROM THE LISTBOX
                StoredAccounts = new Account[listBoxAccounts.Items.Count];
                for (int i = 0; i < listBoxAccounts.Items.Count; i++)
                    StoredAccounts[i] = (Account)listBoxAccounts.Items[i];

                //PARSE TO JSON AND WRITE TO FILE
                string parsedKeys = new JavaScriptSerializer().Serialize(StoredAccounts);
                File.WriteAllText(Path.Combine(_appdata, "api_keys.json"), parsedKeys);
            }
            else
            {
                //WRITE AN EMPTY JSON OBJECT TO FILE
                File.WriteAllText(Path.Combine(_appdata, "api_keys.json"), "[]");
                StoredAccounts = null;
            }

            //CALLING MAIN FORM TO REFRESH KEYS
            var obj = (Settings)Parent;
            obj.RefetchAccounts();
        }
        
        private void buttonAddAccount_Click(object sender, EventArgs e)
        {
            try
            {
                listBoxAccounts.Items.Add(new Account {
                    Name = textBoxName.Text,
                    Key = textBoxAPIKey.Text,
                    Email = textBoxEmail.Text,
                    Password = textBoxPassword.Text
                });

                textBoxName.Clear();
                textBoxAPIKey.Clear();
                textBoxEmail.Clear();
                textBoxPassword.Clear();

                SaveAccounts();
            }
            catch (Exception exc)
            {
                labelError.Text = exc.Message;
                Utility.TimeoutToDisappear(labelError);
            }
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
                var obj = (Account)listBoxAccounts.Items[listBoxAccounts.SelectedIndex];
                textBoxName.Text = obj.Name;
                textBoxAPIKey.Text = obj.Key;
                textBoxEmail.Text = obj.Email;
                textBoxPassword.Text = obj.Password;

                listBoxAccounts.Items.Remove(obj);

                SaveAccounts();
            }
            else
            {
                labelError.Text = "Select an account to edit first!";
                Utility.TimeoutToDisappear(labelError);
            }
        }
        
        private void buttonToggleShowPassword_Click(object sender, EventArgs e)
        {
            m_bHidePassword = !m_bHidePassword;
            textBoxPassword.UseSystemPasswordChar = m_bHidePassword;

            if (m_bHidePassword)
                buttonToggleShowPassword.BackgroundImage = Properties.Resources.ui_locked;
            else
                buttonToggleShowPassword.BackgroundImage = Properties.Resources.ui_unlocked;
        }

        private void listBoxAccounts_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(listBoxAccounts.SelectedIndex >= 0)
            {
                var obj = (Account)listBoxAccounts.Items[listBoxAccounts.SelectedIndex];
                if (obj.Permissions != null)
                    apiKeyInfo.UpdatePermissions(obj.Permissions);
            }
        }
    }
}
