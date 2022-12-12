using Assets.Core.Collision;
using Assets.Core.Math;

namespace Assets.Core.Engine
{
    public abstract class GameObject
    {
        internal BoxCollision collision;
        public readonly FixTransform transform;

        public GameObject()
        {
            transform = new FixTransform()
            {
                position = new FixVector(new FixMath.NET.Fix64(0), new FixMath.NET.Fix64(0)),
                size = new FixVector(new FixMath.NET.Fix64(1), new FixMath.NET.Fix64(1)),
            };
            collision = new BoxCollision(ref transform);
        }

        public virtual void Init() { }

        public virtual void Update(Frame frame) { }

        public abstract GameObject Copy();
    }
}
