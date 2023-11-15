using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletControllerFire : BulletController, fireSkill
{
    public GameObject prebFire;
    public float FireTime;
    public bool FireLoad = false;
    public int CountFire;
    public float Timer = 0;
    public bool PoisonCheck = false;
    public int Count;

    public EnemyController enemyController;
    public void EffecFireBounding(GameObject oppomentFire)// cả cái hàm này nó chỉ đc gọi 1 lần khi em bắn trúng enemy nên k check time ở đây đc
    {
        enemyController = oppomentFire.GetComponent<EnemyController>(); // vì em dùng nó ở dưới hàm update, nên phải tạo biến ở ngoài và gán giá trị cho nó
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
    }
    protected override void BulletEx()
    {
        if(time == 100)
        {
            Instantiate(prebFire, transform.position, transform.rotation);
        }
        base.BulletEx();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            Instantiate(prebFire, transform.position, transform.rotation);
            FireLoad = true;
            EffecFireBounding(collision.gameObject);

        }
    }
}


