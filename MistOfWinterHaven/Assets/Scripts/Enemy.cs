using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : Kretnje
{
    public int xpVal = 1;//vrijednost exp-a koju ce enemy dati pri smrti


    public float triggerLenght = 1;//Varijable osnovne
    public float chaseLenght = 5;//isto kao gore
    private bool chasing;//isto kao gore
    private bool collidingWithPlayer;//isto kao gore
    private Transform playerTransform;//isto kao gore
    private Vector3 startingPosition;//isto kao gore

    public ContactFilter2D filter;//dodajemo ContactFilter2D
    private BoxCollider2D hitbox;//Dodajemo boxColl
    private Collider2D[] hits = new Collider2D[10];//lista za hitse

    protected override void Start()
    {
        base.Start();
        playerTransform = GameManager.instance.player.transform;
        startingPosition = transform.position;//stavljanje start pozicije
        hitbox = transform.GetChild(0).GetComponent<BoxCollider2D>();//Ovdje dohvacamo collider od enemya
    }

    private void FixedUpdate()
    {
        if (Vector3.Distance(playerTransform.position, startingPosition) < chaseLenght)
        {
            if (Vector3.Distance(playerTransform.position, startingPosition) < triggerLenght)//ako je player krocio unutar radiusa enemya gdje ga moze vidjeti
            {
                chasing = true;//enemy chasea
            }
            if (chasing)//ako chasea
            {
                if (!collidingWithPlayer)//ako nije u koliziji sa playerom
                {
                    UpdateMotor((playerTransform.position - transform.position).normalized);//kretanje enemya
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

    protected void Death()//Koristeno kad je hp prazan
    {
        Destroy(gameObject);//unistavamo gameObject
        GameManager.instance.exp += xpVal;//dodajemo exp na ukupni exp
        GameManager.instance.Show("+" + xpVal + " xp", 30, Color.green, playerTransform.position, Vector3.up * 40, 1.0f);//ispisujemo exp letecim tekstom
    }
}
