using Assets.Core.Collision;
using Assets.Core.Math;

namespace Assets.Core
{
    public class Player
    {
        BoxCollision collision;
        public readonly FixTransform transform;

        public Player()
        {
            transform = new FixTransform()
            {
                position = new FixVector(new FixMath.NET.Fix64(3), new FixMath.NET.Fix64(0)),
                size = new FixVector(new FixMath.NET.Fix64(1), new FixMath.NET.Fix64(1)),
            };
            collision = new BoxCollision(ref transform);
        }
    }
}
