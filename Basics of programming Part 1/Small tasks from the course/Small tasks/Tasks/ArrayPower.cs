using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Small_tasks.Tasks
{
    internal class ArrayPower
    {
        public static int[] GetPoweredArray(int[] arr, int power)
        {
            var newArray = new int[arr.Length];
            for (int i = 0; i < newArray.Length; i++)
                newArray[i] = (int)Math.Pow(arr[i], power);
            return newArray;
        }
    }
}
