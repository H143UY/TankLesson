using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletController : MonoBehaviour
{
    public float speed = 6;
    private float time = 0;

    void Update()
    {
        if(time == 800)
        {
            Destroy(this.gameObject);
        }
        time++;
        this.transform.position += transform.up * Time.deltaTime * speed; 
    }
}
