using System;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace GuildLounge.TabPages.Tools
{
    public partial class WindowedResolution : UserControl
    {
        public WindowedResolution()
        {
            InitializeComponent();

            Resolution[] res16by9 = new Resolution[] {
                new Resolution { Width = 1280, Height = 720},
                new Resolution { Width = 1360, Height = 768},
                new Resolution { Width = 1366, Height = 768},
                new Resolution { Width = 1600, Height = 900},
                new Resolution { Width = 1920, Height = 1080},
            };
            Resolution[] res16by10 = new Resolution[] {
                new Resolution { Width = 720, Height = 480},
                new Resolution { Width = 1280, Height = 768},
                new Resolution { Width = 1280, Height = 800},
                new Resolution { Width = 1440, Height = 900},
                new Resolution { Width = 1600, Height = 1024},
                new Resolution { Width = 1680, Height = 1050},
            };
            Resolution[] res4by3 = new Resolution[] {
                new Resolution { Width = 640, Height = 480},
                new Resolution { Width = 720, Height = 576},
                new Resolution { Width = 800, Height = 600},
                new Resolution { Width = 1024, Height = 768},
                new Resolution { Width = 1152, Height = 864},
                new Resolution { Width = 1280, Height = 960},
                new Resolution { Width = 1280, Height = 1024},
            };

            comboBoxAspectRatio.Items.AddRange( new object[] {
                new AspectRatio() { Name = "16:9", Resolutions = res16by9},
                new AspectRatio() { Name = "16:10", Resolutions = res16by10},
                new AspectRatio() { Name = "4:3", Resolutions = res4by3}
            });

            comboBoxAspectRatio.SelectedItem = comboBoxAspectRatio.Items[0];
            comboBoxResolution.SelectedItem = comboBoxResolution.Items[0];
        }

        internal class AspectRatio
        {
            public string Name { get; set; }
            public Resolution[] Resolutions { get; set; }
            public override string ToString()
            {
                return Name;
            }
        }

        internal class Resolution
        {
            public int Width { get; set; }
            public int Height { get; set; }
            public override string ToString()
            {
                return Width + "x" + Height;
            }
        }

        private void comboBoxAspectRatio_SelectedIndexChanged(object sender, EventArgs e)
        {
            comboBoxResolution.Items.Clear();
            comboBoxResolution.Items.AddRange(((AspectRatio)comboBoxAspectRatio.SelectedItem).Resolutions);
            comboBoxResolution.SelectedItem = comboBoxResolution.Items[0];
        }

        private void buttonSet_Click(object sender, EventArgs e)
        {
            //Get window handle
            IntPtr target_hwnd = FindWindowByCaption(IntPtr.Zero, "Guild Wars 2");
            if (target_hwnd == IntPtr.Zero)
            {
                labelError.Text = "Guild Wars 2 is not running.";
                Utility.TimeoutToDisappear(labelError);
                return;
            }

            //Set position of handle
            int width = 0;
            int height = 0;

            if (textBoxWidth.Text != "" && textBoxHeight.Text != "")
            {
                int.TryParse(textBoxWidth.Text, out width);
                int.TryParse(textBoxHeight.Text, out height);
            }
            else
            {
                width = ((Resolution)comboBoxResolution.SelectedItem).Width;
                height = ((Resolution)comboBoxResolution.SelectedItem).Height;
            }
            int x = 10;
            int y = 10;
            
            if (width != 0 && height != 0)
                SetWindowPos(target_hwnd, IntPtr.Zero, x, y, width, height, 0);
        }

        [DllImport("user32.dll", EntryPoint = "FindWindow", SetLastError = true)]
        static extern IntPtr FindWindowByCaption(IntPtr ZeroOnly, string lpWindowName);
        
        [DllImport("user32.dll")]
        [return: MarshalAs(UnmanagedType.Bool)]
        static extern bool SetWindowPos(IntPtr hWnd, IntPtr hWndInsertAfter, int X, int Y, int cx, int cy, SetWindowPosFlags uFlags);
        
        [Flags()]
        private enum SetWindowPosFlags : uint
        {
            SynchronousWindowPosition = 0x4000,
            DeferErase = 0x2000,
            DrawFrame = 0x0020,
            FrameChanged = 0x0020,
            HideWindow = 0x0080,
            DoNotActivate = 0x0010,
            DoNotCopyBits = 0x0100,
            IgnoreMove = 0x0002,
            DoNotChangeOwnerZOrder = 0x0200,
            DoNotRedraw = 0x0008,
            DoNotReposition = 0x0200,
            DoNotSendChangingEvent = 0x0400,
            IgnoreResize = 0x0001,
            IgnoreZOrder = 0x0004,
            ShowWindow = 0x0040,
        }
    }
}