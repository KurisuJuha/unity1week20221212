using UnityEngine;
using Assets.Core;

namespace JuhaKurisu
{
    public class GameManager : MonoBehaviour
    {
        [SerializeField] GameObject playerObj;
        [SerializeField] GameObject enemyObj;

        Player player;

        private void Awake()
        {
            player = new Player();
        }

        public void Update()
        {
            playerObj.transform.position = new Vector2((float)player.transform.position.x, (float)player.transform.position.y);
        }
    }
}