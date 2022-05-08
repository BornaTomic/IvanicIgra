using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHitBox : Collidables
{
    public int damage = 1;//varijable za dmg i snagu odgurivanja
    public float pushForce = 5;//ovo gore

    protected override void OnCollide(Collider2D coll)//OnCollide je sto se desava pri sudaru
    {
        if(coll.tag == "Fighter" && coll.name == "Player")//ako su se sudarili Fighter i Player
        {
            DmgContainer dmg = new DmgContainer//novi dmgContainer
            {
                dmgAmmount = damage,
                origin = transform.position,
                pushForce = pushForce
            };

            coll.SendMessage("ReceiveDamage", dmg);//ovdje koristim send message, slicno kao da sam pozvao tu drugu skriptu ali malo optimiziranije
        }
    }
}
