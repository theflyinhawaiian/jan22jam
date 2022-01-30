using UnityEngine;

public class HubBehavior : MonoBehaviour, ITargetable
{
    private float spawnBlockingRadius = 30;

    public float GetSpawnBlockingRadius() => spawnBlockingRadius;
}
