using System.Collections.Generic;

namespace Assets.Core.Engine
{
    public class TimeLineEngine
    {
        readonly List<GameObject> gameObjects;
        readonly Frame rootFrame;

        public TimeLineEngine()
        {
            gameObjects = new List<GameObject>();
            rootFrame = Frame.CreateRoot();
        }
    }
}
