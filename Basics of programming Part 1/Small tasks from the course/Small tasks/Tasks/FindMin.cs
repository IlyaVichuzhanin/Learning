using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Small_tasks.Tasks
{
    internal class FindMin
    {
        public static void Start()
        {
            Console.WriteLine(Min(new[] { 3, 6, 2, 4 }));
            Console.WriteLine(Min(new[] { "B", "A", "C", "D" }));
            Console.WriteLine(Min(new[] { '4', '2', '7' }));
        }

        static object Min(Array arr)
        {
            var min = (IComparable)arr.GetValue(0);
            foreach (IComparable val in arr)
            {
                if (val.CompareTo(min) < 0) min = val;
            }
            return min;
        }
    }
}
