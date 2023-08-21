using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Small_tasks.Tasks
{
    internal class BenfordStatistics
    {
        public static int[] GetBenfordStatistics(string text)
        {
            var statistics = new int[10];
            for (int i = 0; i < text.Length; i++)
            {
                if ((i == 0) && (char.IsDigit(text[i])))
                    statistics[text[i] - '0']++;
                else if (char.IsDigit(text[i]) && !char.IsDigit(text[i - 1]))
                    statistics[text[i] - '0']++;
            }
            return statistics;
        }

        public static string ReplaceIncorrectSeparators(string text)
        {
            var symbols = new string[] { ": ", "; ", ", ", " - ", " " };
            foreach (var symbol in symbols)
                text = text.Replace(symbol, "\t");
            return text;
        }
    }
}
