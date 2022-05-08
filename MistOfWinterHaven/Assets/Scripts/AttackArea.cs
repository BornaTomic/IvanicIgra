using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackArea : MonoBehaviour
{
    public float damage = 50;
    bool isInColl = false;
    GameObject enemy;
    // Start is called before the first frame update
    void Start()
    {
        enemy = GameObject.FindGameObjectWithTag("Fighter");
    }

    // Update is called once per frame
    void Update()
    {
        if (isInColl)
        {
            enemy.GetComponent<Enemy>().hp -= damage;
            isInColl = false;
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Fighter")
        {
            isInColl = true;
        }
    }
}
