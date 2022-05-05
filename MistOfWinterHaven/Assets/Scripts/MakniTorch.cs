using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MakniTorch : MonoBehaviour
{
    GameObject torch;
    // Start is called before the first frame update
    void Start()
    {
        torch = GameObject.FindGameObjectWithTag("Torch");
    }

    // Update is called once per frame
    void Update()
    {

    }
    public void RemoveTorch()
    {
        Destroy(torch);
        Destroy(gameObject);
    }
}
