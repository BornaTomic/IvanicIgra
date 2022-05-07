using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Doors : MonoBehaviour
{
    GameObject doorTrigger;
    // Start is called before the first frame update
    void Start()
    {
        doorTrigger = GameObject.Find("DoorTrigger");
        doorTrigger.transform.position = gameObject.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
