using System.Collections.Generic;

namespace Assets.Core.Engine
{
    public class TimeLineEngine
    {
        private List<GameObject>[] _timeLine;
        private readonly int maxFrameCount;

        public TimeLineEngine(int maxFrameCount)
        {
            this.maxFrameCount = maxFrameCount;
            RegisterTimeLine();
        }

        private void RegisterTimeLine()
        {
            _timeLine = new List<GameObject>[maxFrameCount];
            for (int i = 0; i < maxFrameCount; i++) _timeLine[i] = new();
        }
    }
}
