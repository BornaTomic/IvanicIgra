using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwordObj : MonoBehaviour
{
    bool attacking = false;
    Animator animator;
    bool isRight = true;
    GameObject player;
    float moveX;
    float moveY;
    private float timeToAttack = 0.03f;
    private float timer = 0f;
    public GameObject attckUp, attckDown, attckRight, attckLeft;
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        player = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        moveX = player.transform.position.x;
        moveY = player.transform.position.y;
        if (Player.pov == POV.desno || Player.pov == POV.gore)
        {
            if (isRight)
            {
                gameObject.transform.position = new Vector3(moveX + 0.38f, moveY - 0.447f, 0);
                isRight = false;
            }
        }
        if (Player.pov == POV.lijevo || Player.pov == POV.dolje)
        {
            if (!isRight)
            {
                gameObject.transform.position = new Vector3(moveX - 0.38f, moveY - 0.447f, 0);
                isRight = true;
            }
        }
        if (Input.GetKeyDown(KeyCode.Q))
        {
            attacking = true;
        }
        if (attacking)
        {
            if (Player.pov == POV.desno || Player.pov == POV.gore)
            {
                animator.SetInteger("Sword", 1);
            }
            if (Player.pov == POV.lijevo || Player.pov == POV.dolje)
            {
                animator.SetInteger("Sword", 2);
            }
            if (Player.pov == POV.gore)
            {
                attckUp.SetActive(true);
            }
            else if (Player.pov == POV.dolje)
            {
                attckDown.SetActive(true);
            }
            else if (Player.pov == POV.lijevo)
            {
                attckLeft.SetActive(true);
            }
            else if (Player.pov == POV.desno)
            {
                attckRight.SetActive(true);
            }
            timer += Time.deltaTime;
            if (timer >= timeToAttack)
            {
                timer = 0;
                attacking = false;
                attckUp.SetActive(false);
                attckRight.SetActive(false);
                attckLeft.SetActive(false);
                attckDown.SetActive(false);
            }
        }
        else
        {
            animator.SetInteger("Sword", 0);
        }
    }
}
