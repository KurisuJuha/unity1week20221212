using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace Assets.Core.Engine
{
    public class TimeLineEngine
    {
        public readonly int maxFrameCount;

        public TimeLineEngine(GameObject[] gameObjects, int maxFrameCount)
        {
            this.maxFrameCount = maxFrameCount;
        }
    }
}
