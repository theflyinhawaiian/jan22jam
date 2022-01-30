using UnityEngine;
using Assets.Scripts;

public class TorchPlacementBehavior : MonoBehaviour, IItemWithCooldown
{
    public GameObject torchPrefab;
    public float cooldown = 5;

    private float lastPlaceTime = -1000;

    public float GetCooldown() => cooldown;

    public float GetLastUseTime() => lastPlaceTime;

    public void PlaceTorch()
    {
        var currTime = Time.time;
        if (currTime - lastPlaceTime < cooldown)
            return;

        Instantiate(torchPrefab, transform.position, transform.rotation);

        lastPlaceTime = currTime;
    }
}
