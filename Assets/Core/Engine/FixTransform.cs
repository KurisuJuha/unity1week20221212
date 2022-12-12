using Assets.Core.Math;

namespace Assets.Core.Engine
{
    public class FixTransform
    {
        public FixVector size;
        public FixVector position;

        public FixTransform()
        {
            size = new FixVector();
            position = new FixVector();
        }

        public FixTransform(FixTransform fixTransform)
        {
            size = fixTransform.size;
            position = fixTransform.position;
        }
    }
}
