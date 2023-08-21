using System;
using System.Linq;

namespace Names
{
    internal static class HistogramTask
    {
        public static HistogramData GetBirthsPerDayHistogram(NameData[] names, string name)
        {
            var labels = new string[31];
            for (int i = 0; i < 31; i++)
                labels[i] = (i + 1).ToString();

            var values = new double[31];
            foreach (var item in names)
                if ((item.BirthDate.Day > 1) & (item.Name == name))
                    values[item.BirthDate.Day - 1]++;

            return new HistogramData(
                string.Format("Рождаемость людей с именем '{0}'", name),
                labels,
                values);
        }
    }
}