using UnityEngine;
using Assets.Core;
using Assets.Core.Engine;

namespace JuhaKurisu
{
    public class GameManager : MonoBehaviour
    {
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
        }
    }
}
