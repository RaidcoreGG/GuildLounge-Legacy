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
        }
        
        private void buttonSet_Click(object sender, EventArgs e)
        {
            //Get window handle
            IntPtr target_hwnd = FindWindowByCaption(IntPtr.Zero, "Guild Wars 2");
            if (target_hwnd == IntPtr.Zero)
            {
                return;
            }

            //Set position of handle
            int width = int.Parse(textBoxWidth.Text);
            int height = int.Parse(textBoxHeight.Text);
            int x = 10;
            int y = 10;
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