using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GeometryTasks;

namespace GeometryPainting
{
    public static class SegmentExtensions
    {
        public static Dictionary<Segment, Color> ColoredSegments = new Dictionary<Segment, Color>();
        public static void SetColor(this Segment segment, Color color)
        {
            if (ColoredSegments.ContainsKey(segment))
                ColoredSegments[segment] = color;
            else
                ColoredSegments.Add(segment, color);
        }

        public static Color GetColor(this Segment segment)
        {
            if (ColoredSegments.ContainsKey(segment)) return ColoredSegments[segment];
            return Color.Black;
        }
    }
}
