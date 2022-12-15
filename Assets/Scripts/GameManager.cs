using UnityEngine;
using Assets.Core.Engine;

namespace JuhaKurisu
{
    public class GameManager : MonoBehaviour
    {
        public static TimeLineEngine engine { get; private set; }
        [Range(0, 9)]
        public int tick;

        private void Awake()
        {
            Assets.Core.Engine.Debug.log += UnityEngine.Debug.Log;
        }

        private void Update()
        {

        }
    }
}
