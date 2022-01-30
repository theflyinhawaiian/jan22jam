namespace Assets.Scripts
{
    class PlaceTorchCooldownBar : CooldownProgressBar
    {
        private void Start()
        {
            item = player.GetComponentInChildren<TorchPlacementBehavior>();
            max = 1f;
            current = item.GetLastUseTime() / item.GetLastUseTime();
            scaleDirection = ScaleDirection.Y;
        }

        private void Update()
        {
            UpdateBar();
        }
    }
}
