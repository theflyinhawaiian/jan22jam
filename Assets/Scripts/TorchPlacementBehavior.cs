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

        var obj = Instantiate(torchPrefab, transform.position, transform.rotation);
        var torch = obj.GetComponentInChildren<TorchBehavior>();
        torch.destroyOnExhaust = true;

        lastPlaceTime = currTime;
    }
}
