using System;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GuildLounge
{
    class Utility
    {
        public static void TimeoutToDisappear(Control c)
        {
            Task.Run(async () =>
            {
                c.Invoke(new Action(() => c.Visible = true));
                await Task.Delay(7000);
                c.Invoke(new Action(() => c.Visible = false));
            });
        }
    }
}
