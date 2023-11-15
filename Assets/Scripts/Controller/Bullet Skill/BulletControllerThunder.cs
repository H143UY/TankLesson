using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletControllerThunder : BulletController, thunderSkill
{
    public GameObject preThunder;
    public EnemyController enemyController;
    public void EffectThunderBounding(GameObject opponent)
    {
        var effect = opponent.GetComponent<MoveController>(); //opponent = enemy
        if (effect != null)
        {
            return;
        }
     

        Debug.Log(speed);
    }
    public override void Update()
    {
        base.Update();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            Instantiate(preThunder, transform.position, transform.rotation);
            EffectThunderBounding(collision.gameObject);
            this.PostEvent(EventID.ThunderEnemy);
            //enemyController.ThunderBullet = true;
        }
    }
}
