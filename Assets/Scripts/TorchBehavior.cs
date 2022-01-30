 using UnityEngine;
using UnityEngine.Experimental.Rendering.Universal;

public class TorchBehavior : MonoBehaviour, ITargetable
{
    public float decayRatePerSecond;
    public float startingIntensity = 2.2f;
    public float startingRadius = 5.5f;
    public bool destroyOnExhaust = false;

    float maxFuel = 1f;

    Light2D torch;

    float fuel;

    float timeAtLastDecay;

    private float spawnBlockingRadius = 10;

    public delegate void TorchDestroyedHandler(ITargetable torch);
    public event TorchDestroyedHandler OnDying;

    void Start()
    {
        torch = GetComponent<Light2D>();

        timeAtLastDecay = Time.time;
        fuel = maxFuel;
    }

    void Update()
    {
        if (fuel <= 0)
        {
            fuel = 0;
            if (destroyOnExhaust)
                Destroy(transform.parent.gameObject);
            return;
        }

        var currentTime = Time.time;
        if(currentTime - timeAtLastDecay >= .1)
        {
            fuel -= (decayRatePerSecond / 10);
            timeAtLastDecay = currentTime;
        }

        torch.pointLightOuterRadius = startingRadius * fuel;
        torch.intensity = startingIntensity * fuel;
    }

    private void OnDestroy()
    {
        if(OnDying != null)
            OnDying.Invoke(this);
    }

    public void Refuel() => fuel = 1f;

    public float GetRemainingFuel() => fuel;

    public float GetMaxFuel() => maxFuel;

    public float GetSpawnBlockingRadius() => spawnBlockingRadius;
}
