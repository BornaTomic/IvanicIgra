using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fighter : MonoBehaviour
{
    public int hp = 10;//varijable
    public int maxHp = 10;//isto kao gore
    public float pushRecSpeed = 0.1f;//isto kao gore

    protected float immuneTime = 1.0f;//vrijeme imuniteta nakon zadnjeg odgurivanja
    protected float lastImmune;//kad je zadnje imun bio

    protected Vector3 pushDirection;

    protected virtual void ReceiveDamage(DmgContainer dmg) //tu si napisao RecIeveDmg umjesto ReceiveDamage jel ja na ovo moram vecer trosit, ovo se desi kad ne prokomentiras odma sta napises, pazi za ubuduce
    {
        if(Time.time - lastImmune > immuneTime) //Ako je Vrijeme - lastImmune(Zadnje "IMUN") vece od ImmuneTime, mozemo opet  primit dmg
        {
            lastImmune = Time.time; //postavljamo lastImmune da je trenutno vrijeme
            hp -= dmg.dmgAmmount;  //HP -= dmg nemoram puno rec
            pushDirection = (transform.position - dmg.origin).normalized * dmg.pushForce;  //samo smijer gdje ce biti odgurnut

            GameManager.instance.Show(dmg.dmgAmmount.ToString(), 40, Color.red, transform.position, Vector3.zero, 0.5f); //Napomena ovdje je Vector3.zero jer netreba micanje tog efekta

            if (hp <= 0)//ako je hp manji ili jednak nuli
            {
                hp = 0;//hp je 0
            }
        }
    }
}
