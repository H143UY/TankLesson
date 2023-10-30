using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Core.Pool;
public class TankController : MoveController
{
    public Transform bodyTank;
    public Transform gun;
    public Transform gun2; // súng đằng sau
    public BulletController bullet;
    public Transform transhoot;
    public Transform transhoot2; // item 1
    public float hp;
    
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
        gun2.up = direction;
    }

    public void CreateBullet()
    {
        SmartPool.Instance.Spawn(bullet.gameObject, transhoot.transform.position, transhoot.rotation);
    }
    public virtual void CalculateHP(float value)
    {
        hp += value;
    }
}