using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Core.Pool;

public class ItemControlelr : MonoBehaviour
{
     void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            SmartPool.Instance.Despawn(this.gameObject);
        }
    }
}
