using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class BossBar : MonoBehaviour
{
    public Slider slider;
    public GameObject Boss;
    public float MaxHealth;
    public float Health;
    private void Start()
    {
        Boss = GameObject.FindGameObjectWithTag("Boss");
    }
    public void Update()
    {
        MaxHealth = Boss.GetComponent<MainBoss>().MaxHp;
        Health = Boss.GetComponent<MainBoss>().Hp;

        slider.maxValue = MaxHealth;
        slider.value = Health;
    }
}
