using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSpawn : MonoBehaviour
{
    GameObject player;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player");
        player.transform.position = new Vector3(gameObject.transform.position.x, gameObject.transform.position.y, 0);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
