using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyController : MonoBehaviour
{
    public void DestroySmoker()
    {
        Destroy(this.gameObject);
    }
}
