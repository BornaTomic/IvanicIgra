using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DrinkPotion : MonoBehaviour
{
    public float Pressentage;
    GameObject gameManager;
    private void Update()
    {
        
    }
    public void Click()
    {
        GameManager.instance.CurrentHEalth = GameManager.instance.CurrentHEalth + (Pressentage / 100) * GameManager.instance.MaxHealth;
        Destroy(gameObject);
    }
}
