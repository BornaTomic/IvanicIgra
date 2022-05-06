using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chest : MonoBehaviour
{
    public GameObject tekst;
    public GameObject loot;
    Animator animator;
    bool isCollision = false;
    bool isOpen = false;
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && isCollision)
        {
            animator.SetInteger("ChestAnim", 1);
            var obj = Instantiate(loot, new Vector3(transform.position.x, transform.position.y + 1, 0), Quaternion.identity) as GameObject;
            isCollision = false;
            isOpen = true;
            tekst.SetActive(false);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player" && !isOpen)
        {
            tekst.SetActive(true);
            isCollision = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            tekst.SetActive(false);
            isCollision = false;
        }
    }
}
