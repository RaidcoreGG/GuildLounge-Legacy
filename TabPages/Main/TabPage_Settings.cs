using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using System.Web.Script.Serialization;
using System.Windows.Forms;

namespace GuildLounge
{
    public partial class TabPage_Settings : UserControl
    {
        private static AddOnUpdater _updater;
        private static string _appdata = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "GuildLounge");
        private AddOn[] AddOns { get; set; }

        public TabPage_Settings()
        {
            InitializeComponent();

            LoadSettings();
            
            try
            {
                LoadAddOns();
                if (checkBoxUpdateAddOns.Checked)
                    UpdateAddOns(AddOns, true);
            }
            catch (Exception exc)
            {
                Console.WriteLine(exc.Message);
            }
        }

        private void LoadSettings()
        {
            textBoxGameDirectory.Text = Properties.Settings.Default.GameDir;
            switch (Properties.Settings.Default.LaunchBehavior)
            {
                case "STAY_OPEN":
                    radioButtonLaunchStayOpen.Checked = true;
                    break;
                case "MINIMIZE":
                    radioButtonLaunchMinimize.Checked = true;
                    break;
                case "CLOSE":
                    radioButtonLaunchClose.Checked = true;
                    break;
            }
            textBoxStartParams.Text = Properties.Settings.Default.StartParams;
            checkBoxUpdateAddOns.Checked = Properties.Settings.Default.UpdateAddOns;

            //LABEL LOADUP CORRECT
            labelUpdateInfo.Visible = false;
        }

        private void LoadAddOns()
        {
            //READ ADDONS FROM FILE & ADD THEM TO THE LISTBOX
            AddOns = new JavaScriptSerializer().Deserialize<List<AddOn>>(File.ReadAllText(Path.Combine(_appdata, "addons.json"))).ToArray();
            listBoxAddOns.Items.AddRange(AddOns);
            listBoxAddOns.DisplayMember = "link";
        }

        private void UpdateAddOns(AddOn[] addOns, bool checkForLastModified)
        {
            //CREATE A NEW TASK TO RUN IN THE BACKGROUND SO THE PROGRAM EXECUTION/LOAD UP WON'T BE DELAYED
            Task.Run(async () =>
            {
                _updater = new AddOnUpdater();
                await _updater.UpdateAddOns(addOns, checkForLastModified);
                AddOns = _updater.AddOns;
                SaveAddOns();
            });
        }

        private void SaveAddOns()
        {
            if (listBoxAddOns.Items.Count > 0)
            {
                //REINITIALIZE ARRAY WITH EDITED/UPDATED VALUES FROM THE LISTBOX
                AddOns = new AddOn[listBoxAddOns.Items.Count];
                for (int i = 0; i < listBoxAddOns.Items.Count; i++)
                    AddOns[i] = (AddOn)listBoxAddOns.Items[i];

                //PARSE TO JSON AND WRITE TO FILE
                string parsedKeys = new JavaScriptSerializer().Serialize(AddOns);
                File.WriteAllText(Path.Combine(_appdata, "addons.json"), parsedKeys);
            }
            else
            {
                //WRITE AN EMPTY JSON OBJECT TO FILE
                File.WriteAllText(Path.Combine(_appdata, "addons.json"), "[]");
                AddOns = null;
            }
        }

        #region OnSettingsChanged
        private void textBoxGameDirectory_TextChanged(object sender, EventArgs e)
        {
            if (textBoxGameDirectory.Text != Properties.Settings.Default.GameDir)
                buttonSave.Enabled = true;
        }

