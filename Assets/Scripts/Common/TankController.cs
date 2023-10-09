using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankController : MoveController
{
    public Transform bodyTank;
    public Transform gun;
    public GameObject bullet;
    public Transform transhoot;
    protected override void Move(Vector3 direction)
    {
        if (direction != Vector3.zero)
        {
            bodyTank.up = direction;
        }
        base.Move(direction);
    }
    protected void RotateGun(Vector3 direction)
    {
        gun.up = direction;
    }
    public void Shoot()
    {
        Instantiate(bullet, transhoot.transform.position, transhoot.transform.rotation);
    }
   /* protected virtual void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("bbbbb");

        if (collision.gameObject.tag == "dan")
        {
            Destroy(gameObject);

        }
    }*/
}