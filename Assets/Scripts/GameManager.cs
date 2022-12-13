using UnityEngine;
using Assets.Core;
using Assets.Core.Engine;

namespace JuhaKurisu
{
    public class GameManager : MonoBehaviour
    {
        [SerializeField] TimeLineViewer timeLineViewer;
        TimeLineEngine engine;

        private void Awake()
        {
            Assets.Core.Engine.Debug.log += UnityEngine.Debug.Log;
            engine = new TimeLineEngine(new Assets.Core.Engine.GameObject[]
            {
                new Player(),
                new Enemy(),
                new Enemy(),
            }, 10);

            Frame f = engine.rootFrame;

            for (int i = 0; i < 9; i++)
            {
                 UnityEngine.Debug.Log(f.CreateFuture());
                f = f.CreateFuture();
                UnityEngine.Debug.Log(f);
            }

            timeLineViewer.timeLineEngine = engine;
        }
    }
}
