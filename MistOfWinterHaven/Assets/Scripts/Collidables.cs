using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collidables : MonoBehaviour
{
    public ContactFilter2D filter; //Filter da definiramo sa cim se tocno collideamo
    private BoxCollider2D boxCollider; //Box collider to to
    private Collider2D[] hits = new Collider2D[10];               //cak jos jednu listu imam wow, 10 je previse al nemoze naskodit  

    protected virtual void Start()
    {
        boxCollider = GetComponent<BoxCollider2D>();      //uzimamo BoxCollider2D komponentu
    }

    protected virtual void Update()            //Zaboravio rec virtual se koristi kako bih mogli re definirati u klasama nasljedjenima iz ove, primjer imas u MagicniPortal di mjenjam OnCollide
    {
        boxCollider.OverlapCollider(filter, hits);  //Uzima onaj gore filter i hits, znaci ovo trazi drugi coll iznad ili ispod ovoga i stavlja ga u hits  gore
        for (int i = 0; i < hits.Length; i++)                         //For petlja.....
        {
            if (hits[i] == null)//ako je taj index u hitsima prazan
            {
                continue;//nastavi
            }

            OnCollide(hits[i]);           //ovo je samo meni pozivanje OnCollide za debuganje

            Debug.Log(hits[i].name);                      //Super jos  debuganja

            hits[i] = null;               //Cistimo listu
        }
    }
    protected virtual void OnCollide(Collider2D coll)//Koristeno trenutno za debugging, i ako kasnije vidim tu korist
    {
        Debug.Log(coll.name);                            //Meni da pomogne sa playtestanjem, realno jedini doprinos ove linije ovdije
    }
}
