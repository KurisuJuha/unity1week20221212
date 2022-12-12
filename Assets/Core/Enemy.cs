using Assets.Core.Engine;

namespace Assets.Core
{
    public class Enemy : GameObject
    {
        internal Enemy() { }

        public override GameObject Copy()
        {
            return new Enemy();
        }
    }
}
