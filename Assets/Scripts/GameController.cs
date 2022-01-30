using UnityEngine;

public class GameController : MonoBehaviour
{
    public GameObject hub;
    public int numberOfEnemiesToSpawn = 20;
    public float spawnDistance = 15;
    public GameObject enemyPrefab;

    public bool enableSpawning = true;

    void Start()
    {
        var hubPos = new Vector2(hub.transform.position.x, hub.transform.position.y);

        HealthSystem healthSystem = new HealthSystem(100);

        Debug.Log("Health: " + healthSystem.GetHealth());
       
        

        if (!enableSpawning)
            return;

        for(int i = numberOfEnemiesToSpawn; i > 0; i--)
        {
            var spawnDirection = Random.Range(0, 360);
            var spawnVector = new Vector2(Mathf.Cos(spawnDirection * Mathf.Deg2Rad), Mathf.Sin(spawnDirection * Mathf.Deg2Rad));
            var enemy = Instantiate(enemyPrefab, hubPos + spawnVector * spawnDistance, Quaternion.identity);
            enemy.GetComponent<EnemyController>().hub = hub;
        }
    }



}
