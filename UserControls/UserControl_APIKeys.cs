using System;
using System.Collections.Generic;
using System.IO;
using System.Web.Script.Serialization;
using System.Windows.Forms;

namespace GuildLounge
{
    public partial class UserControl_APIKeys : UserControl
    {
        private static string _appdata = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "GuildLounge");
        public ApiEntry[] APIEntries { get; set; }

        public UserControl_APIKeys()
        {
            InitializeComponent();

            try
            {
                LoadAPIKeys();
            }
            catch (Exception exc)
            {
                Console.WriteLine(exc.Message);
            }
        }

        public void LoadAPIKeys()
        {
            //READ API KEYS FROM FILE AND ADD THEM TO THE LISTBOX
            APIEntries = new JavaScriptSerializer().Deserialize<List<ApiEntry>>(File.ReadAllText(Path.Combine(_appdata, "api_keys.json"))).ToArray();
            listBoxAPIKeys.Items.AddRange(APIEntries);
        }

        public void SaveAPIKeys()
        {
            if (listBoxAPIKeys.Items.Count > 0)
            {
                //REINITIALIZE ARRAY WITH EDITED/UPDATED VALUES FROM THE LISTBOX
                APIEntries = new ApiEntry[listBoxAPIKeys.Items.Count];
                for (int i = 0; i < listBoxAPIKeys.Items.Count; i++)
                    APIEntries[i] = (ApiEntry)listBoxAPIKeys.Items[i];

                //PARSE TO JSON AND WRITE TO FILE
                string parsedKeys = new JavaScriptSerializer().Serialize(APIEntries);
                File.WriteAllText(Path.Combine(_appdata, "api_keys.json"), parsedKeys);
            }
            else
            {
                //WRITE AN EMPTY JSON OBJECT TO FILE
                File.WriteAllText(Path.Combine(_appdata, "api_keys.json"), "[]");
                APIEntries = null;
            }

            //CALLING MAIN FORM TO REFRESH KEYS
            var obj = (Main)Parent;
            obj.RefreshKeys();
        }

        #region listbox
        //SHORTCUTS
        private void listBoxAPIKeys_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Delete)
                buttonRemoveKey_Click(sender, e);
            else if (e.KeyCode == Keys.E && e.Modifiers == Keys.Control)
                buttonEditKey_Click(sender, e);
        }

        //BUTTONS
        private void buttonAddKey_Click(object sender, EventArgs e)
        {
            try
            {
                listBoxAPIKeys.Items.Add(new ApiEntry { Name = textBoxKeyName.Text, Key = textBoxKey.Text });
                textBoxKeyName.Clear();
                textBoxKey.Clear();
                SaveAPIKeys();
            }
            catch (Exception exc)
            {
                labelError.Text = exc.Message;
                ErrorInfo.TimeoutToDisappear(labelError);
            }
        }
        
        private void buttonEditKey_Click(object sender, EventArgs e)
        {
            if (listBoxAPIKeys.SelectedIndex >= 0)
            {
                var obj = (ApiEntry)listBoxAPIKeys.Items[listBoxAPIKeys.SelectedIndex];
                textBoxKeyName.Text = obj.Name;
                textBoxKey.Text = obj.Key;
                listBoxAPIKeys.Items.Remove(obj);
                SaveAPIKeys();
            }
            else
            {
                labelError.Text = "Select a key to edit first!";
                ErrorInfo.TimeoutToDisappear(labelError);
            }
        }
        
        private void buttonRemoveKey_Click(object sender, EventArgs e)
        {
            if (listBoxAPIKeys.SelectedIndex >= 0)
            {
                listBoxAPIKeys.Items.RemoveAt(listBoxAPIKeys.SelectedIndex);
                SaveAPIKeys();
            }
        }
        #endregion
    }
}