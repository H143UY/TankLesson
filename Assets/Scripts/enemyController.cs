using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyController : MonoBehaviour
{
    public int speed;
    public GameObject gun;
    public GameObject transhoot;
    public GameObject bullet;
    public GameObject Player;
    void Start()
    {
        
    }
    void Update()
    {
        Vector3 direction = Player.transform.position;
        var gunDirection = direction - transform.position;
        if(gunDirection != Vector3.zero)
        {
            this.gameObject.transform.up = gunDirection;
        }
        this.gameObject.transform.position += gunDirection * Time.deltaTime * speed;

        gun.transform.up = gunDirection;
        if(Random.Range(0, 100) % 50 == 0 )
            Instantiate(bullet,transform.position,transhoot.transform.rotation);
        }
    private void OnTriggerEnter2D(Collider2D collision) // collision : th va cham voi minh
    {
        if(collision.transform.tag == "bullet") 
        {
            Destroy(this.gameObject);
        }
    }
}

