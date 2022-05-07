using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnSnake : MonoBehaviour
{
    public GameObject snake;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(Spawner());
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    IEnumerator Spawner()
    {
        yield return new WaitForSeconds(1f);
        Instantiate(snake, new Vector3(transform.position.x, transform.position.y, 0), Quaternion.identity);
    }
}
