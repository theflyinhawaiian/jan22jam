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
}
