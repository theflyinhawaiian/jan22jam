using UnityEngine;

public class EnemyBehavior : MonoBehaviour
{
    public GameObject hub;
    public float maxVelocity;

    private Rigidbody2D body;

    void Start()
    {
        body = GetComponent<Rigidbody2D>();
        body.isKinematic = true;
    }

    void FixedUpdate()
    {
        var diff = transform.position - hub.transform.position;
        var moveDirection = new Vector2(diff.x, diff.y);

        Debug.Log($"move distance: {moveDirection.magnitude}");

        body.position = body.position - moveDirection.normalized * maxVelocity;
    }
}
