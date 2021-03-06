using UnityEngine;
using UnityEngine.SceneManagement;

public class HubBehavior : MonoBehaviour, ITargetable
{
    private float spawnBlockingRadius = 30;

    public float GetSpawnBlockingRadius() => spawnBlockingRadius;

    private HealthSystem HubHealth;

    void Start()
    {
        HubHealth = new HealthSystem(10);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            HubHealth.Damage(1);
            Destroy(collision.gameObject);

            if (HubHealth.GetHealth() == 0)
            {
                SceneManager.LoadScene("GameOver");
            }
        }
    }
}
