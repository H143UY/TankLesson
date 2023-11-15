using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBarController : MonoBehaviour
{
    public Slider sliderHealth;
    public void SetMaxHealth(float health)
    {
        sliderHealth.maxValue = health;
        sliderHealth.value = health; // bắt đầu ở lượng máu tối đa
    }
    public void SetHealth(float Health)
    {
        sliderHealth.value = Health;
    }
}
