using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyController : MonoBehaviour
{
    public float speed;
    public GameObject gun;
    public GameObject transhoot;
    public GameObject bullet;
    public GameObject Player;

    public float timedelay;
    public float timeBullet;

    public int count;
    public GameObject USung;

    void Start()
    {
        timedelay = timeBullet;
    }
    void Update()
    { 
        Movement();
        fireBullet();
    }
    void fireBullet()
    {
        timedelay -= Time.deltaTime;
        if (timedelay <= 0)
        {
            Instantiate(bullet, transform.position, transhoot.transform.rotation);
            timedelay = timeBullet;
            Debug.Log(speed + "/enemy dung lai");
            speed = 0;
            Invoke("StopMoverment", 5f);
        }

    }

    void Movement()
    {
        Vector3 direction = Player.transform.position;
        var gunDirection = direction - transform.position;
        if (gunDirection != Vector3.zero)
        {
            this.gameObject.transform.up = gunDirection;
        }
        this.gameObject.transform.position += gunDirection * Time.deltaTime * speed;

        gun.transform.up = gunDirection;
    }
    void OnTriggerEnter2D(Collider2D collision) // collision : th va cham voi minh
    {
        if (collision.transform.tag == "bullet")
            count++;
        if (count == 10)
        {
            Destroy(this.gameObject);
            Instantiate(USung, transform.position, transform.rotation);
        }
    }

    void StopMoverment()
    {
        speed = 1;
    }
}

