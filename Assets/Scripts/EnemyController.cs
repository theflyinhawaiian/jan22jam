using UnityEngine;

public class EnemyController : MonoBehaviour
{
    private HealthSystem EnemyHealth;



    public GameObject hub;
    public float maxVelocity;

    private Rigidbody2D body;

    void Start()
    {
        body = GetComponent<Rigidbody2D>();
        body.isKinematic = true;

        EnemyHealth = new HealthSystem(10);
    }

    void FixedUpdate()
    {
        var diff = transform.position - hub.transform.position;
        var moveDirection = new Vector2(diff.x, diff.y);

        body.position = body.position - moveDirection.normalized * maxVelocity;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        // If the other thing has a specific tag. It's a good idea to limit the detection to specific things
        if (collision.gameObject.CompareTag("Bullet"))
        {
            // Destroy this gameobject?
            EnemyHealth.Damage(1);
            Debug.Log("Health: " + EnemyHealth.GetHealth());

            if (EnemyHealth.GetHealth() == 0)
            {
                Destroy(gameObject);
            }
            // Destroy the gameobject this one collided with? Uncomment this next line
            //Destroy(collision.gameObject);
        }
    }







}
