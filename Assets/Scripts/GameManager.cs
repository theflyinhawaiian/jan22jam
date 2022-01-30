using UnityEngine;

namespace Assets.Scripts
{
    class GameManager : MonoBehaviour
    {
        public GameObject player;

        private void Start()
        {
            var enemySpawner = GetComponent<EnemySpawner>();
            var torchSpawner = player.GetComponentInChildren(typeof(ITorchSpawner)) as ITorchSpawner;
            torchSpawner.AddListener(enemySpawner);
        }
    }
}
