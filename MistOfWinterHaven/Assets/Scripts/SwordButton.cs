using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwordButton : MonoBehaviour
{
    GameObject sword;
    GameObject border;
    public bool isSword = false;
    // Start is called before the first frame update
    void Start()
    {
        border = GameObject.FindGameObjectWithTag("Border");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void GetSword()
    {
        sword.GetComponent<SpriteRenderer>().sortingLayerID = 3;
        border.SetActive(true);
        isSword = true;
    }
    public void RemoveSword()
    {
        sword.GetComponent<SpriteRenderer>().sortingLayerID = 0;
        border.SetActive(false);
        isSword = false;
    }
}
