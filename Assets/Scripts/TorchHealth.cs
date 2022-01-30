using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TorchHealth : MonoBehaviour
{

    private HealthSystem TorchHP;

    void Start()
    {
        TorchHP = new HealthSystem(1);
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            TorchHP.Damage(1);
            Destroy(collision.gameObject);

            if (TorchHP.GetHealth() == 0)
            {
                Destroy(gameObject);
            }
        }
    }
}
