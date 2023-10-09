using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunController : MonoBehaviour
{
    public GameObject dan;
    public GameObject transhoot1;
    public GameObject transhoot2;
    public GameObject transhoot3;
    public GameObject transhoot4;
    private void Update()
    {
        this.gameObject.transform.Rotate(0, 0, 10);
        Instantiate(dan, transhoot1.transform.position, transhoot1.transform.rotation);
        Instantiate(dan, transhoot2.transform.position, transhoot2.transform.rotation);
        Instantiate(dan, transhoot3.transform.position, transhoot3.transform.rotation);
        Instantiate(dan, transhoot4.transform.position, transhoot4.transform.rotation);
    }
    
}
