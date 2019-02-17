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
        private static AddOnUpdater _updater;
        private static string _appdata = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "GuildLounge");
        private AddOn[] StoredExtensions { get; set; }

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
        }

        private void LoadExtensions()
        {
            //READ ADDONS FROM FILE & ADD THEM TO THE LISTBOX
            StoredExtensions = new JavaScriptSerializer().Deserialize<List<AddOn>>(File.ReadAllText(Path.Combine(_appdata, "addons.json"))).ToArray();
            listBoxExtensions.Items.AddRange(StoredExtensions);
            listBoxExtensions.DisplayMember = "link";
        }

        public void LoadSettingsExtensions()
        {
            checkBoxAutoUpdate.Checked = Properties.Settings.Default.AutoUpdate;
        }

        private void UpdateExtensions(AddOn[] addOns, bool checkForLastModified)
        {
            //CREATE A NEW TASK TO RUN IN THE BACKGROUND SO THE PROGRAM EXECUTION/LOAD UP WON'T BE DELAYED
            Task.Run(async () =>
            {
                _updater = new AddOnUpdater();
                await _updater.UpdateAddOns(addOns, checkForLastModified);
                StoredExtensions = _updater.AddOns;
                SaveExtensions();
            });
        }

        private void SaveExtensions()
        {
            if (listBoxExtensions.Items.Count > 0)
            {
                //REINITIALIZE ARRAY WITH EDITED/UPDATED VALUES FROM THE LISTBOX
                StoredExtensions = new AddOn[listBoxExtensions.Items.Count];
                for (int i = 0; i < listBoxExtensions.Items.Count; i++)
                    StoredExtensions[i] = (AddOn)listBoxExtensions.Items[i];

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
            
            Utility.TimeoutToDisappear(labelUpdateInfo);
        }
    }
}
