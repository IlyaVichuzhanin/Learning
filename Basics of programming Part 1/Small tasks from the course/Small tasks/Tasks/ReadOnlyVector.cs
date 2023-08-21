using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Small_tasks.Tasks
{
    public class ReadOnlyVector
    {
        public readonly double X;
        public readonly double Y;
        public double Length
        {
            get
            {
                return Math.Sqrt(X * X + Y * Y);
            }
        }

        public ReadOnlyVector(double x, double y)
        {
            this.X = x;
            this.Y = y;
        }

        public ReadOnlyVector Add(ReadOnlyVector another)
        {
            return new ReadOnlyVector(this.X + another.X, this.Y + another.Y);
        }

        public ReadOnlyVector WithX(double x)
        {
            return new ReadOnlyVector(x, this.Y);
        }

        public ReadOnlyVector WithY(double y)
        {
            return new ReadOnlyVector(this.X, y);
        }

        public override string ToString()
        {
            return string.Format("({0}, {1}) with length: {2}", X, Y, Length);
        }
    }
}
