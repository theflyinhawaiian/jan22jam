using Assets.Scripts;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour, ITorchSpawnListener
{
    public GameObject hub;
    public Transform player;
    public float spawnDelay = 1f;
    public GameObject enemyPrefab;

    public bool enableSpawning = true;

    private List<ITargetable> availableTargets;

    void Start()
    {
        var playerController = player.GetComponent<PlayerController>();

        availableTargets = new List<ITargetable>()
        {
            hub.GetComponent<HubBehavior>(),
            playerController
        };

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
        ITargetable selectedTarget = availableTargets[0];
        while (!validSpawn)
        {
            validSpawn = true;

            //pick a spawn point outside of a random target's radius
            selectedTarget = availableTargets[Random.Range(0, availableTargets.Count)];
            var randomTargetPos = new Vector2(selectedTarget.transform.position.x, selectedTarget.transform.position.y);
            var spawnDirection = Random.Range(0, 360);
            var spawnVector = new Vector2(Mathf.Cos(spawnDirection * Mathf.Deg2Rad), Mathf.Sin(spawnDirection * Mathf.Deg2Rad));
            spawnPosition = randomTargetPos + spawnVector * (selectedTarget.GetSpawnBlockingRadius() + 1);

            //verify the spawn position is not in the radius of any other target
            foreach(var target in availableTargets)
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

    public void OnTorchSpawned(ITargetable torch)
    {
        availableTargets.Add(torch);
        Debug.Log($"Torch Spawned. Number of torches: {availableTargets.Count}");
    }

    public void OnTorchDestroyed(ITargetable torch)
    {
        availableTargets.Remove(torch);
        Debug.Log($"Torch Destroyed. Number of torches: {availableTargets.Count}");
    }
}