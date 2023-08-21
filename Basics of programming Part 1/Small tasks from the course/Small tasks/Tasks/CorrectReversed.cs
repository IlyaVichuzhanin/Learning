using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Small_tasks.Tasks
{
    internal class CorrectReversed
    {
        public static void WriteReversed(char[] items, int startIndex = 0)
        {
            if (items.Length > 0)
            {
                if (startIndex >= 0 && startIndex < items.Length - 1)
                {
                    WriteReversed(items, startIndex + 1);
                }
                Console.Write(items[startIndex]);
            }
        }
    }
}
