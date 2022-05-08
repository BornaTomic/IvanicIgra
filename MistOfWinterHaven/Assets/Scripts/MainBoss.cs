using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainBoss : MonoBehaviour
{
    public GameObject Target;
    public GameObject ProjectailUp;
    public GameObject ProjectailDown;
    public GameObject ProjectailLeft;
    public GameObject ProjectailRight;
    public Animator anim;
    public float AtackCooldownLenght;
    public float speed;
    public float MaxHp;
    public float Hp;
    public float Ad;
    public bool atackCooldown;
    public bool InRange = false;
    public bool jumpOnTarget;
    public float JumpCooldown;
    void Update()
    {
        //provjera za hp
        if (Hp > MaxHp) Hp = MaxHp;
        //mowment
        if (Target.transform.position.x > transform.position.x)
        {
            if (Target.transform.position.x - transform.position.x <= speed * Time.deltaTime)
            {
                transform.position = new Vector3(Target.transform.position.x, transform.position.y, 0);
            }
            else
            {
                transform.Translate(speed * Time.deltaTime, 0, 0);
                anim.SetInteger("State", 2);
                gameObject.GetComponent<SpriteRenderer>().flipX = true;
            }
        }
        else if (Target.transform.position.x < transform.position.x)
        {
            if (transform.position.x - Target.transform.position.x <= speed * Time.deltaTime)
            {
                transform.position = new Vector3(Target.transform.position.x, transform.position.y, 0);
            }
            else
            {
                transform.Translate(-speed * Time.deltaTime, 0, 0);
                anim.SetInteger("State", 2);
                gameObject.GetComponent<SpriteRenderer>().flipX = false;
            }
        }
        else if (Target.transform.position.y > transform.position.y)
        {
            if (Target.transform.position.y - transform.position.y <= speed * Time.deltaTime)
            {
                transform.position = new Vector3(transform.position.x, Target.transform.position.y, 0);
                anim.SetInteger("State", 1);
            }
            else
            {
                transform.Translate(0, speed * Time.deltaTime, 0);
                anim.SetInteger("State", 1);
            }
        }
        else if (Target.transform.position.y < transform.position.y)
        {
            if (transform.position.y - Target.transform.position.y <= speed * Time.deltaTime)
            {
                transform.position = new Vector3(transform.position.x, Target.transform.position.y, 0);
                anim.SetInteger("State", 0);
            }
            else
            {
                transform.Translate(0, -speed * Time.deltaTime, 0);
                anim.SetInteger("State", 0);
            }
         }

        

        //Napad

        if (Hp <= MaxHp/2 && !jumpOnTarget) StartCoroutine(JompOnTarget());

        else if (Hp <= MaxHp && InRange) StartCoroutine(atack());
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            if (Hp <= MaxHp)
            {
                InRange = true;
            }
        }
    }

    IEnumerator atack()
    {
            if (atackCooldown == false)
            {
                GameManager.instance.CurrentHEalth = GameManager.instance.CurrentHEalth - Ad;
                atackCooldown = true;
                InRange = false;
            }
            yield return new WaitForSeconds(AtackCooldownLenght);
            atackCooldown = false;
    }

    IEnumerator JompOnTarget()
    {
            transform.position = Target.transform.position;
        anim.SetBool("jump", true);
            jumpOnTarget = true;
            Instantiate(ProjectailUp, transform.position, Quaternion.identity);
            Instantiate(ProjectailDown, transform.position, Quaternion.identity);
            Instantiate(ProjectailLeft, transform.position, Quaternion.identity);
            Instantiate(ProjectailRight, transform.position, Quaternion.identity);
        yield return new WaitForEndOfFrame();
        anim.SetBool("jump", false);
        yield return new WaitForSeconds(JumpCooldown);
        jumpOnTarget = false;
    }

}
