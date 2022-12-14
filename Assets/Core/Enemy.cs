using Assets.Core.Engine;

namespace Assets.Core
{
    public class Enemy : GameObject
    {
        public Enemy(int timeAxisId) : base(timeAxisId)
        {

        }

        internal override GameObject Copy()
        {
            return BaseCopy(new Enemy());
        }
    }
}
