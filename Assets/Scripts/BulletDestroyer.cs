using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletDestroyer : MonoBehaviour
{
    //public float BulletTime = 0f;
    
    // Start is called before the first frame update
    void Start()
    {
        Destroy(gameObject, 1);
    }

   
}
