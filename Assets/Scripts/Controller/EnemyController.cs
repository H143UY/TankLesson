using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : TankController
{

    public float time;
    public GameObject gunEmplace;

    void Update()
    {
        var direction = PlayerController.instance.transform.position - this.gameObject.transform.position;
        Move(direction);
        RotateGun(direction);
        time++;
        if (time == 100)
        {
            Shoot();
            time = 0;
        }

       

    }
    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "danPlayer")
        {
            Destroy(gameObject);
            GameManager.instance.addScore();
            float RandomX = Random.Range(0, 100);
            float RandomY = Random.Range(0, 100);
            Vector3 randomRange = new Vector3(RandomX, RandomY, 0);
            GameManager.instance.Create(randomRange);
        }
    }

   
}
