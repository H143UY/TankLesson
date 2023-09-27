using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletController : MonoBehaviour
{
    public float speed = 6;
    private float time = 0;
    public GameObject bum;

    void Update()
    {
        if (time == 400)
        {
            Destroy(this.gameObject);
            Instantiate(bum, this.transform.position, this.transform.rotation);
        }
        time++;
        this.transform.position += transform.up * Time.deltaTime * speed;
    }
}
