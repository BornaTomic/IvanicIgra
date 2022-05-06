using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : Collidables
{
    public int[] damagePoints = { 1, 2, 3, 4, 5, 6, 7 };//ovo je dmg svih varijanti oruzija
    public float[] pushForce = { 1.5f, 2.0f, 2.5f, 3.0f, 3.5f, 4.0f, 5.0f };//snaga guranja svih varijanti oruzija

    public int weaponLevel = 0;//level oruzija
    public SpriteRenderer spriteRenderer; //e promjenio sam u public da mos preko inspectora assignat lakse je neg preko koda patit se

    private Animator anim;//animator
    private float cooldown = 0.5f;//vrijeme izmedju zamaha
    private float lastSwing;//zadnji put zamahnuto macem

    protected override void Start()
    {
        base.Start(); //isto kao da smo napisali boxCollider = GetComponent<BoxCollider2D>();
        //spriteRenderer = GetComponent<SpriteRenderer>();
        anim = GetComponent<Animator>();//uzimamo komponentu animator
    }

    protected override void Update()
    {
        base.Update();

        if (Input.GetKeyDown(KeyCode.Space))//stavio sam da se udara na space
        {
            if (Time.time - lastSwing > cooldown)//ako je vrijeme - zadnji zamah vece od cooldowna
            {
                lastSwing = Time.time;//zadnji zamah postaje trenutno vrijeme
                Swing();//zamahni macem
            }
        }
    }

    protected override void OnCollide(Collider2D coll)
    {
        if (coll.tag == "Fighter")//ako je sudareno sa fighterom
        {
            if (coll.name == "Player")//ako je Player
                return;//vrati se

            DmgContainer dmg = new DmgContainer
            {
                dmgAmmount = damagePoints[weaponLevel],
                origin = transform.position,
                pushForce = pushForce[weaponLevel]
            };

            coll.SendMessage("ReceiveDamage", dmg);//opet ovaj send message pisao sam o tom u drugoj skripti

            Debug.Log(coll.name);     //debugging, korisno za mene izbrisi ako smeta
        }
    }

    private void Swing()
    {
        Debug.Log("Swing");//jos debugging

        anim.SetTrigger("Swing");    //krece animacija zamaha
    }

    public void UpgradeWeapon()
    {
        weaponLevel++;//povecavanje lvla oruzija
        spriteRenderer.sprite = GameManager.instance.weaponSprites[weaponLevel];//uzimanje pravilnog spritea
    }

    public void SetWeaponLevel(int level)
    {
        weaponLevel = level;//postavljanje levela oruzija
        spriteRenderer.sprite = GameManager.instance.weaponSprites[weaponLevel];//uzimanje adekvatnoga spritea isto
    }
}
