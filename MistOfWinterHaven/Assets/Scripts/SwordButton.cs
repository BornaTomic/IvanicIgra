using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwordButton : MonoBehaviour
{
    public GameObject sword;
    public GameObject border;
    GameObject player;
    GameObject canvas1;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        canvas1 = GameObject.FindGameObjectWithTag("Kanvas");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void GetSword()
    {
        var obj = Instantiate(sword, new Vector3(player.transform.position.x, player.transform.position.y, 0), Quaternion.identity) as GameObject;
        var obj2 = Instantiate(border, new Vector3(transform.position.x, transform.position.y, 0), Quaternion.identity) as GameObject;
        obj.transform.parent = player.transform;
        obj2.transform.parent = canvas1.transform;
    }
}
