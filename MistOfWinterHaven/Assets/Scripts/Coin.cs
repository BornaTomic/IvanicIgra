using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
    int value = 0;
    public static bool isPickUp = false;
    // Start is called before the first frame update
    void Start()
    {
        value = Random.Range(0, 50);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            Score.score += value;
            isPickUp = true;
            //GameManager.instance.Show("Pokupio si " + value + " coinsa!", 25, Color.yellow, transform.position, Vector3.up * 30, 3f);
            Destroy(gameObject);
        }
    }
}
