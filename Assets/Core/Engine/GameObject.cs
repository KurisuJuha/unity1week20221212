using Assets.Core.Math;
using FixMath.NET;

namespace Assets.Core.Engine
{
    public struct GameObject
    {
        public FixVector size { get; internal set; }
        public FixVector position { get; internal set; }
        public Input input;
        public readonly int timeAxisId;
        public readonly string Id;

        public GameObject(string Id,int timeAxisId)
        {
            size = new FixVector();
            position = new FixVector();
            input = new Input();
            this.timeAxisId = timeAxisId;
            this.Id = Id;
        }

        public bool Detect(GameObject gameObject)
        {
            FixVector distance = FixVector.Abs(gameObject.position - position);

            if (distance.x < (gameObject.size.x + size.x) / new Fix64(2)
             && distance.y < (gameObject.size.y + size.y) / new Fix64(2)
            && (timeAxisId == -1 || gameObject.timeAxisId == -1 || timeAxisId == gameObject.timeAxisId))
                return true;

            return false;
        }
    }
}
