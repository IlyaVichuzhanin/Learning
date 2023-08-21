using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Small_tasks.Tasks
{
    internal class BubbleSort
    {
        public static int[] BubbleSortRange(int[] array, int left, int right)
        {
            for (int i = left; i < right; i++)
                for (int j = left; j < right; j++)
                    if (array[j] > array[j + 1])
                    {
                        var t = array[j + 1];
                        array[j + 1] = array[j];
                        array[j] = t;
                    }
            return array;
        }
    }
}
