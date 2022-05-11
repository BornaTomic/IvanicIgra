using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Sword : MonoBehaviour
{
    SpriteRenderer sr;
    GameObject player;
    GameObject swordObj;
    public Material Defuser;
    public Material Defult;
    Renderer rend;
    // Start is called before the first frame update
    void Start()
    {
        sr = GetComponent<SpriteRenderer>();
        player = GameObject.FindGameObjectWithTag("Player");
        swordObj = GameObject.Find("SwordObj");
        rend = GetComponent<Renderer>();
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
        if (SceneManager.GetActiveScene().name == "PrviLvl" || SceneManager.GetActiveScene().name == "Zadnja NPC scena")
        {
            rend.material = Defult;
        }
        else
        {
            rend.material = Defuser;
        }
    }
}
