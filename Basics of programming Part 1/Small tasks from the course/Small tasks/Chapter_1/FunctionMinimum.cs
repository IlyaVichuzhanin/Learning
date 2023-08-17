using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Small_tasks.Chapter_1
{
    public class FunctionMinimum
    {
        public static void WriteRoots()
        {
            Console.WriteLine(GetMinX(1, 2, 3));
            Console.WriteLine(GetMinX(0, 3, 2));
            Console.WriteLine(GetMinX(1, -2, -3));
            Console.WriteLine(GetMinX(5, 2, 1));
            Console.WriteLine(GetMinX(4, 3, 2));
            Console.WriteLine(GetMinX(0, 4, 5));

            // А в этих случаях решение существует:
            Console.WriteLine(GetMinX(0, 0, 2) != "Impossible");
            Console.WriteLine(GetMinX(0, 0, 0) != "Impossible");
        }
        private static string GetMinX(double a, double b, double c)
        {
            
            if (a <= 0&&b!=0)
            {
                return "Impossible";
            }
            else if (b!=0)
            {
                var x = -b / (2 * a);
                return x.ToString();
            }
            else
            {
                return c.ToString();
            }
        }
    }
}
