using UnityEngine;

public class PlayerController : MonoBehaviour
{

    public float maxVelocity = 0.5f;
    public GunBehavior gun;

    protected Rigidbody2D body;
    public Camera cam;

    private Vector2 move;
    private Vector2 mousePos;

    // Start is called before the first frame update
    void Start()
    {
        body = GetComponent<Rigidbody2D>();
        body.isKinematic = true;
    }

    void Update()
    {
        move = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));

        mousePos = cam.ScreenToWorldPoint(Input.mousePosition);
        
        
        if (Input.GetButton("Fire1"))
        {
            gun.FireBullet();
        }
    }

    void FixedUpdate()
    {
        body.position = body.position + (move * maxVelocity);

        Vector2 lookDir = mousePos - body.position;
        float angle = Mathf.Atan2(lookDir.y, lookDir.x) * Mathf.Rad2Deg - 90f;
        body.rotation = angle;
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
