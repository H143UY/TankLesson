using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletControllerFireThunder : BulletController, fireSkill, thunderSkill
{
    public GameObject preThunder;
    public GameObject preFire;
    public float FireTime;
    public bool FireLoad = false;
    public int CountFire;
    public EnemyController enemyController;
    public void EffecFireBounding(GameObject oppomentFire)
    {
        enemyController = oppomentFire.GetComponent<EnemyController>();
    }
    public void EffectThunderBounding(GameObject opponent)
    {
        var effect = opponent.GetComponent<MoveController>(); //opponent = enemy
        if (effect != null)
        {
            return;
        }
        effect.speed += 5;
    }
    public override void Update()
    {
        base.Update();
        if (FireLoad == true && enemyController != null)
        {
            FireTime += Time.deltaTime;
            if (FireTime >= 5)
            {
                enemyController.hp -= 1;
                Debug.Log("hp đã trừ 1" + enemyController.hp);
                CountFire += 1;
                FireTime = 0;
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
        base.BulletEx();
        if (time == 50)
        {
            Instantiate(preThunder, transform.position, transform.rotation);
            Instantiate(preFire, transform.position, transform.rotation);
        }
    }
   
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            FireLoad = true;
            this.PostEvent(EventID.ThunderEnemy);
            Instantiate(preThunder, transform.position, transform.rotation);
            Instantiate(preFire, transform.position, transform.rotation);
            EffectThunderBounding(collision.gameObject);
            EffecFireBounding(collision.gameObject);
        }
    }
}
