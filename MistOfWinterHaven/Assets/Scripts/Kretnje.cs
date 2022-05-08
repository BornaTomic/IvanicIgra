using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Kretnje : Fighter //abstract znaci nema vise drag and dropanja ovog na objekte, moze samo biti nasljedjeno, to vec daje ideju za sta mi ova klasa sluzi
{
    protected BoxCollider2D boxCollider;
    private Vector3 moveDelta;                          //jednostavna stvar, skuzit cu sta je sutra kad ovo citam isto
    private RaycastHit2D hit;                            //raycast je nevidljiv "Laser" koji koristi pri kolizijama
    protected float ySpeed = 7.5f;//varijable
    protected float xSpeed = 10f;//isto kao gore

    protected virtual void Start()
    {
        boxCollider = GetComponent<BoxCollider2D>();        //uzimamo component BoxCollider2D
    }

    protected virtual void UpdateMotor(Vector3 input)
    {
        moveDelta = new Vector3(input.x * xSpeed, input.y * ySpeed, 0); //Samo resetira moveDeltu

        if (moveDelta.x > 0) //mjenjanje smijera spritea
        {
            transform.localScale = Vector3.one;
        }
        else if (moveDelta.x < 0)//isto kao gore
        {
            transform.localScale = new Vector3(-1, 1, 1);
        }

        moveDelta += pushDirection; //dodavanje guranja pri koliziji

        pushDirection = Vector3.Lerp(pushDirection, Vector3.zero, pushRecSpeed); // smanjivanje sile odgurivanja inace bi vjecno isao 

        hit = Physics2D.BoxCast(transform.position, boxCollider.size, 0, new Vector2(0, moveDelta.y), Mathf.Abs(moveDelta.y * Time.deltaTime), LayerMask.GetMask("Actor", "Blocking"));//Ukratko da ovo skratim, ako prepozna layer actor ili blocking nece moci tu hodati
        if (hit.collider == null)
        {
            transform.Translate(0, moveDelta.y * Time.deltaTime, 0);                //tu sam se igrao sa  ghost colliderom, da budem iskren nije radilo jucer danas radi ne znam zasto
        }                                                                             //radi na principu napravimo collider koji se krece ispred playera i orjentira po layerima kao sto vidimo po GetMask, imamo zasebno napisan za x i y osi
        hit = Physics2D.BoxCast(transform.position, boxCollider.size, 0, new Vector2(moveDelta.x, 0), Mathf.Abs(moveDelta.x * Time.deltaTime), LayerMask.GetMask("Actor", "Blocking"));//Isto kao ovo gore ali za drugu os
        if (hit.collider == null)
        {
            transform.Translate(moveDelta.x * Time.deltaTime, 0, 0);
        }
    }
 }
