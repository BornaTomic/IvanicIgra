using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Necromancer : MonoBehaviour
{
    public float Hp;
    public GameObject Target;
    public float speed;
    public bool Doing;
    public GameObject SpawningEnemy;
    public float spawningDelay;
    public bool CanSpawn;
    public Animator anim;
    private void Start()
    {
        Target = GameObject.FindWithTag("Player");
    }

    public void Update()
    {

        if(Doing == false && CanSpawn == true)
        {
            StartCoroutine(Spawn());
            anim.SetInteger("State", 0);
        }
        else if(Doing == false)
        {
            StartCoroutine(Mowe());
        }
        if(Hp <= 0)
        {
            StartCoroutine(Death());
        }
    }

    public IEnumerator Mowe()
    {

        Doing = true;
        if (Target.transform.position.x > transform.position.x)
        {
            transform.Translate(speed * Time.deltaTime, 0, 0);
            gameObject.GetComponent<SpriteRenderer>().flipX = false;
            anim.SetInteger("State", 2);
        }
        else if (Target.transform.position.x < transform.position.x)
        {
            transform.Translate(-speed * Time.deltaTime, 0, 0);
            gameObject.GetComponent<SpriteRenderer>().flipX = true;
            anim.SetInteger("State", 1);
        }
         if (Target.transform.position.y > transform.position.y)
        {
            transform.Translate(0, speed * Time.deltaTime, 0);
        }
        else if (Target.transform.position.y < transform.position.y)
        {
            transform.Translate(0, -speed * Time.deltaTime, 0);
        }
        yield return new WaitForEndOfFrame();
        Doing = false;
    }
    public IEnumerator Spawn()
    {
        Doing = true;
        CanSpawn = false;
        Instantiate(SpawningEnemy, transform.position, Quaternion.identity);
        Instantiate(SpawningEnemy, transform.position, Quaternion.identity);
        Doing = false;
        yield return new WaitForSeconds(spawningDelay);
        CanSpawn = true;
    }

    public IEnumerator Death()
    {
        Instantiate(SpawningEnemy, transform.position, Quaternion.identity);
        Instantiate(SpawningEnemy, transform.position, Quaternion.identity);
        Instantiate(SpawningEnemy, transform.position, Quaternion.identity);
        Instantiate(SpawningEnemy, transform.position, Quaternion.identity);
        Instantiate(SpawningEnemy, transform.position, Quaternion.identity);
        Instantiate(SpawningEnemy, transform.position, Quaternion.identity);
        Destroy(gameObject);
        yield return new WaitForEndOfFrame();

    }
}
