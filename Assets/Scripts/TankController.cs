using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankController : MonoBehaviour
{
    public float speed;
    public GameObject bodyTank;
    public GameObject gun;
    public GameObject gunBehind;
    public GameObject bullet; 
    public GameObject bulletbehind;
    public GameObject transhoot;
    public GameObject transhootbehind;
    public GameObject transhoot2;
    void Update()
    {
        Ban_dan();
        Movement();
        FireBullet();
    }
    void Movement()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");
        Vector3 direction = new Vector3(horizontal, vertical);

        if (direction != Vector3.zero)
        {
            this.gameObject.transform.up = direction;
        }
        this.gameObject.transform.position += direction * speed * Time.deltaTime;
        Vector3 gunDirection = new Vector3(
             Input.mousePosition.x - Screen.width / 2,
             Input.mousePosition.y - Screen.height / 2
            );
        gun.transform.up = gunDirection;
        gunBehind.transform.up = gunDirection;
    }
    void Ban_dan()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Instantiate(bullet, transhoot.transform.position, transhoot.transform.rotation);
            Instantiate(bullet, transhoot2.transform.position, transhoot2.transform.rotation);
        }
    }
    void FireBullet()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Instantiate(bulletbehind, transhootbehind.transform.position, transhootbehind.transform.rotation);
        }
    }
}
