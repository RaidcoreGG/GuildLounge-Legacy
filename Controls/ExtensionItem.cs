using System.Windows.Forms;

namespace GuildLounge.Controls
{
    public partial class ExtensionItem : UserControl
    {
        private string _ExtensionName;
        private string _LastUpdated;
        private bool _IsUpToDate;
        private bool _IsUpdating;
        private bool _IsMain;

        public string ExtensionName
        {
            get
            {
                return _ExtensionName;
            }
            set
            {
                _ExtensionName = value;
                labelName.Text = value;
            }
        }
        public string LastUpdated
        {
            get
            {
                return _LastUpdated;
            }
            set
            {
                _LastUpdated = value;
                labelLastUpdated.Text = value;
            }
        }
        public bool IsUpToDate
        {
            get
            {
                return _IsUpToDate;
            }
            set
            {
                _IsUpToDate = value;
                statePanelUpToDate.Active = value;
            }
        }
        public bool IsUpdating
        {
            get
            {
                return _IsUpdating;
            }
            set
            {
                _IsUpdating = value;
                if(value)
                {
                    pictureBoxIsUpdating.Image = Properties.Resources.ui_refresh_ani;
                }
                else
                {
                    pictureBoxIsUpdating.Image = null;
                }
            }
        }
        public bool IsMain
        {
            get
            {
                return _IsMain;
            }
            set
            {
                _IsMain = value;
                if (value)
                {
                    pictureBoxIsMain.Image = Properties.Resources.ui_chain;
                }
                else
                {
                    pictureBoxIsMain.Image = null;
                }
            }
        }

        public ExtensionItem()
        {
            InitializeComponent();

            ExtensionName = "[UNDEFINED]";
            LastUpdated = "YYYY-MM-DD";
            IsUpToDate = false;
            IsUpdating = false;
            IsMain = false;
        }
    }
}
