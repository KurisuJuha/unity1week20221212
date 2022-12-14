using Assets.Core.Collision;
using Assets.Core.Math;

namespace Assets.Core.Engine
{
    public abstract class GameObject
    {
        internal BoxCollision collision;
        public FixTransform transform { get; private set; }

        public GameObject()
        {
            transform = new FixTransform()
            {
                position = new FixVector(new FixMath.NET.Fix64(0), new FixMath.NET.Fix64(0)),
                size = new FixVector(new FixMath.NET.Fix64(1), new FixMath.NET.Fix64(1)),
                timeAxisId = -1
            };
            collision = new BoxCollision(transform);
        }

        public GameObject(int timeAxisId)
        {
            transform = new FixTransform()
            {
                position = new FixVector(new FixMath.NET.Fix64(0), new FixMath.NET.Fix64(0)),
                size = new FixVector(new FixMath.NET.Fix64(1), new FixMath.NET.Fix64(1)),
                timeAxisId = timeAxisId
            };
            collision = new BoxCollision(transform);
        }

        internal virtual void Init() { }

        internal virtual void Update(Frame frame) { }

        internal abstract GameObject Copy();

        protected GameObject BaseCopy(GameObject newGameObject)
        {
            newGameObject.transform = new FixTransform(transform);
            newGameObject.collision = new BoxCollision(newGameObject.transform);
            return newGameObject;
        }
    }
}
