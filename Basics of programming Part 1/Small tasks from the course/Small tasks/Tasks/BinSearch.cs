using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Small_tasks.Tasks
{
    internal class BinSearch
    {
        private static int FindLeftBorder(long[] arr, long value)
        {
            return BinSearchLeftBorder(arr, value, -1, arr.Length);
        }

        public static int BinSearchLeftBorder(long[] array, long value, int left, int right)
        {
            if (array.Length == left + 1 || array[left + 1] >= value || array.Length == 0) return left;
            var m = (left + right) / 2;
            if (array[m] < value)
                return BinSearchLeftBorder(array, value, m, right);
            return BinSearchLeftBorder(array, value, left, m);
        }
    }
}
