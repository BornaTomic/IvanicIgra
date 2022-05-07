using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    public bool[] isFull;
    public GameObject[] slots;
    // Start is called before the first frame update
    void Start()
    {
        slots[0] = GameObject.Find("Slot (1)");
        slots[1] = GameObject.Find("Slot (2)");
        slots[2] = GameObject.Find("Slot (3)");
        slots[3] = GameObject.Find("Slot (4)");
        slots[4] = GameObject.Find("Slot (5)");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
