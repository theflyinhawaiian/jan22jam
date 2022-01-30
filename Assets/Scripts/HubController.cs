using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.SceneManagement;

public class HubController : MonoBehaviour
{
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
