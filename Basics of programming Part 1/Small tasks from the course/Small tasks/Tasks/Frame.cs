using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Small_tasks.Tasks
{
    public class Frame
    {
        private static void WriteTextWithBorder(string text)
        {
            string dashes = "";
            for (int i = 0; i < text.Length; i++)
            {
                dashes = dashes + "-";
            }
            string mainline = "+-" + dashes + "-+";
            string midleline = "| " + text + " |";
            Console.WriteLine(mainline);
            Console.WriteLine(midleline);
            Console.WriteLine(mainline);
        }
    }
}
