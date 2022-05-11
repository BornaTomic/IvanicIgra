using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Snake : MonoBehaviour
{
    public float hp = 100;
    public Transform[] waypoints;
    public float speed = 0.2f;
    private int waypointIndex = 0;
    Rigidbody2D rb;
    public GameObject prefab;
    public GameObject kiselina;
    public static int snakeLenght = 0;
    bool isAttackedSword = false;
    bool isAttackedBullett = false;
    public float damage = 30;
    bool isInColl = false;
    bool canAttack = true;
    GameObject gamemanager;
    // Start is called before the first frame update
    void Start()
    {
        gamemanager = GameObject.Find("GameManager");
        StartCoroutine(Spawn());
        rb = GetComponent<Rigidbody2D>();
        this.transform.position = GameObject.Find("WayPoint").transform.position;
        waypoints[0] = GameObject.Find("WayPoint").transform;
        waypoints[1] = GameObject.Find("WayPoint (1)").transform;
        waypoints[2] = GameObject.Find("WayPoint (2)").transform;
        waypoints[3] = GameObject.Find("WayPoint (3)").transform;
        waypoints[4] = GameObject.Find("WayPoint (4)").transform;
        waypoints[5] = GameObject.Find("WayPoint (5)").transform;
        waypoints[6] = GameObject.Find("WayPoint (6)").transform;
        waypoints[7] = GameObject.Find("WayPoint (7)").transform;
        waypoints[8] = GameObject.Find("WayPoint (8)").transform;
        waypoints[9] = GameObject.Find("WayPoint (9)").transform;
        waypoints[10] = GameObject.Find("WayPoint (10)").transform;
        waypoints[11] = GameObject.Find("WayPoint (11)").transform;
        waypoints[12] = GameObject.Find("WayPoint (12)").transform;
        waypoints[13] = GameObject.Find("WayPoint (13)").transform;
        waypoints[14] = GameObject.Find("WayPoint (14)").transform;
        waypoints[15] = GameObject.Find("WayPoint (15)").transform;
        waypoints[16] = GameObject.Find("WayPoint (16)").transform;
        
    }

    // Update is called once per frame
    void Update()
    {
        if (isAttackedBullett)
        {
            hp -= Player.damage;
            isAttackedBullett = false;
        }
        if (isAttackedSword)
        {
            hp -= 50;
            isAttackedSword = false;
        }
        if (isInColl && canAttack)
        {
            StartCoroutine(DealDamage());
            isInColl = false;
        }
        if (hp <= 0)
        {
            Destroy(gameObject);
        }
        if (waypointIndex <= waypoints.Length - 1)
        {
            Vector2 newPos = Vector2.MoveTowards(transform.position, waypoints[waypointIndex].transform.position, speed);
            rb.MovePosition(newPos);
            if (transform.position == waypoints[waypointIndex].transform.position)
            {
                waypointIndex++;
                if (waypointIndex < waypoints.Length)
                {
                    Vector3 direction = waypoints[waypointIndex].transform.position - this.transform.position;
                    float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
                    rb.rotation = angle;
                }
            }
            if (waypointIndex == waypoints.Length)
            {
                waypointIndex = 0;
            }
        }
    }
    IEnumerator Spawn()
    {
        if (snakeLenght < 20)
        {
            yield return new WaitForSeconds(0.1f);
            var obj = Instantiate(prefab, new Vector3(transform.position.x, transform.position.y, 0), Quaternion.identity) as GameObject;
            obj.transform.parent = gameObject.transform;
            snakeLenght++;
        }
    }
    IEnumerator DealDamage()
    {
        gamemanager.GetComponent<GameManager>().CurrentHEalth -= damage;
        canAttack = false;
        Player.isDamaged = true;
        yield return new WaitForSeconds(2f);
        canAttack = true;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            isInColl = true;
        }
        if (collision.gameObject.tag == "AttackArea")
        {
            isAttackedSword = true;
        }
        if (collision.gameObject.tag == "Bullett")
        {
            Destroy(collision.gameObject);
            isAttackedBullett = true;
        }
    }
}
