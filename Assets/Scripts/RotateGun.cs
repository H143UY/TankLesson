using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateGun : MonoBehaviour
{
    public GameObject bullet;
    public GameObject transhot1;
    public GameObject transhot2;
    public GameObject transhot3;
    public GameObject transhot4;
    void Update()
    {
        this.gameObject.transform.Rotate(0, 0, 5);
        Instantiate(bullet, transhot1.transform.position, transhot1.transform.rotation);
        Instantiate(bullet, transhot2.transform.position, transhot2.transform.rotation);
        Instantiate(bullet, transhot3.transform.position, transhot3.transform.rotation);
        Instantiate(bullet, transhot4.transform.position, transhot4.transform.rotation);
        
    }
}
