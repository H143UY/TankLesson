using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Core.Pool;
public class BulletController : MoveController
{
    private float time = 0;
    public GameObject smoke;
    public float damage;
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
            SmartPool.Instance.Despawn(this.gameObject);
            SmartPool.Instance.Spawn(smoke.gameObject,transform.position,transform.rotation);
        }
        time++;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag != this.gameObject.transform.tag)
        {
            Destroy(this.gameObject);
        }
    }
    public void Bonusdame()
    {
        damage += 5;
    }
}
