using Assets.Core.Engine;
using Assets.Core.Math;
using FixMath.NET;

namespace Assets.Core
{
    public class Player : GameObject
    {
        public Player(int timeAxisId) : base(timeAxisId)
        {

        }

        internal override void Update(Frame frame)
        {
            transform.position += new FixVector(new Fix64(1) / new Fix64(100), new Fix64(0));
            Debug.Log(frame.input.rightArrow);
        }

        internal override GameObject Copy()
        {
            return BaseCopy(new Player());
        }
    }
}
