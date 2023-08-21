using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Small_tasks.Tasks
{
    internal class ArrayCreator
    {
        public static int[] GetFirstEvenNumbers(int count)
        {
            int[] array = new int[count];
            for (int i = 0; i < array.Length; i++)
                array[i] = (i + 1) * 2;
            return array;
        }
    }
}
