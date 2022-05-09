using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : Kretnje
{
    public int xpVal = 1;//vrijednost exp-a koju ce enemy dati pri smrti
    public float hp = 10;//varijable
    public float maxHp = 10;//isto kao gore


    public float triggerLenght = 1;//Varijable osnovne
    public float chaseLenght = 5;//isto kao gore
    private bool chasing;//isto kao gore
    private bool collidingWithPlayer;//isto kao gore
    //private bool isInRange;
    private GameObject playerTransform;//isto kao gore
    private Vector3 startingPosition;//isto kao gore

    public ContactFilter2D filter;//dodajemo ContactFilter2D
    private BoxCollider2D hitbox;//Dodajemo boxColl
    private Collider2D[] hits = new Collider2D[10];//lista za hitse
    private Animator animator;
    private SpriteRenderer sr;
    bool isAttackedSword = false;
    bool isAttackedBullett = false;

    protected override void Start()
    {
        base.Start();
        animator = GetComponent<Animator>();
        sr = GetComponent<SpriteRenderer>();
        playerTransform = GameObject.FindGameObjectWithTag("Player");
        startingPosition = transform.position;//stavljanje start pozicije
        hitbox = transform.GetChild(0).GetComponent<BoxCollider2D>();//Ovdje dohvacamo collider od enemya
    }

    private void FixedUpdate()
    {
        if (Vector3.Distance(playerTransform.transform.position, startingPosition) < chaseLenght)
        {
            if (Vector3.Distance(playerTransform.transform.position, startingPosition) < triggerLenght)//ako je player krocio unutar radiusa enemya gdje ga moze vidjeti
            {
                chasing = true;//enemy chasea
            }
            if (chasing)//ako chasea
            {
                if (!collidingWithPlayer)//ako nije u koliziji sa playerom
                {
                    UpdateMotor((playerTransform.transform.position - transform.position).normalized);//kretanje enemya
                }
            }
            else
            {
                UpdateMotor(startingPosition - transform.position);//opet kretanje enemya
            }
        }
        else
        {
            UpdateMotor(startingPosition - transform.position);//isto kretnja enemya
            chasing = false;//ne chasea
        }

        collidingWithPlayer = false;//ne sudaramo se sa playerom vise
        boxCollider.OverlapCollider(filter, hits);
        for (int i = 0; i < hits.Length; i++)                         //For petlja.....
        {
            if (hits[i] == null)//ako je taj index u listi prazan
                continue;//nastavi

            if (hits[i].tag == "Fighter" && hits[i].name == "Player")//ako su tagovi Fighter i Player
            {
                collidingWithPlayer = true;//znaci da se enemy collidea sa playerom
            }
            //Debug.Log(hits[i].name);                      //Super jos  debuganja

            hits[i] = null;               //Cistimo listu
        }
        UpdateMotor(Vector3.zero);//Mjenjamo vector
    }

    private void Update()
    {
        if (isAttackedBullett)
        {
            hp -= Player.damage;
            isAttackedBullett = false;
        }
        if (isAttackedSword)
        {
            hp -= 50;
            isAttackedSword = false;
        }
        if (gameObject.transform.position.y - playerTransform.transform.position.y < 0)
        {
            animator.SetInteger("Anim", 1);
        }
        else if (gameObject.transform.position.y - playerTransform.transform.position.y > 0)
        {
            animator.SetInteger("Anim", 3);
        }
        else if (gameObject.transform.position.x - playerTransform.transform.position.x > 0)
        {
            sr.flipX = true;
            animator.SetInteger("Anim", 2);
        }
        else if (gameObject.transform.position.x - playerTransform.transform.position.x < 0)
        {
            sr.flipX = false;
            animator.SetInteger("Anim", 2);
        }
        if (hp <= 0)
        {
            Destroy(gameObject);
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "AttackArea")
        {
            isAttackedSword = true;
        }
        if (collision.gameObject.tag == "Bullett")
        {
            Destroy(collision.gameObject);
            isAttackedBullett = true;
        }
    }
}
