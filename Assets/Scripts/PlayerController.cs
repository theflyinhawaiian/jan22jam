using UnityEngine;

public class PlayerController : MonoBehaviour
{

    protected Rigidbody2D body;

    private Vector2 move;

    // Start is called before the first frame update
    void Start()
    {
        body = GetComponent<Rigidbody2D>();
        body.isKinematic = true;
    }

    void Update()
    {
        move = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
    }

    void FixedUpdate()
    {
        body.position = body.position + move;
    }

    void OnTriggerEnter2D(Collider2D hit)
    {
        if(hit.gameObject.tag == "Campfire")
        {
            var torch = GetComponentInChildren<TorchBehavior>();

            if(torch != null)
            {
                torch.Refuel();
            }
        }
    }
}
