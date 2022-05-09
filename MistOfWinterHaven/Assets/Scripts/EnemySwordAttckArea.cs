using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySwordAttckArea : MonoBehaviour
{
    public float damage = 10;
    bool isInColl = false;
    GameObject gamemanager;
    // Start is called before the first frame update
    void Start()
    {
        gamemanager = GameObject.Find("GameManager");   
    }

    // Update is called once per frame
    void Update()
    {
        if (isInColl)
        {
            gamemanager.GetComponent<GameManager>().CurrentHEalth -= damage;
            isInColl = false;
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            isInColl = true;
        }
    }
}
