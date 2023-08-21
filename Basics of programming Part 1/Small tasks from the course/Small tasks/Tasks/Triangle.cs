using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Small_tasks.Tasks
{
    public class Triangle : Object
    {
        public Point A = new Point() { X = 0, Y = 0 };
        public Point B = new Point() { X = 0, Y = 0 };
        public Point C = new Point() { X = 0, Y = 0 };

        public override string ToString()
        {
            return string.Format("({0} {1}) ({2} {3}) ({4} {5}) ", A.X, A.Y, B.X, B.Y, C.X, C.Y);
        }
    }

    public class Point
    {
        public double X;
        public double Y;
        public override string ToString()
        {
            return string.Format("{0} {1}", X, Y);
        }
    }
}
