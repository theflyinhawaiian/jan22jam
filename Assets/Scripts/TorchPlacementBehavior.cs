using UnityEngine;

public class TorchPlacementBehavior : MonoBehaviour
{
    public GameObject torchPrefab;
    public float cooldown = 5;

    private float lastPlaceTime = -1000;

    public void PlaceTorch()
    {
        var currTime = Time.time;
        if (currTime - lastPlaceTime < cooldown)
            return;

        Instantiate(torchPrefab, transform.position, transform.rotation);

        lastPlaceTime = currTime;
    }
}
