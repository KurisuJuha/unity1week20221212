using Assets.Core.Engine;

namespace Assets.Core
{
    public class Enemy : GameObject
    {
        public Enemy() { }

        internal override GameObject Copy()
        {
            return BaseCopy(new Enemy());
        }
    }
}
