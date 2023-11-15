using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletControllerIce : BulletController , iceSkill
{
    public GameObject prebIce;
    public void EffecIceBounDing(GameObject oppoment)
    {
        var affected = oppoment.GetComponent<MoveController>();
        if (affected != null)
        {
            return;
        }
        affected.speed = 0;
    }

    public float ICe(int dameff)
    {
        throw new System.NotImplementedException();
    }
    public float Ice(int dameff)
    {
        return dameff;
    }
    protected override void BulletEx()
    {
        if (time == 100)
        {
            Instantiate(prebIce, this.gameObject.transform.position, this.gameObject.transform.rotation);
        }
        base.BulletEx();
    }

    protected virtual void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            Instantiate(prebIce, this.gameObject.transform.position, this.gameObject.transform.rotation);   
            damage += Ice(25);
            EffecIceBounDing(collision.gameObject);
        }
    }
}
