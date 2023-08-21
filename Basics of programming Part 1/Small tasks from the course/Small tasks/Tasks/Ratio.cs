using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Small_tasks.Tasks
{
    public class Ratio
    {
        public Ratio(int num, int den)
        {
            if (den <= 0) throw new ArgumentException();

            Numerator = num;
            Denominator = den;
            Value = (double)num / den;
        }

        public readonly int Numerator; //числитель
        public readonly int Denominator; //знаменатель
        public readonly double Value; //значение дроби Numerator / Denominator
    }
}
