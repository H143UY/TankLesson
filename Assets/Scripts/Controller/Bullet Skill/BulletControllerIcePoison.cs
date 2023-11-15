using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletControllerIcePoison : BulletController , iceSkill, poisonSkill
{
    public GameObject preIce;
    public GameObject prePoison;
    public float Timer = 0;
    public bool PoisonCheck = false;
    public int Count;
    public EnemyController enemycontroller;
    public void EffecIceBounDing(GameObject oppoment)
    {
        var affec = oppoment.GetComponent<MoveController>();
        if(affec != null)
        {
            return;
        }
        speed = 0;
    }

    public void EffectPoisonBouding(GameObject opponent)
    {
        enemycontroller = opponent.GetComponent<EnemyController>(); 
    }

    public float ICe(int dameff)
    {
        Debug.Log("tang dame");
        return dameff;
    }
    public override void Update()
    {
        base.Update();
        if (PoisonCheck == true)
        {
            Timer += Time.deltaTime;
            if (Timer >= 1)
            {
                Debug.Log("hp da tru" + enemycontroller.hp);
                enemycontroller.hp -= 1;
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
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Enemy")
        {
            PoisonCheck = true;
            damage += ICe(5);
            EffecIceBounDing(collision.gameObject);
            EffectPoisonBouding(collision.gameObject);  
            Instantiate(preIce, transform.position, transform.rotation);
            Instantiate(prePoison, transform.position, transform.rotation); 
        }
    }
}
