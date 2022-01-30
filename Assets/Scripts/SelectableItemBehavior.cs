using UnityEngine;
using UnityEngine.UI;
using Assets.Scripts;

public class SelectableItemBehavior : MonoBehaviour
{
    public PlayerItem representedItem;
    
    protected Image border;

    private void Start()
    {
        border = GetComponent<Image>();
    }

    public void Select() =>
        border.color = Color.yellow;

    public void Deselect() =>
        border.color = Color.white;
}
