using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TorchButton : MonoBehaviour
{
    public GameObject torch;
    public GameObject border1;
    GameObject player;
    GameObject canvas1;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        canvas1 = GameObject.FindGameObjectWithTag("Kanvas2");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void GetTorch()
    {
        var obje = Instantiate(torch, new Vector3(player.transform.position.x, player.transform.position.y, 0), Quaternion.identity) as GameObject;
        var obje2 = Instantiate(border1, new Vector3(transform.position.x, transform.position.y, 0), Quaternion.identity) as GameObject;
        obje.transform.parent = player.transform;
        obje2.transform.parent = canvas1.transform;
    }
}
