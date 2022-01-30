using Assets.Scripts;
using UnityEngine;
using UnityEngine.UI;

public class ProgressBar : MonoBehaviour
{
    protected float current = 1f;
    protected float max = 1f;
    protected ScaleDirection scaleDirection;

    public Image fill;
    public GameObject player;

    protected void UpdateCurrent(float current)
    {
        this.current = current;

        var scale = fill.transform.localScale;
        var newValue = current / max;

        Vector3 newScale;

        switch (scaleDirection)
        {
            case ScaleDirection.Y:
                newScale = new Vector3(scale.x, newValue, scale.z);
                break;
            case ScaleDirection.X:
            default:
                newScale = new Vector3(newValue, scale.y, scale.z);
                break;
        }

        fill.transform.localScale = newScale;
    }
}