        private void buttonBrowseGameDirectory_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog fbd = new FolderBrowserDialog();
            fbd.RootFolder = Environment.SpecialFolder.MyComputer;
            if (fbd.ShowDialog() == DialogResult.OK)
                textBoxGameDirectory.Text = fbd.SelectedPath;
        }

        private void radioButtonLaunchStayOpen_CheckedChanged(object sender, EventArgs e)
        {
            if (!radioButtonLaunchStayOpen.Checked && Properties.Settings.Default.LaunchBehavior == "STAY_OPEN")
                buttonSave.Enabled = true;
        }

        private void radioButtonLaunchMinimize_CheckedChanged(object sender, EventArgs e)
        {
            if (!radioButtonLaunchMinimize.Checked && Properties.Settings.Default.LaunchBehavior == "MINIMIZE")
                buttonSave.Enabled = true;
        }

        private void radioButtonLaunchClose_CheckedChanged(object sender, EventArgs e)
        {
            if (!radioButtonLaunchClose.Checked && Properties.Settings.Default.LaunchBehavior == "CLOSE")
                buttonSave.Enabled = true;
        }

        private void textBoxStartParams_TextChanged(object sender, EventArgs e)
        {
            if (textBoxStartParams.Text != Properties.Settings.Default.StartParams)
                buttonSave.Enabled = true;
        }

        private void checkBoxUpdateAddOns_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBoxUpdateAddOns.Checked != Properties.Settings.Default.UpdateAddOns)
                buttonSave.Enabled = true;
            if (checkBoxUpdateAddOns.Checked)
                labelUpdateInfo.Text = "Your add-ons will update automatically, the next time you start Guild Lounge.";
            else
                labelUpdateInfo.Text = "Your add-ons will no longer be updated automatically.";
            labelUpdateInfo.Visible = true;
        }
        #endregion

        #region listbox
        private void listboxAddOns_OnKeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Delete)
                buttonRemoveAddOn_Click(sender, e);
            else if (e.KeyCode == Keys.E && e.Modifiers == Keys.Control)
                buttonEditAddOn_Click(sender, e);
        }
        private void buttonAddAddOn_Click(object sender, EventArgs e)
        {
            //IF LINK VALID (IS DLL FILE)
            try
            {
                listBoxAddOns.Items.Add(new AddOn() { Link = textBoxAddOnLink.Text });
                textBoxAddOnLink.Clear();
                SaveAddOns();
            }
            catch (Exception exc)
            {
                labelError.Text = exc.Message;
                Utility.TimeoutToDisappear(labelError);
            }
        }

        private void buttonEditAddOn_Click(object sender, EventArgs e)
        {
            if (listBoxAddOns.SelectedIndex >= 0)
            {
                var obj = (AddOn)listBoxAddOns.Items[listBoxAddOns.SelectedIndex];
                textBoxAddOnLink.Text = obj.Link;
                listBoxAddOns.Items.Remove(obj);
                SaveAddOns();
            }
            else
            {
                labelError.Text = "Select a add-on to edit first!";
                Utility.TimeoutToDisappear(labelError);
            }
        }

        private void buttonRemoveAddOn_Click(object sender, EventArgs e)
        {
            if (listBoxAddOns.SelectedIndex >= 0)
            {
                listBoxAddOns.Items.RemoveAt(listBoxAddOns.SelectedIndex);
                SaveAddOns();
            }
        }

        private void buttonForceUpdate_Click(object sender, EventArgs e)
        {
            UpdateAddOns(AddOns, false);
        }
        #endregion

        private void buttonSave_Click(object sender, EventArgs e)
        {
            //SAVE ALL SETTINGS
            Properties.Settings.Default.GameDir = textBoxGameDirectory.Text;
            if (radioButtonLaunchStayOpen.Checked)
                Properties.Settings.Default.LaunchBehavior = "STAY_OPEN";
            else if (radioButtonLaunchMinimize.Checked)
                Properties.Settings.Default.LaunchBehavior = "MINIMIZE";
            else if (radioButtonLaunchClose.Checked)
                Properties.Settings.Default.LaunchBehavior = "CLOSE";
            Properties.Settings.Default.StartParams = textBoxStartParams.Text;
            Properties.Settings.Default.UpdateAddOns = checkBoxUpdateAddOns.Checked;
            Properties.Settings.Default.Save();
            buttonSave.Enabled = false;
        }

        private void buttonRestore_Click(object sender, EventArgs e)
        {
            //RESTORE TO DEFAULT SETTINGS
            Properties.Settings.Default.Reset();
            textBoxGameDirectory.Text = Properties.Settings.Default.GameDir;
            radioButtonLaunchStayOpen.Checked = radioButtonLaunchMinimize.Checked = radioButtonLaunchClose.Checked = false;
            if (Properties.Settings.Default.LaunchBehavior == "STAY_OPEN")
                radioButtonLaunchStayOpen.Checked = true;
            else if (Properties.Settings.Default.LaunchBehavior == "MINIMIZE")
                radioButtonLaunchMinimize.Checked = true;
            else if (Properties.Settings.Default.LaunchBehavior == "CLOSE")
                radioButtonLaunchClose.Checked = true;
            textBoxStartParams.Text = Properties.Settings.Default.StartParams;
            checkBoxUpdateAddOns.Checked = Properties.Settings.Default.UpdateAddOns;
            buttonSave.Enabled = false;
        }
    }
}