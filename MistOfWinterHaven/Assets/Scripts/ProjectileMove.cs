
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileMove : MonoBehaviour
{
    public int Direction;
    public float damage;
    public float speed;
    public float destroy;


    private void Update()
    {
        if(Direction == 0)
        {
            transform.Translate(speed * Time.deltaTime,0,0);
        }
        if (Direction == 1)
        {
            transform.Translate(0, speed * Time.deltaTime, 0);
        }
        if (Direction == 2)
        {
            transform.Translate(-speed * Time.deltaTime, 0, 0);
        }
        if (Direction == 3)
        {
            transform.Translate(0, -speed * Time.deltaTime, 0);
        }
        destroy = destroy - Time.deltaTime;
        if (destroy <= 0) Destroy(gameObject);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            GameManager.instance.CurrentHEalth = GameManager.instance.CurrentHEalth - damage;
        }
    }
}
