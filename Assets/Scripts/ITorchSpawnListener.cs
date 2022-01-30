namespace Assets.Scripts
{
    public interface ITorchSpawnListener
    {
        void OnTorchSpawned(ITargetable torch);

        void OnTorchDestroyed(ITargetable torch);
    }
}
