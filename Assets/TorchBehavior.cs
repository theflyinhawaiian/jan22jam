using UnityEngine;
using UnityEngine.Experimental.Rendering.Universal;

public class TorchBehavior : MonoBehaviour
{
    public float decayRatePerSecond;
    public float startingIntensity = 2.2f;

    Light2D torch;

    float fuel = 1f;

    float timeAtLastDecay;

    void Start()
    {
        torch = GetComponent<Light2D>();

        timeAtLastDecay = Time.time;
    }

    void Update()
    {
        if (fuel <= 0)
        {
            fuel = 0;
            return;
        }

        var currentTime = Time.time;
        if(currentTime - timeAtLastDecay >= .1)
        {
            fuel -= (decayRatePerSecond / 10);
            timeAtLastDecay = currentTime;
        }

        torch.intensity = startingIntensity * fuel;
    }

    public void Refuel()
    {
        fuel = 1f;
    }
}
