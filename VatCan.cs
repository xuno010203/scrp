using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VatCan : MonoBehaviour
{
    protected virtual void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "box")
        {
            Destroy(gameObject);
        }
    }
}
