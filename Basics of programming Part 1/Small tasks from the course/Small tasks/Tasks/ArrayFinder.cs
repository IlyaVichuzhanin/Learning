using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Small_tasks.Tasks
{
    internal class ArrayFinder
    {
        public static int FindSubarrayStartIndex(int[] array, int[] subArray)
        {
            for (var i = 0; i < array.Length - subArray.Length + 1; i++)
                if (ContainsAtIndex(array, subArray, i))
                    return i;
            return -1;
        }

        public static bool ContainsAtIndex(int[] array, int[] subArray, int i)
        {
            bool matches = true;
            for (int j = 0; j < subArray.Length; j++)
            {
                if (subArray[j] == array[i + j])
                    matches = matches && true;
                else
                    matches = matches && false;
            }
            return matches;
        }
    }
}
