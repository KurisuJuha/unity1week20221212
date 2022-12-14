using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace Assets.Core.Engine
{
    public class TimeLineEngine
    {
        public readonly int maxFrameCount;
        public ReadOnlyCollection<TimeLine> timeLines => _timeLines.AsReadOnly();

        private GameObject[] gameObjects;
        private List<TimeLine> _timeLines;

        public TimeLineEngine(GameObject[] gameObjects, int maxFrameCount)
        {
            this.gameObjects = gameObjects;
            this.maxFrameCount = maxFrameCount;
            _timeLines = new List<TimeLine>();
        }

        public TimeLine CreateTimeLine()
        {
            _timeLines.Add(new TimeLine(gameObjects.Select(g => g.Copy()).ToArray(), maxFrameCount));
            return _timeLines.Last();
        }
    }
}
