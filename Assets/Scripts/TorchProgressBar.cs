using Assets.Scripts;

public class TorchProgressBar : ProgressBar
{
    TorchBehavior torch;
    
    void Start()
    {
        torch = player.GetComponentInChildren<TorchBehavior>();

        current = torch.GetRemainingFuel();
        max = torch.GetMaxFuel();
        scaleDirection = ScaleDirection.X;
    }

    void Update()
    {
        UpdateCurrent(torch.GetRemainingFuel());
    }
}
