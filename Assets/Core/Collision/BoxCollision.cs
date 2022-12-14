using Assets.Core.Engine;
using Assets.Core.Math;
using FixMath.NET;

namespace Assets.Core.Collision
{
    internal class BoxCollision
    {
        readonly FixTransform transform;

        public BoxCollision(FixTransform transform)
        {
            this.transform = transform;
        }

        public bool Detect(BoxCollision otherBoxCollision)
        {
            FixTransform otherTransform = otherBoxCollision.transform;
            FixVector distance = FixVector.Abs(otherBoxCollision.transform.position - transform.position);

            if (distance.x < (otherTransform.size.x + transform.size.x) / new Fix64(2)
             && distance.y < (otherTransform.size.y + transform.size.y) / new Fix64(2)
             && (transform.timeAxisId == -1 || otherTransform.timeAxisId == -1 || transform.timeAxisId == otherTransform.timeAxisId)) 
                return true;

            return false;
        }
    }
}
