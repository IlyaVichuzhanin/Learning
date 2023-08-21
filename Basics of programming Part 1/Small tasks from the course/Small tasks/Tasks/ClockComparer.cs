using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Small_tasks.Tasks
{
    internal class ClockComparer
    {
        private static void Main()
        {
            var array = new[]
            {
        new Point { X = 1, Y = 0 },
        new Point { X = -1, Y = 0 },
        new Point { X = 0, Y = 1 },
        new Point { X = 0, Y = -1 },
        new Point { X = 0.01, Y = 1 }
    };
            Array.Sort(array, new ClockwiseComparer());
            foreach (Point e in array)
                Console.WriteLine("{0} {1}", e.X, e.Y);
        }

        public class Point
        {
            public double X;
            public double Y;
        }
    }
    class ClockwiseComparer : IComparer
    {
        public int Compare(object x, object y)
        {
            var point1 = (Point)x;
            var point2 = (Point)y;
            var angle1 = -Math.Atan2(point1.Y, -point1.X);
            var angle2 = -Math.Atan2(point2.Y, -point2.X);
            return angle1.CompareTo(angle2);
        }
    }
}
