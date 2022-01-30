using Assets.Scripts;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour, ITargetable
{
    public float maxVelocity = 0.5f;

    public GameObject GameManager;
    public HealthSystem PlayerHealth;
    protected Rigidbody2D body;
    public Camera cam;

    private Vector2 move;
    private Vector2 mousePos;

    private GameManager manager;
    private GunBehavior gun;
    private TorchPlacementBehavior torchPlacer;

    private TorchBehavior torch;

    private PlayerItem activeItem;

    public float currentTime = -1000f;
    public float iframes = .5f;
    private float spawnBlockingRadius = 15;

    // Start is called before the first frame update
    void Start()
    {
        PlayerHealth = new HealthSystem(3);
        body = GetComponent<Rigidbody2D>();
        manager = GameManager.GetComponent<GameManager>();
        torch = GetComponentInChildren<TorchBehavior>();

        gun = GetComponentInChildren<GunBehavior>();
        torchPlacer = GetComponentInChildren<TorchPlacementBehavior>();

        activeItem = PlayerItem.Torch;
    }

    void Update()
    {
        move = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));

        mousePos = cam.ScreenToWorldPoint(Input.mousePosition);

        if (InDarkness())
            SceneManager.LoadScene("GameOver");

        if (Input.GetButton("Fire1"))
        {
            ProcessAction(activeItem);
        }

        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            activeItem = PlayerItem.Weapon;
        }
        else if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            activeItem = PlayerItem.Torch;
        }
    }

    bool InDarkness()
    {
        if (torch.GetRemainingFuel() > 0)
            return false;

        var inDarkness = true;
        foreach(var target in manager.targets)
        {
            if(target.transform != transform || target.GetSpawnBlockingRadius() != spawnBlockingRadius)
            {
                var targetPos = new Vector2(target.transform.position.x, target.transform.position.y);
                var playerPos = new Vector2(transform.position.x, transform.position.y);
                if (Vector2.Distance(targetPos, playerPos) <= target.GetSpawnBlockingRadius())
                {
                    inDarkness = false;
                }
            }
        }

        return inDarkness;
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
        if (hit.gameObject.tag == "Campfire")
        {
            var torch = GetComponentInChildren<TorchBehavior>();

            if (torch != null)
            {
                torch.Refuel();
            }
        }
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        // If the other thing has a specific tag. It's a good idea to limit the detection to specific things
        if (collision.gameObject.CompareTag("Enemy"))
        {
            if (iframes + currentTime > Time.time)
                return;
            // Destroy this gameobject?
            PlayerHealth.Damage(1);

            currentTime = Time.time;

            Debug.Log("Health: " + PlayerHealth.GetHealth());

            if (PlayerHealth.GetHealth() == 0)
            {
                SceneManager.LoadScene("GameOver");
            }
            // Destroy the gameobject this one collided with? Uncomment this next line
            //Destroy(collision.gameObject);
        }
    }


    public PlayerItem GetSelectedItem() => activeItem;

    public float GetSpawnBlockingRadius() => spawnBlockingRadius;
}
