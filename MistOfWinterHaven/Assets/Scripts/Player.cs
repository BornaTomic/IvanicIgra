using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float speed = 0f;
    Animator animator;
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
            animator.SetInteger("Anim", 1);
            animator.SetFloat("MoveX", 0);
            animator.SetFloat("MoveY", 1);
        }
        else if (Input.GetKey(KeyBindsManager.dictionary["MoveDown"]))
        {
            transform.Translate(0, -speed * Time.deltaTime, 0);
            animator.SetInteger("Anim", 1);
            animator.SetFloat("MoveX", 0);
            animator.SetFloat("MoveY", -1);
        }
        else if (Input.GetKey(KeyBindsManager.dictionary["MoveLeft"]))
        {
            transform.Translate(-speed * Time.deltaTime, 0, 0);
            animator.SetInteger("Anim", 1);
            animator.SetFloat("MoveX", -1);
            animator.SetFloat("MoveY", 0);
        }
        else if (Input.GetKey(KeyBindsManager.dictionary["MoveRight"]))
        {
            transform.Translate(speed * Time.deltaTime, 0, 0);
            animator.SetInteger("Anim", 1);
            animator.SetFloat("MoveX", 1);
            animator.SetFloat("MoveY", 0);
        }
        else
        {
            animator.SetInteger("Anim", 0);
        }
    }
}
