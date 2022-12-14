using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace Assets.Core.Engine
{
    public class TimeLine
    {
        public readonly int maxFrameCount;
        public readonly ReadOnlyCollection<Frame> frames;

        private readonly GameObject[] gameObjects;

        public TimeLine(GameObject[] gameObjects, int maxFrameCount)
        {
            this.gameObjects = gameObjects;
            this.maxFrameCount = maxFrameCount;
            frames = RegisterFrames().AsReadOnly();
        }

        private List<Frame> RegisterFrames()
        {
            List<Frame> ret = new List<Frame>();

            Frame f = Frame.CreateRoot(gameObjects);
            ret.Add(f);

            for (int i = 0; i < maxFrameCount - 1; i++)
            {
                f = f.CreateFuture();
                ret.Add(f);
            }

            return ret;
        }
    }
}
