using System.Collections.Generic;
using Assets.Scripts;
using UnityEngine;

public class TorchPlacementBehavior : MonoBehaviour, IItemWithCooldown, ITorchSpawner
{
    public GameObject torchPrefab;
    public float cooldown = 5;

    private float lastPlaceTime = -1000;

    private List<ITorchSpawnListener> torchSpawnListeners= new List<ITorchSpawnListener>();

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
        torch.OnDying += dyingTorch => NotifyTorchDestroyed(dyingTorch);

        foreach (var listener in torchSpawnListeners)
            listener.OnTorchSpawned(torch);

        lastPlaceTime = currTime;
    }

    private void NotifyTorchDestroyed(ITargetable dyingTorch)
    {
        foreach (var listener in torchSpawnListeners)
            listener.OnTorchDestroyed(dyingTorch);
    }

    void OnDestroy()
    {
        ClearListeners();
    }

    public void AddListener(ITorchSpawnListener listener) => torchSpawnListeners.Add(listener);

    public void RemoveListener(ITorchSpawnListener listener) => torchSpawnListeners.Remove(listener);

    public void ClearListeners() => torchSpawnListeners.Clear();
}
