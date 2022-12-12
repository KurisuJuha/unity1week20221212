using FixMath.NET;

namespace Assets.Core.Math
{
    public struct FixVector
    {
        public readonly Fix64 x;
        public readonly Fix64 y;

        public FixVector(Fix64 x, Fix64 y)
        {
            this.x = x;
            this.y = y;
        }

        public static FixVector operator-(FixVector a, FixVector b)
        {
            return new FixVector(a.x - b.x, a.y - b.y);
        }

        public static FixVector operator+(FixVector a, FixVector b)
        {
            return new FixVector(a.x + b.x, a.y - b.y);
        }

        public static FixVector Abs(FixVector a)
        {
            return new FixVector(Fix64.Abs(a.x), Fix64.Abs(a.y));
        }
    }
}
