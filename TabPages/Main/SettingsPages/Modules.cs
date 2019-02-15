using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GuildLounge.TabPages.SettingsPages
{
    public partial class Modules : UserControl
    {
        public Modules()
        {
            InitializeComponent();
            listBoxActive.Items.AddRange(new string[]
            {
                "Basic Currencies",
                "Fractals",
                "PvP",
                "Raids",
                "Trading Post Pickup",
                "WvW"
            });
        }

        private void buttonMoveToActive_Click(object sender, EventArgs e)
        {
            if(listBoxInactive.SelectedItem != null)
            {
                listBoxActive.Items.Add(listBoxInactive.Items[listBoxInactive.SelectedIndex]);
                listBoxInactive.Items.RemoveAt(listBoxInactive.SelectedIndex);
            }
        }

        private void buttonMoveToInactive_Click(object sender, EventArgs e)
        {
            if (listBoxActive.SelectedItem != null)
            {
                listBoxInactive.Items.Add(listBoxActive.Items[listBoxActive.SelectedIndex]);
                listBoxActive.Items.RemoveAt(listBoxActive.SelectedIndex);
            }
        }

        private void linkLabelGLDiscord_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            System.Diagnostics.Process.Start("https://discord.gg/MSgPhDv");
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
        }
    }
}