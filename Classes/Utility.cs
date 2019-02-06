using System;
using System.Drawing;
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

        public static SortedCoins SortCoins(int amount)
        {
            SortedCoins rtrn = new SortedCoins
            {
                Gold = (amount / 100 / 100),
                Silver = (amount % 10000 / 100),
                Copper = (amount % 100)
            };
            return rtrn;
        }

        public class SortedCoins
        {
            public int Gold { get; set; }
            public int Silver { get; set; }
            public int Copper { get; set; }
        }

        public static void ResizeFontOnWidthThreshold(Control control, int max)
        {
            max = max + control.Margin.Left + control.Margin.Right;
            while (control.Width > max)
            {
                float sip =  control.Font.SizeInPoints;
                sip -= .5f;
                Font newFont = new Font(control.Font.FontFamily, sip, control.Font.Style);
                control.Font = newFont;
            }
        }
    }
}
