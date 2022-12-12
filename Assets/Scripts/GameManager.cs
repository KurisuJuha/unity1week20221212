using UnityEngine;
using Assets.Core;

namespace JuhaKurisu
{
    public class GameManager : MonoBehaviour
    {
        [SerializeField] GameObject playerObj;
        [SerializeField] GameObject enemyObj;

        Player player;
        Enemy enemy;

        private void Awake()
        {
            Assets.Core.Debug.log += UnityEngine.Debug.Log;
            player = new Player();
            enemy = new Enemy();
        }

        public void Update()
        {
            playerObj.transform.position = new Vector2((float)player.transform.position.x, (float)player.transform.position.y);
            enemyObj.transform.position = new Vector2((float)enemy.transform.position.x, (float)enemy.transform.position.y);
        }
    }
}
