using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    public float speed = 0f;
    public POV pov = POV.desno;
    Animator animator;
    public static float damage;
    public Slider slider;
    public GameObject bullett;
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyBindsManager.dictionary["MoveUp"]))
        {
            transform.Translate(0, speed * Time.deltaTime, 0);
            pov = POV.gore;
            animator.SetInteger("Anim", 1);
            animator.SetFloat("MoveX", 0);
            animator.SetFloat("MoveY", 1);
        }
        else if (Input.GetKey(KeyBindsManager.dictionary["MoveDown"]))
        {
            transform.Translate(0, -speed * Time.deltaTime, 0);
            pov = POV.dolje;
            animator.SetInteger("Anim", 1);
            animator.SetFloat("MoveX", 0);
            animator.SetFloat("MoveY", -1);
        }
        else if (Input.GetKey(KeyBindsManager.dictionary["MoveLeft"]))
        {
            transform.Translate(-speed * Time.deltaTime, 0, 0);
            pov = POV.lijevo;
            animator.SetInteger("Anim", 1);
            animator.SetFloat("MoveX", -1);
            animator.SetFloat("MoveY", 0);
        }
        else if (Input.GetKey(KeyBindsManager.dictionary["MoveRight"]))
        {
            transform.Translate(speed * Time.deltaTime, 0, 0);
            pov = POV.desno;
            animator.SetInteger("Anim", 1);
            animator.SetFloat("MoveX", 1);
            animator.SetFloat("MoveY", 0);
        }
        else
        {
            animator.SetInteger("Anim", 0);
        }
        if (Input.GetKeyDown(KeyCode.F))
        {
            damage = slider.value;
            slider.value = 0;
            var obj = Instantiate(bullett, new Vector3(transform.position.x, transform.position.y, 0), Quaternion.identity) as GameObject;
            obj.GetComponent<Bullett>().povB = pov;
        }
    }
}

public enum POV
{
    gore,
    dolje,
    desno,
    lijevo
}
