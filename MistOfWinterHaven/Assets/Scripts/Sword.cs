using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sword : MonoBehaviour
{
    SpriteRenderer sr;
    GameObject player;
    GameObject swordObj;
    // Start is called before the first frame update
    void Start()
    {
        sr = GetComponent<SpriteRenderer>();
        player = GameObject.FindGameObjectWithTag("Player");
        swordObj = GameObject.Find("SwordObj");
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyBindsManager.dictionary["MoveRight"]) || Input.GetKeyDown(KeyBindsManager.dictionary["MoveUp"]))
        {
            gameObject.transform.position = new Vector3(swordObj.transform.position.x + 0.375f, swordObj.transform.position.y + 0.393f);
            sr.flipX = false;
        }
        if(Input.GetKeyDown(KeyBindsManager.dictionary["MoveLeft"]) || Input.GetKeyDown(KeyBindsManager.dictionary["MoveDown"]))
        {
            gameObject.transform.position = new Vector3(swordObj.transform.position.x - 0.375f, swordObj.transform.position.y + 0.393f);
            sr.flipX = true;
        }
    }
}
