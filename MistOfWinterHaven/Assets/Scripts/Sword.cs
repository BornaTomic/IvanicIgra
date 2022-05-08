using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sword : MonoBehaviour
{
    SpriteRenderer sr;
    bool isRight = true;
    GameObject player;
    float moveX;
    float moveY;
    // Start is called before the first frame update
    void Start()
    {
        sr = GetComponent<SpriteRenderer>();
        player = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        moveX = player.transform.position.x;
        moveY = player.transform.position.y;
        if (Player.pov == POV.desno || Player.pov == POV.gore)
        {
            sr.flipX = false;
            if (isRight)
            {
                gameObject.transform.position = new Vector3(moveX + 0.7f, moveY, 0);
                isRight = false;
            }
        }
        if(Player.pov == POV.lijevo || Player.pov == POV.dolje)
        {
            sr.flipX = true;
            if (!isRight)
            {
                gameObject.transform.position = new Vector3(moveX -0.7f, moveY, 0);
                isRight = true;
            }
        }
    }
}
