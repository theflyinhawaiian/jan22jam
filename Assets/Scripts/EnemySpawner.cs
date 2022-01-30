using System.Collections;
using Assets.Scripts;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject hub;
    public Transform player;
    public float spawnDelay = 1f;
    public GameObject enemyPrefab;

    private GameManager manager;

    public bool enableSpawning = true;

    void Start()
    {
        manager = GetComponent<GameManager>();

        if (!enableSpawning)
            return;

        StartCoroutine(SpawnEnemies());
    }

    IEnumerator SpawnEnemies()
    {
        while (true)
        {
            var tuple = GenerateTargetAndSpawnPoint();
            var enemy = Instantiate(enemyPrefab, tuple.spawnPoint, Quaternion.identity);
            enemy.GetComponent<EnemyController>().target = tuple.target.transform;
            yield return new WaitForSeconds(spawnDelay);
        }
    }

    (Vector2 spawnPoint, ITargetable target) GenerateTargetAndSpawnPoint()
    {
        var validSpawn = false;
        Vector2 spawnPosition = new Vector2();
        ITargetable selectedTarget = manager.targets[0];
        while (!validSpawn)
        {
            validSpawn = true;

            //pick a spawn point outside of a random target's radius
            selectedTarget = manager.targets[Random.Range(0, manager.targets.Count)];
            var randomTargetPos = new Vector2(selectedTarget.transform.position.x, selectedTarget.transform.position.y);
            var spawnDirection = Random.Range(0, 360);
            var spawnVector = new Vector2(Mathf.Cos(spawnDirection * Mathf.Deg2Rad), Mathf.Sin(spawnDirection * Mathf.Deg2Rad));
            spawnPosition = randomTargetPos + spawnVector * (selectedTarget.GetSpawnBlockingRadius() + 1);

            //verify the spawn position is not in the radius of any other target
            foreach(var target in manager.targets)
            {
                var targetPos = new Vector2(target.transform.position.x, target.transform.position.y);
                if (Vector2.Distance(spawnPosition, targetPos) < target.GetSpawnBlockingRadius())
                {
                    validSpawn = false;
                }
            }
        }

        return (spawnPosition, selectedTarget);
    }
}