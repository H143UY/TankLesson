using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletControllerPoison : BulletController, poisonSkill
{
    public GameObject prebPoison;
    public EnemyController enemyController;
    public float Timer = 0;
    public bool PoisonCheck = false;
    public int Count;
    public void EffectPoisonBouding(GameObject opponent)
    {
        enemyController = opponent.GetComponent<EnemyController>();
    }
    public override void Update()
    {
        base.Update();
        if (PoisonCheck == true)
        {
            Timer += Time.deltaTime;
            if (Timer >= 1)
            {
                enemyController.hp -= 1;
                Count += 1;
                Timer = 0;
            }
            else if (Count == 10)
            {
                Count = 0;
                PoisonCheck = false;
            }
        }
    }
    protected override void BulletEx()
    {
        base.BulletEx();
        if(time==100)
        {
            Instantiate(prebPoison, transform.position, transform.rotation);
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            Instantiate(prebPoison, transform.position, transform.rotation);
            PoisonCheck = true;
            EffectPoisonBouding(collision.gameObject);
        }
    }
}
