using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Small_tasks.Tasks
{
    internal class ItemCounter
    {
        public static int GetElementCount(int[] items, int itemToCount)
        {
            int counter = 0;
            foreach (var item in items)
                if (item == itemToCount) counter++;
            return counter;
        }
    }
}
