namespace Assets.Scripts
{
    class GunCooldownBar : CooldownProgressBar
    {
        private void Start()
        {
            item = player.GetComponentInChildren<GunBehavior>();
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
