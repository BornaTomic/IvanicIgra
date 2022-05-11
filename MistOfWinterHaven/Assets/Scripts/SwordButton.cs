using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SwordButton : MonoBehaviour
{
    public static bool isSword = false;
    public GameObject sword;
    public GameObject border;
    GameObject swordObj;
    GameObject canvas1;
    // Start is called before the first frame update
    void Start()
    {
        swordObj = GameObject.Find("SwordObj");
        canvas1 = GameObject.FindGameObjectWithTag("Kanvas");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void GetSword()
    {
        if (!TorchButton.isTorch)
        {
            var obj = Instantiate(sword, new Vector3(swordObj.transform.position.x + 0.375f, swordObj.transform.position.y + 0.393f, 0), Quaternion.identity) as GameObject;
            var obj2 = Instantiate(border, new Vector3(transform.position.x, transform.position.y, 0), Quaternion.identity) as GameObject;
            obj.transform.parent = swordObj.transform;
            obj2.transform.SetParent(canvas1.transform);
            isSword = true;
        }
    }
}
