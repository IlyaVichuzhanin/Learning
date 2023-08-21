using System;

namespace Names
{
    internal static class HeatmapTask
    {
        public static HeatmapData GetBirthsPerDateHeatmap(NameData[] names)
        {
            var xLabels = new string[30];
            for (int i = 0; i < xLabels.Length; i++)
                xLabels[i] = (i + 2).ToString();
            var yLabels = new string[12];
            for (int i = 0; i < yLabels.Length; i++)
                yLabels[i] = (i + 1).ToString();
            var birthCount = new double[30, 12];

            foreach (var item in names)
                if ((item.BirthDate.Day > 1))
                    birthCount[item.BirthDate.Day - 2, item.BirthDate.Month - 1]++;

            return new HeatmapData("Пример карты интенсивностей", birthCount, xLabels, yLabels);
        }
    }
}