using UnityEngine;
using Assets.Scripts;

public class GunBehavior : MonoBehaviour, IItemWithCooldown
{
    public GameObject prefab;
    public float emitForce = 20f;

    public float lastUseTime = -1000;
    public float cooldown = 0.1f;

    public void FireBullet()
    {
        if (lastUseTime + cooldown > Time.time)
            return;

        GameObject p = Instantiate(prefab, transform.position, transform.rotation);
        Rigidbody2D prb2d = p.GetComponent<Rigidbody2D>();
        prb2d.AddForce(transform.up * emitForce, ForceMode2D.Impulse);
        lastUseTime = Time.time;
    }

    public float GetLastUseTime() => lastUseTime;

    public float GetCooldown() => cooldown;
}
