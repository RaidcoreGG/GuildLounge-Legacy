using System;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GuildLounge
{
    class ErrorInfo
    {
        public static void TimeoutToDisappear(Control c)
        {
            Task.Run(async () =>
            {
                Console.WriteLine("Hiding " + c.Parent.Name + "." + c.Name + " in 7s.");
                await Task.Delay(7000);
                c.Invoke(new Action(() => c.Visible = false));
                Console.WriteLine("Hidden.");
            });
        }
    }
}
