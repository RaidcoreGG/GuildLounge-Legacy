using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using System.Web.Script.Serialization;
using System.Windows.Forms;

namespace GuildLounge.TabPages.SettingsPages
{
    public partial class Extensions : UserControl
    {
        private static ExtensionManager _updater;
        private static string _appdata = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "GuildLounge");
        private Extension[] StoredExtensions { get; set; }

        public Extensions()
        {
            InitializeComponent();

            InitializeExtensionSettings();

            //Loadup fix
            labelUpdateInfo.Visible = false;

            try
            {
                InitializeExtensions();
                if (checkBoxAutoUpdate.Checked)
                    UpdateExtensions(StoredExtensions, true);
            }
            catch (Exception exc)
            {
                Console.WriteLine(exc.Message);
            }
        }

        #region misc
        private void InitializeExtensions()
        {
            //Deserialize and load into listbox
            StoredExtensions = new JavaScriptSerializer().Deserialize<List<Extension>>(File.ReadAllText(Path.Combine(_appdata, "addons.json"))).ToArray();
            listBoxExtensions.Items.AddRange(StoredExtensions);
        }

        public void InitializeExtensionSettings()
        {
            checkBoxAutoUpdate.Checked = Properties.Settings.Default.AutoUpdateExtensions;
        }

        private void UpdateExtensions(Extension[] addOns, bool checkForLastModified)
        {
            //Create a new task so program execution won't be delayed
            Task.Run(async () =>
            {
                _updater = new ExtensionManager();
                await _updater.UpdateExtensions(addOns, checkForLastModified);
            });
        }

        private void SaveExtensions()
        {
            if (listBoxExtensions.Items.Count > 0)
            {
                //Reinitialize array from listbox
                StoredExtensions = new Extension[listBoxExtensions.Items.Count];
                for (int i = 0; i < listBoxExtensions.Items.Count; i++)
                    StoredExtensions[i] = (Extension)listBoxExtensions.Items[i];

                //Serialize json and write to file
                string parsedKeys = new JavaScriptSerializer().Serialize(StoredExtensions);
                File.WriteAllText(Path.Combine(_appdata, "addons.json"), parsedKeys);
            }
            else
            {
                //write empty json
                File.WriteAllText(Path.Combine(_appdata, "addons.json"), "[]");
                StoredExtensions = null;
            }
        }
        #endregion

        #region navigation
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
                //Load values of selected item into textboxes
                var obj = (Extension)listBoxExtensions.Items[listBoxExtensions.SelectedIndex];
                textBoxExtensionLink.Text = obj.Link;
                textBoxExtensionName.Text = obj.Name;

                //Remove selected item
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
            //if link is valid (is DLL file)
            try
            {
                //Create new object from values
                listBoxExtensions.Items.Add(new Extension() { Link = textBoxExtensionLink.Text, Name = textBoxExtensionName.Text });

                //Clear textboxes
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
        #endregion

        #region events
        private void checkBoxAutoUpdate_CheckedChanged(object sender, EventArgs e)
        {
            Properties.Settings.Default.AutoUpdateExtensions = checkBoxAutoUpdate.Checked;
            if (checkBoxAutoUpdate.Checked)
                labelUpdateInfo.Text = "Your add-ons will update automatically, the next time you start Guild Lounge.";
            else
                labelUpdateInfo.Text = "Your add-ons will no longer be updated automatically.";

            labelUpdateInfo.Visible = true;
            if (Parent != null)
                ((Settings)Parent).SettingsChanged(false);
        }
        #endregion
    }
}