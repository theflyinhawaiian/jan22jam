using Assets.Scripts;
using UnityEngine;

public class CooldownProgressBar : ProgressBar
{
    protected IItemWithCooldown item;

    protected void UpdateBar()
    {
        var lastUse = item.GetLastUseTime();
        var cooldown = item.GetCooldown();

        var cooldownPct = Mathf.Clamp((Time.time - lastUse) / cooldown, 0, 1f);

        UpdateCurrent(cooldownPct);
    }
}
