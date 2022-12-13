using UnityEngine;
using Assets.Core;
using Assets.Core.Engine;
using System.Linq;

namespace JuhaKurisu
{
    public class GameManager : MonoBehaviour
    {
        [SerializeField] TimeLineViewer timeLineViewer;
        public static TimeLineEngine engine { get; private set; }

        private void Awake()
        {
            Assets.Core.Engine.Debug.log += UnityEngine.Debug.Log;
            engine = new TimeLineEngine(new Assets.Core.Engine.GameObject[]
            {
                new Player(),
                new Enemy(),
                new Enemy(),
            }, 10);

            Frame root = engine.rootFrame;

            root.CreateFuture().CreateFuture().CreateFuture().CreateFuture();
            root.futures.First().futures.First().CreateFuture().CreateFuture();
            root.futures.First().CreateFuture();
            root.futures.First().futures.First().futures[1].CreateFuture();

            timeLineViewer.timeLineEngine = engine;
        }
    }
}
