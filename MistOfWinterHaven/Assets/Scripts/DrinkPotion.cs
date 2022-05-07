using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DrinkPotion : MonoBehaviour
{
    public float Pressentage;
    public void Click()
    {
        GameManager.instance.CurrentHEalth = GameManager.instance.CurrentHEalth + (Pressentage / 100) * GameManager.instance.MaxHealth; 
    }
}
