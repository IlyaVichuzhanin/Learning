using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Small_tasks.Tasks
{
    public class MinPowerOfTwo
    {
        private static int GetMinPowerOfTwoLargerThan(int number)
        {
            int result = 1;
            while (result <= number)
                result *= 2;
            return result;
        }
    }
}
