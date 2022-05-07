using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Kiselina : MonoBehaviour
{
    bool canDie = false;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(Wait());
        StartCoroutine(Destroy2());
    }

    // Update is called once per frame
    void Update()
    {
        
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

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player" && canDie)
        {
            Destroy(collision.gameObject);
        }
    }
}
