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
    public partial class Extensions : UserControl
    {
        private static ExtensionUpdater _updater;
        private static string _appdata = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "GuildLounge");
        private Extension[] StoredExtensions { get; set; }

        public Extensions()
        {
            InitializeComponent();

            LoadSettingsExtensions();

            try
            {
                LoadExtensions();
                if (checkBoxAutoUpdate.Checked)
                    UpdateExtensions(StoredExtensions, true);
            }
            catch (Exception exc)
            {
                Console.WriteLine(exc.Message);
            }

            //LOADUP FIX
            labelUpdateInfo.Visible = false;
        }

        private void LoadExtensions()
        {
            //READ ADDONS FROM FILE & ADD THEM TO THE LISTBOX
            StoredExtensions = new JavaScriptSerializer().Deserialize<List<Extension>>(File.ReadAllText(Path.Combine(_appdata, "addons.json"))).ToArray();
            listBoxExtensions.Items.AddRange(StoredExtensions);
            listBoxExtensions.DisplayMember = "link";
        }

        public void LoadSettingsExtensions()
        {
            checkBoxAutoUpdate.Checked = Properties.Settings.Default.AutoUpdate;
        }

        private void UpdateExtensions(Extension[] addOns, bool checkForLastModified)
        {
            //CREATE A NEW TASK TO RUN IN THE BACKGROUND SO THE PROGRAM EXECUTION/LOAD UP WON'T BE DELAYED
            Task.Run(async () =>
            {
                _updater = new ExtensionUpdater();
                await _updater.UpdateExtensions(addOns, checkForLastModified);
                StoredExtensions = _updater.StoredExtensions;
                SaveExtensions();
            });
        }

        private void SaveExtensions()
        {
            if (listBoxExtensions.Items.Count > 0)
            {
                //REINITIALIZE ARRAY WITH EDITED/UPDATED VALUES FROM THE LISTBOX
                StoredExtensions = new Extension[listBoxExtensions.Items.Count];
                for (int i = 0; i < listBoxExtensions.Items.Count; i++)
                    StoredExtensions[i] = (Extension)listBoxExtensions.Items[i];

                //PARSE TO JSON AND WRITE TO FILE
                string parsedKeys = new JavaScriptSerializer().Serialize(StoredExtensions);
                File.WriteAllText(Path.Combine(_appdata, "addons.json"), parsedKeys);
            }
            else
            {
                //WRITE AN EMPTY JSON OBJECT TO FILE
                File.WriteAllText(Path.Combine(_appdata, "addons.json"), "[]");
                StoredExtensions = null;
            }
        }

        private void checkBoxAutoUpdate_CheckedChanged(object sender, EventArgs e)
        {
            Properties.Settings.Default.AutoUpdate = checkBoxAutoUpdate.Checked;
            if (checkBoxAutoUpdate.Checked)
                labelUpdateInfo.Text = "Your add-ons will update automatically, the next time you start Guild Lounge.";
            else
                labelUpdateInfo.Text = "Your add-ons will no longer be updated automatically.";

            labelUpdateInfo.Visible = true;
            if (Parent != null)
                ((Settings)Parent).SettingsChanged();
        }

        private void buttonForceUpdate_Click(object sender, EventArgs e)
        {
            UpdateExtensions(StoredExtensions, false);
        }

        private void buttonRemoveExtension_Click(object sender, EventArgs e)
        {
            if (listBoxExtensions.SelectedIndex >= 0)
            {
                listBoxExtensions.Items.RemoveAt(listBoxExtensions.SelectedIndex);
                SaveExtensions();
            }
        }

        private void buttonEditExtension_Click(object sender, EventArgs e)
        {
            if (listBoxExtensions.SelectedIndex >= 0)
            {
                var obj = (Extension)listBoxExtensions.Items[listBoxExtensions.SelectedIndex];
                textBoxExtensionLink.Text = obj.Link;
                textBoxExtensionName.Text = obj.Name;
                listBoxExtensions.Items.Remove(obj);
                SaveExtensions();
            }
            else
            {
                labelError.Text = "Select an add-on to edit first!";
                Utility.TimeoutToDisappear(labelError);
            }
        }

        private void buttonAddExtension_Click(object sender, EventArgs e)
        {
            //IF LINK VALID (IS DLL FILE)
            try
            {
                listBoxExtensions.Items.Add(new Extension() { Link = textBoxExtensionLink.Text, Name = textBoxExtensionName.Text });
                textBoxExtensionLink.Clear();
                textBoxExtensionName.Clear();
                SaveExtensions();
            }
            catch (Exception exc)
            {
                labelError.Text = exc.Message;
                Utility.TimeoutToDisappear(labelError);
            }
        }
    }
}
