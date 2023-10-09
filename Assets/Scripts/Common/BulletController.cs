using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletController : MoveController
{
    private float time = 0;
    public GameObject smoke;
    void Update()
    {
        this.transform.position += transform.up * Time.deltaTime * speed;
        Move(this.transform.up);
        BulletEx();
    }
    protected virtual void BulletEx()
    {
        if(time == 100)
        {
            Destroy(this.gameObject);
            Instantiate(smoke,this.gameObject.transform.position, this.gameObject.transform.rotation);
        }
        time++;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag != this.gameObject.transform.tag ) 
        {
            Destroy(this.gameObject);
        }
    }
}
