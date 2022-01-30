using Assets.Scripts;

public class HealthBarBehavior : ProgressBar
{
    HealthSystem health;

    void Start()
    {
        current = 1f;
        max = 1f;
        scaleDirection = ScaleDirection.X;
    }

    void Update()
    {
        var health = player.GetComponent<PlayerController>().PlayerHealth;

        current = health.GetHealth();
        max = health.GetMaxHealth();
        UpdateCurrent(health.GetHealth());
    }
}
