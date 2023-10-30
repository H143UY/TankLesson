using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Core.Pool;
public class SmokeController : MonoBehaviour
{
    public void DestroySmoke()
    {
        SmartPool.Instance.Despawn(this.gameObject);
    }
}
