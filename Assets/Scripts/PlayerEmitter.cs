using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerEmitter : MonoBehaviour
{
    public GameObject prefab;
    public float emitForce = 20f;


    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("space"))
        {
            GameObject p = Instantiate(prefab, transform.position, transform.rotation);
            Rigidbody2D prb2d = p.GetComponent<Rigidbody2D>();
            prb2d.AddForce(transform.up * emitForce, ForceMode2D.Impulse);
        }
    }
}
