using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices.ComTypes;
using UnityEngine;

public class BulletControllerFIREPOISON : BulletController, poisonSkill, fireSkill
{
    public GameObject prebPoison;
    public GameObject prebFire;
    public EnemyController enemyController;
    public float FireTime;
    public bool FireLoad = false;
    public int CountFire;

    public float Timer = 0;
    public bool PoisonCheck = false;
    public int Count;
    public void EffecFireBounding(GameObject oppomentFire)
    {
        enemyController = oppomentFire.GetComponent<EnemyController>();
    }

    public void EffectPoisonBouding(GameObject opponent)
    {
        enemyController = opponent.GetComponent<EnemyController>(); //opponent là va chạm với enemy ở hàm ontrigger, check xem có script enemy controller được gắn ko
    }


    public override void Update()
    {
        base.Update();
        if (FireLoad == true && enemyController != null)// chỗ này là check nó này, nếu khác null thì mới xử lý 
        {
            FireTime += Time.deltaTime;
            if (FireTime >= 5)
            {
                enemyController.hp -= 1;
                Debug.Log("hp đã trừ (fire):" + enemyController.hp);
                CountFire += 1;
                FireTime = 0;
            }
            else if (Count == 10)
            {
                Count = 0;
                PoisonCheck = false;
            }
        }
        //hieu ung doc
        if (PoisonCheck == true && enemyController != null)
        {
            Timer += Time.deltaTime;
            if (Timer >= 1)
            {
                enemyController.hp -= 1;
                Count += 1;
                Timer = 0;
                Debug.Log("hp đã trừ (doc):" + enemyController.hp);
            }
            else if (CountFire == 4)
            {
                CountFire = 0;
                FireLoad = false;
                return;
            }
        }        
    }
    protected override void BulletEx()
    {
        if (time == 500)
        {
            Instantiate(prebFire, transform.position, transform.rotation);
            Instantiate(prebPoison, transform.position, transform.rotation);
        }
        base.BulletEx();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            Instantiate(prebPoison, transform.position, transform.rotation);
            Instantiate(prebFire, transform.position, transform.rotation);
            FireLoad = true;
            PoisonCheck = true;
            EffecFireBounding(collision.gameObject);
            EffectPoisonBouding(collision.gameObject);
        }
    }
}
