namespace GeometryTasks
{
    public class Vector
    {
        public double X = 0;
        public double Y = 0;

        public double GetLength()
        {
            return Geometry.GetLength(this);
        }

        public Vector Add(Vector vector)
        {
            return Geometry.Add(this, vector);
        }

        public bool Belongs(Segment segment)
        {
            return Geometry.IsVectorInSegment(this, segment);
        }
    }

    public class Geometry
    {
        public static double GetLength(Vector a)
        {
            return System.Math.Sqrt(a.X * a.X + a.Y * a.Y);
        }

        public static Vector Add(Vector a, Vector b)
        {
            return new Vector() { X = a.X + b.X, Y = a.Y + b.Y };
        }

        public static double GetLength(Segment a)
        {
            var aVector = new Vector() { X = a.End.X - a.Begin.X, Y = a.End.Y - a.Begin.Y };
            return GetLength(aVector);
        }

        public static bool IsVectorInSegment(Vector x, Segment ab)
        {
            var axLength = GetLength(new Vector() { X = x.X - ab.Begin.X, Y = x.Y - ab.Begin.Y });
            var bxLength = GetLength(new Vector() { X = x.X - ab.End.X, Y = x.Y - ab.End.Y });
            var abLength = GetLength(ab);
            return axLength + bxLength == abLength;
        }
    }

    public class Segment
    {
        public Vector Begin = new Vector { X = 0, Y = 0 };
        public Vector End = new Vector { X = 0, Y = 0 };

        public double GetLength()
        {
            return Geometry.GetLength(this);
        }

        public bool Contains(Vector vector)
        {
            return Geometry.IsVectorInSegment(vector, this);
        }
    }
}