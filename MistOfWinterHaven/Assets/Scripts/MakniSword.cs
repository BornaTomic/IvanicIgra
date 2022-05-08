using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MakniSword : MonoBehaviour
{
    GameObject sword;
    // Start is called before the first frame update
    void Start()
    {
        sword = GameObject.FindGameObjectWithTag("Sword");
    }

    // Update is called once per frame
    void Update()
    {

    }
    public void RemoveSword()
    {
        SwordButton.isSword = false;
        Destroy(sword);
        Destroy(gameObject);
    }
}
