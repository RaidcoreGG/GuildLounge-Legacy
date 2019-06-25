using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Threading.Tasks;
using System.Web.Script.Serialization;
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
            return new SortedCoins {
                Gold = (amount / 100 / 100),
                Silver = (amount % 10000 / 100),
                Copper = (amount % 100)
            };
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

        public static void WriteJSON<T>(string path, T data)
        {
            string serializedData = new JavaScriptSerializer().Serialize(data);
            File.WriteAllText(path, serializedData);
        }

        public static T[] ReadJSON<T>(string path)
        {
            return new JavaScriptSerializer().Deserialize<List<T>>(File.ReadAllText(path)).ToArray();
        }
    }
}
