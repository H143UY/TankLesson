using Core.Pool;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Core.Pool;
using UniRx.Examples;

public class EnemyController : TankController
{
    public GameObject[] randomItem;
    public float time;
    private int Count;
    //public int levelEnemy;
    public int percent;
    public float TimeThunder;

    public bool ThunderBullet = false;

    private void Awake()
    {
        this.RegisterListener(EventID.ThunderEnemy, (sender, param) =>
        {
            ThunderBullet = true;
        });
    }
    void Update()
    {
        var direction = PlayerController.instance.transform.position - this.gameObject.transform.position;
        if (ThunderBullet == false)
        {
            Move(direction);
            RotateGun(direction);
        }
        else if (ThunderBullet == true)
        {
            RandomDirection();
            TimeThunder += Time.deltaTime;
            if (TimeThunder >= 20)
            {
                TimeThunder = 0;
                ThunderBullet = false;
            }
        }

        time++;
        if (time == 100)
        {
            CreateBullet();
            time = 0;
        }
        //if (direction.magnitude < 10f)
        //{
        //    speed -= 2f;
        //}
    }
    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "danPlayer")
        {
            var dame = collision.gameObject.GetComponent<BulletController>().damage;
            CalculateHP(-dame);

        }
    }
    public override void CalculateHP(float value)
    {
        base.CalculateHP(value);
        if (hp <= 0)
        {
            var randomNumber = Random.Range(0, 100);
            if (randomNumber < percent)
            {
                int randomIndex = Random.Range(0, randomItem.Length);
                GameObject Item = randomItem[randomIndex];
                SmartPool.Instance.Spawn(Item.gameObject, transform.position, transform.rotation);
            }
            SmartPool.Instance.Despawn(this.gameObject);
            this.PostEvent(EventID.EnemyDestroy);
            hp = 200; //set lại hp sau khi destroy
        }
    }
    //public void Uplevel()
    //{
    //    levelEnemy += 1;
    //    speed += 5;
    //    //bullet.Bonusdame();
    //}
    public void RandomDirection()
    {
        float Randomx = this.gameObject.transform.position.x;
        float Randomy = this.gameObject.transform.position.y;
        float RandomPos = Random.Range(0,10);
        Vector3 randomDr = new Vector3(RandomPos+Randomx, Randomy+RandomPos);
        Move(randomDr);
        RotateGun(randomDr);
    }//ramdom vị trí di chuyển sau khi ăn bullet thunder

}

