namespace Assets.Scripts
{
    public interface ITorchSpawner
    {
        void AddListener(ITorchSpawnListener listener);

        void RemoveListener(ITorchSpawnListener listener);

        void ClearListeners();
    }
}
