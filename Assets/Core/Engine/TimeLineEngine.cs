using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace Assets.Core.Engine
{
    public class TimeLineEngine
    {
        public readonly Frame rootFrame;
        public readonly int maxFrameCount;

        public TimeLineEngine(GameObject[] gameObjects, int maxFrameCount)
        {
            rootFrame = Frame.CreateRoot(gameObjects, maxFrameCount);
            this.maxFrameCount = maxFrameCount;
        }
    }
}
