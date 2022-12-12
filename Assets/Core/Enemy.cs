using Assets.Core.Collision;
using Assets.Core.Math;
using FixMath.NET;

namespace Assets.Core
{
    public class Enemy
    {
        BoxCollision collision;
        public readonly FixTransform transform;

        public Enemy()
        {
            transform = new FixTransform()
            {
                position = new FixVector(new Fix64(0), new Fix64(0)),
                size = new FixVector(new Fix64(1), new Fix64(1)),
            };
            collision = new BoxCollision(ref transform);
        }
    }
}
