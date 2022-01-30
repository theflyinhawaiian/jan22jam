using UnityEngine;
using System.Collections.Generic;

namespace Assets.Scripts
{
    class GameManager : MonoBehaviour, ITorchSpawnListener
    {
        public GameObject player, hub;

        public List<ITargetable> targets = new List<ITargetable>();

        public void OnTorchSpawned(ITargetable torch)
        {
            targets.Add(torch);
        }

        public void OnTorchDestroyed(ITargetable torch)
        {
            targets.Remove(torch);
        }

        private void Start()
        {

            targets = new List<ITargetable>()
            {
                hub.GetComponent<HubBehavior>(),
                player.GetComponent<PlayerController>()
            };

            var torchSpawner = player.GetComponentInChildren(typeof(ITorchSpawner)) as ITorchSpawner;
            torchSpawner.AddListener(this);
        }

    }
}
