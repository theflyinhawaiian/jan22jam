using UnityEngine;

public class GunBehavior : MonoBehaviour
{
    public GameObject prefab;
    public float emitForce = 20f;

    public void FireBullet()
    {
        GameObject p = Instantiate(prefab, transform.position, transform.rotation);
        Rigidbody2D prb2d = p.GetComponent<Rigidbody2D>();
        prb2d.AddForce(transform.up * emitForce, ForceMode2D.Impulse);
    }
}
