using Assets.Scripts;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float maxVelocity = 0.5f;

    private HealthSystem PlayerHealth;
    protected Rigidbody2D body;
    public Camera cam;

    private Vector2 move;
    private Vector2 mousePos;

    private GunBehavior gun;
    private TorchPlacementBehavior torchPlacer;

    private PlayerItem activeItem;

    // Start is called before the first frame update
    void Start()
    {
        PlayerHealth = new HealthSystem(100);
        body = GetComponent<Rigidbody2D>();
        body.isKinematic = true;

        gun = GetComponentInChildren<GunBehavior>();
        torchPlacer = GetComponentInChildren<TorchPlacementBehavior>();

        activeItem = PlayerItem.Torch;
    }

    void Update()
    {
        move = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));

        mousePos = cam.ScreenToWorldPoint(Input.mousePosition);


        if (Input.GetButton("Fire1"))
        {
            ProcessAction(activeItem);
        }

        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            activeItem = PlayerItem.Weapon;
        } else if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            activeItem = PlayerItem.Torch;
        }
    }

    void ProcessAction(PlayerItem item)
    {
        switch (item)
        {
            case PlayerItem.Weapon:
                gun.FireBullet();
                break;
            case PlayerItem.Torch:
                torchPlacer.PlaceTorch();
                break;
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

    public PlayerItem GetSelectedItem() => activeItem;
}
