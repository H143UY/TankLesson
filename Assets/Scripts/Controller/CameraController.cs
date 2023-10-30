using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : SingletonMono<CameraController>
{
  
    void Update()
    {
        Transform Tank = PlayerController.instance.transform;
        Vector3 newPos = new Vector3(Tank.position.x, Tank.position.y, -10f);
        transform.position = Vector3.Lerp(transform.position,newPos,0.3f);
    }
}
