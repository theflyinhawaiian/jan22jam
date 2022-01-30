using UnityEngine;

public class UIManager : MonoBehaviour
{
    public GameObject player;

    private PlayerController controller;
    void Start()
    {
        controller = player.GetComponent<PlayerController>();
    }

    void Update()
    {
        var itemWindows = GetComponentsInChildren<SelectableItemBehavior>();
        foreach(var window in itemWindows)
        {
            if (window.representedItem != controller.GetSelectedItem())
                window.Deselect();
            else
                window.Select();
        }
    }
}
