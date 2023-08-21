using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Small_tasks.Tasks
{
    internal class GetMaxElementOfArray
    {
        public static int MaxIndex(double[] array)
        {
            if (array.Length == 0)
            {
                return -1;
            }
            else
            {
                int indexMax = 0;
                double valueMax = array[0];
                for (int i = 0; i < array.Length; i++)
                {
                    if (array[i] > valueMax)
                    {
                        valueMax = array[i];
                        indexMax = i;
                    }
                }
                return indexMax;
            }
        }
    }
}
