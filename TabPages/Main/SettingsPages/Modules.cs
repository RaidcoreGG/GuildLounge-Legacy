using System;
using System.Drawing;
using System.Windows.Forms;
using System.Web.Script.Serialization;

namespace GuildLounge.TabPages.SettingsPages
{
    public partial class Modules : UserControl
    {
        private static readonly ApiHandler _api = new ApiHandler();
        
        public Modules()
        {
            InitializeComponent();

            LoadSettingsModules();
        }

        public void LoadSettingsModules()
        {
            //ACTIVE
            System.Collections.Specialized.StringCollection sca = Properties.Settings.Default.ActiveModules;
            listBoxActive.Items.Clear();
            if (sca != null)
            {
                string[] stra = new string[sca.Count];
                sca.CopyTo(stra, 0);
                listBoxActive.Items.AddRange(stra);
            }

            //INACTIVE
            System.Collections.Specialized.StringCollection sci = Properties.Settings.Default.InactiveModules;
            listBoxInactive.Items.Clear();
            if (sci != null)
            {
                string[] stri = new string[sci.Count];
                sci.CopyTo(stri, 0);
                listBoxInactive.Items.AddRange(stri);
            }

            FetchModules();
        }

        private async void FetchModules()
        {
            try
            {
                string[] APIResponse = await _api.GetResponseWithEntryPoint<string[]>("http://api.guildlounge.com/", "modules");

                foreach (string s in APIResponse)
                {
                    if (!listBoxActive.Items.Contains(s) && !listBoxInactive.Items.Contains(s))
                    {
                        listBoxInactive.Items.Add(s);
                        SetModules();
                    }
                }
            }
            catch (Exception exc)
            {
                Console.WriteLine(exc.Message);
            }
        }

        private void SetModules()
        {
            System.Collections.Specialized.StringCollection sca = new System.Collections.Specialized.StringCollection();
            sca.AddRange(GetActiveModules());
            Properties.Settings.Default.ActiveModules = sca;

            System.Collections.Specialized.StringCollection sci = new System.Collections.Specialized.StringCollection();
            sci.AddRange(GetInactiveModules());
            Properties.Settings.Default.InactiveModules = sci;

            if (Parent != null)
                ((Settings)Parent).SettingsChanged();
        }

        private string[] GetActiveModules()
        {
            string[] modules = new string[listBoxActive.Items.Count];

            int i = 0;
            foreach(object o in listBoxActive.Items)
            {
                modules[i] = (string)o;
                i++;
            }
            return modules;
        }

        private string[] GetInactiveModules()
        {
            string[] modules = new string[listBoxInactive.Items.Count];

            int i = 0;
            foreach (object o in listBoxInactive.Items)
            {
                modules[i] = (string)o;
                i++;
            }
            return modules;
        }

        private void buttonMoveToActive_Click(object sender, EventArgs e)
        {
            if(listBoxInactive.SelectedItem != null)
            {
                listBoxActive.Items.Add(listBoxInactive.Items[listBoxInactive.SelectedIndex]);
                listBoxInactive.Items.RemoveAt(listBoxInactive.SelectedIndex);
            }

            SetModules();
        }

        private void buttonMoveToInactive_Click(object sender, EventArgs e)
        {
            if (listBoxActive.SelectedItem != null)
            {
                listBoxInactive.Items.Add(listBoxActive.Items[listBoxActive.SelectedIndex]);
                listBoxActive.Items.RemoveAt(listBoxActive.SelectedIndex);
            }

            SetModules();
        }
        
        private void listBoxActive_MouseDown(object sender, MouseEventArgs e)
        {
            if (listBoxActive.SelectedItem != null)
                listBoxActive.DoDragDrop(listBoxActive.SelectedItem, DragDropEffects.Move);
        }

        private void listBoxActive_DragOver(object sender, DragEventArgs e)
        {
            e.Effect = DragDropEffects.Move;
        }

        private void listBoxActive_DragDrop(object sender, DragEventArgs e)
        {
            Point point = listBoxActive.PointToClient(new Point(e.X, e.Y));
            int index = this.listBoxActive.IndexFromPoint(point);
            if (index < 0) index = this.listBoxActive.Items.Count - 1;
            object data = e.Data.GetData(typeof(string));
            this.listBoxActive.Items.Remove(data);
            this.listBoxActive.Items.Insert(index, data);

            SetModules();
        }

        private void linkLabelGLDiscord_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            System.Diagnostics.Process.Start("https://discord.gg/MSgPhDv");
        }
    }
}