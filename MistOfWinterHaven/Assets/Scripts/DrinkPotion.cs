using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DrinkPotion : MonoBehaviour
{
    public float Pressentage;
    private void Update()
    {
        if (!GameManager.isInGame)
        {
            Destroy(gameObject);
        }
    }
    public void Click()
    {
        GameManager.instance.CurrentHEalth = GameManager.instance.CurrentHEalth + (Pressentage / 100) * GameManager.instance.MaxHealth;
        Destroy(gameObject);
    }
}
