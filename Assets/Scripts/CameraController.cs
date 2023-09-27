using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public GameObject Tank;
    void Update()
    {
        Transform tank = Tank.transform;
        Vector3 newPos = new Vector3(tank.position.x, tank.position.y, -10f);
        transform.position = Vector3.Lerp(transform.position, newPos, 0.3f); // điểm đầu, điểm cuối, tốc độ
    }
}
