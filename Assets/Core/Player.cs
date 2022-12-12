using Assets.Core.Engine;
using Assets.Core.Math;
using FixMath.NET;

namespace Assets.Core
{
    public class Player : GameObject
    {
        public Enemy enemy;

        public override void Update()
        {
            transform.position += new FixVector(new Fix64(1) / new Fix64(100), new Fix64(0));
            Debug.Log(collision.Detect(enemy.collision));
        }
    }
}
