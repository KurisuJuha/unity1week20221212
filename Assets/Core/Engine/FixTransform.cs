using Assets.Core.Math;

namespace Assets.Core.Engine
{
    public class FixTransform
    {
        public FixVector size { get; internal set; }
        public FixVector position { get; internal set; }
        /// <summary>
        /// -1の場合時間軸関係なく干渉できる
        /// </summary>
        public int timeAxisId { get; internal set; }

        public FixTransform()
        {
            size = new FixVector();
            position = new FixVector();
            timeAxisId = -1;
        }

        public FixTransform(FixTransform fixTransform)
        {
            size = fixTransform.size;
            position = fixTransform.position;
            timeAxisId = fixTransform.timeAxisId;
        }
    }
}
