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
    void Update()
    {
        var direction = PlayerController.instance.transform.position - this.gameObject.transform.position;
        Move(direction);
        RotateGun(direction);
        time++;
        if (time == 100)
        {
            CreateBullet();
            time = 0;
        }

        if (direction.magnitude < 10f)
        {
            Debug.Log("aaaaaa");
            speed = 0f;
        }
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
            if(randomNumber  < percent ) 
            {
                int randomIndex = Random.Range(0, randomItem.Length);
                GameObject Item = randomItem[randomIndex];
                SmartPool.Instance.Spawn(Item.gameObject, transform.position, transform.rotation);
            }            
            SmartPool.Instance.Despawn(this.gameObject);           
            this.PostEvent(EventID.EnemyDestroy);
        }
    }
    //public void Uplevel()
    //{
    //    levelEnemy += 1;
    //    speed += 5;
    //    //bullet.Bonusdame();
    //}
}
