using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices.ComTypes;
using UnityEngine;

public class BulletControllerIceFIre : BulletController, iceSkill, fireSkill
{
    public GameObject preIce;
    public GameObject preFire;
    public EnemyController enemyController;
    public float FireTime;
    public bool FireLoad = false;
    public int CountFire;
    public void EffecFireBounding(GameObject oppoment)
    {
        var affected = oppoment.GetComponent<MoveController>();
        if (affected != null)
        {
            return;
        }
        affected.speed = 0;
    }

    public void EffecIceBounDing(GameObject oppomentFire)
    {
        enemyController = oppomentFire.GetComponent<EnemyController>();
    }
    public float ICe(int dameff)
    {
        Debug.Log("tang dame");
        return dameff;
    }

    public override void Update()
    {
        base.Update();
        if (FireLoad == true && enemyController != null)
        {
            FireTime += Time.deltaTime;
            if (FireTime >= 5)
            {
                Debug.Log("hp da tru" + enemyController.hp);
                enemyController.hp -= 1;
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
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            damage += ICe(25);
            Instantiate(preIce, transform.position, transform.rotation);
            Instantiate(preFire, transform.position, transform.rotation);
            FireLoad = true;
            EffecFireBounding(collision.gameObject);
            EffecIceBounDing(collision.gameObject);
        }
    }
}


