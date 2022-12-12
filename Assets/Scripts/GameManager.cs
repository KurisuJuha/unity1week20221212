using UnityEngine;
using Assets.Core;

namespace JuhaKurisu
{
    public class GameManager : MonoBehaviour
    {
        [SerializeField] GameObject playerObj;
        [SerializeField] GameObject enemyObj;

        private void Awake()
        {
            Assets.Core.Engine.Debug.log += Debug.Log;
        }
    }
}
