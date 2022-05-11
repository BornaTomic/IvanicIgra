using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Kiselina : MonoBehaviour
{
    bool canDie = false;
    GameObject gameManager;
    bool isInColl = false;
    public float damage = 10;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(Wait());
        StartCoroutine(Destroy2());
        gameManager = GameObject.Find("GameManager");
    }

    // Update is called once per frame
    void Update()
    {
        if (isInColl)
        {
            StartCoroutine(DealDamage());
        }
    }
    IEnumerator Wait()
    {
        yield return new WaitForSeconds(1f);
        canDie = true;
    }
    IEnumerator Destroy2()
    {
        yield return new WaitForSeconds(3f);
        Destroy(gameObject);
    }
    IEnumerator DealDamage()
    {
        gameManager.GetComponent<GameManager>().CurrentHEalth -= damage;
        yield return new WaitForSeconds(1.5f);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player" && canDie)
        {
            isInColl = true;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player" && canDie)
        {
            isInColl = false;
        }
    }
}
