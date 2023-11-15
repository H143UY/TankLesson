    using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Core.Pool;
public class BulletController : MoveController
{
    public float time = 0;
    //public GameObject smoke;
    public float damage;
    public virtual void Update()
    {
        this.transform.position += transform.up * Time.deltaTime * speed;
        Move(this.transform.up);
        BulletEx();
    }
    protected virtual void BulletEx()
    {
        if (time == 500)
        {
            SmartPool.Instance.Despawn(this.gameObject);
            //Instantiate(smoke,transform.position,transform.rotation);
        }
        time++;
    }
    //private void OnTriggerEnter2D(Collider2D collision)
    //{
    //    if (collision.gameObject.tag != this.gameObject.transform.tag)
    //    {
    //        Destroy(this.gameObject);
    //    }
    //}

    public void Bonusdame()
    {
        damage += 5;
    }
}
