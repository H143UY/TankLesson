﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bulletcontroller2 : MonoBehaviour
{
    public float speed = 5;
    private float time = 0;
    public GameObject bum;


    void Update()
    {
        if (time == 300)
        {
            Destroy(this.gameObject);
            Instantiate(bum, this.transform.position, this.transform.rotation);
        }
        time++;
        this.transform.position += transform.up * Time.deltaTime * speed;
    }
}
