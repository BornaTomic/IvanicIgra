using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    public Slider slider;
    public float MaxHealth;
    public float Health;
    public void Update()
    {
        MaxHealth = GameManager.instance.MaxHealth;
        Health = GameManager.instance.CurrentHEalth;

        slider.maxValue = MaxHealth;
        slider.value = Health;
    }
}
