using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public Image fill;
    public GameObject player;

    TorchBehavior torch;
    
    void Start()
    {
        torch = player.GetComponentInChildren<TorchBehavior>();
    }

    void Update()
    {
        var scale = fill.transform.localScale;
        var xScale = torch.GetRemainingFuel() / torch.GetMaxFuel();

        var newScale = new Vector3(xScale, scale.y, scale.z);

        fill.transform.localScale = newScale;
    }
}
