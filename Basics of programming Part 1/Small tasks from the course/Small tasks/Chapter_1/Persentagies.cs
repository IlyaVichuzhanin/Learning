using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Small_tasks.Chapter_1
{
    internal class Persentagies
    {
        public static double Calculate(string userInput)
        {
            string[] number = userInput.Split(' ');
            double a = Convert.ToDouble(number[0]);
            double b = Convert.ToDouble(number[1]);
            double c = Convert.ToDouble(number[2]);
            return a * Math.Pow(1 + b / 12 / 100, c);
        }
    }
}
