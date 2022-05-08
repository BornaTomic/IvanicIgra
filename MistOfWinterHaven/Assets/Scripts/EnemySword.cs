using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySword : MonoBehaviour
{
    Animator animator;
    bool isColl = false;
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (isColl)
        {
            StartCoroutine(SwordAnim());
        }
        else
        {
            animator.SetInteger("Anim", 0);
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        isColl = true;
    }
    IEnumerator SwordAnim()
    {
        animator.SetInteger("Anim", 1);
        yield return new WaitForSeconds(2f);
        isColl = false;
    }
}
